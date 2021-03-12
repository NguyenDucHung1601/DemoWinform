using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoFluentValidation {
    public partial class FormThongTinBoSoChoCacKhoanMucTrinhBayTrongBCKQHDTH : Form {
        #region Variable
        DataTable g_table = new DataTable();
        Dictionary<int, string> g_dictError = new Dictionary<int, string>();
        List<GridColumn> g_listValidateCol = new List<GridColumn>();
        List<RuleTable> g_listRule = new List<RuleTable>();
        List<Dictionary<int, string>> g_listDictError = new List<Dictionary<int, string>>();
        List<string> g_listValidateColName = new List<string>();
        OPERATOR OpeCommon;
        #endregion

        #region Constructor
        public FormThongTinBoSoChoCacKhoanMucTrinhBayTrongBCKQHDTH() {
            InitializeComponent();
            gridData.OptionsBehavior.Editable = false;
            g_table.Clear();
            g_table.Columns.Add("STT", typeof(string));
            g_table.Columns.Add("ChiTiet", typeof(string));
            g_table.Columns.Add("MaSo", typeof(string));
            g_table.Columns.Add("NamNay", typeof(double));
            g_table.Columns.Add("NamTruoc", typeof(double));
            g_table.Columns.Add("ThuyetMinh", typeof(string));

            g_listValidateColName.AddRange(new string[] { "NamNay", "NamTruoc" });
        }
        #endregion

        #region Business
        private void LoadFakeData() {
            g_table.Rows.Add(new object[] { "IV", "Thông tin bổ sung cho các khoản mục trình bày trong báo cáo kết quả hoạt động tổng hợp", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Hoạt động hành chính sự nghiệp", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1.1", "Doanh thu", "01", 0, 0, "   01 = 02 + 05 + 08" });
            g_table.Rows.Add(new object[] { "a", "Từ NSNN cấp:", "02", 10000000, 0, "   02 = 03 + 04" });
            g_table.Rows.Add(new object[] { "", "- Nhận NSN cấp (thường xuyên, không thường xuyên)", "03", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Nguồn hoạt động khác được phép để lại", "04", 136127757, 136127757, "" });
            g_table.Rows.Add(new object[] { "b", "Từ nguồn viện trợ, vay nợ nước ngoài", "05", 138946757, 138946757, "  05 = 06 + 07" });
            g_table.Rows.Add(new object[] { "", "- Thu viện trợ", "06", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "- Thu vay nợ nước ngoài", "07", 20000000, 20000000, "" });
            g_table.Rows.Add(new object[] { "c", "Từ nguồn phí được khấu trừ, để lại (có thể chi tiết theo loại phí hoặc theo yêu cầu quản lý)", "08", 3000000, 3000000, "" });
            g_table.Rows.Add(new object[] { "1.2", "Chi phí", "09", 2000000, 2000000, "     09 = 10 + 15 + 20 + 23" });
            g_table.Rows.Add(new object[] { "a", "Chi phí hoạt động thường xuyên", "10", 17181000, 13181000, "     10 = 11 + 12 + 13 + 14" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương, tiền công và chí phí khác cho nhân viên", "11", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "12", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hao mòn TSCĐ", "13", 2000000, 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "14", 20000000, 20000000, "" });
            g_table.Rows.Add(new object[] { "b", "Chi phí hoạt động không thường xuyên", "15", 500000, 500000, "     15 = 16 + 17 + 18 + 19" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương, tiền công và chí phí khác cho nhân viên", "16", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "17", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hao mòn TSCĐ", "18", 2000000, 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "19", 20000000, 20000000, "" });
            g_table.Rows.Add(new object[] { "c", "Chi phí từ nguồn vợ trợ, vay nợ nước ngoài", "20", 2000000, 2000000, "     20 = 21 + 22" });
            g_table.Rows.Add(new object[] { "", "- Chi từ nguồn viện trợ", "21", 4000000, 4000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi vay nợ nước ngoài", "22", 1000000, 1000000, "" });
            g_table.Rows.Add(new object[] { "d", "Chi phí hoạt động thu phí", "23", 0, 1000000, "     23 = 24 + 25 + 26 + 27" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương, tiền công và chí phí khác cho nhân viên", "24", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "25", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hao mòn TSCĐ", "26", 2000000, 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "27", 20000000, 20000000, "" });
            g_table.Rows.Add(new object[] { "2", "Hoạt động sản xuất kinh doanh, dịch vụ", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "a", "Doanh thu", "28", 0, 0, "" });
            g_table.Rows.Add(new object[] { "b", "Chi phí", "29", 0, 0, "   29 = 30 + 31 + 32 + 33 + 34 + 35" });
            g_table.Rows.Add(new object[] { "", "- Giá vốn bán hàng", "30", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí quản lý", "31", 136127757, 136127757, "" });
            g_table.Rows.Add(new object[] { "", "+ Chi phí tiền lương, tiền công và chi phí khác cho nhân viên", "32", 138946757, 138946757, "" });
            g_table.Rows.Add(new object[] { "", "+ Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "33", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "+ Chi phí khấu hao TSCĐ", "34", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "+ Chi phí hoạt động khác", "35", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "3", "Hoạt động tài chính", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "a", "Doanh thu (chi tiết)", "36", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "b", "Chi phí (chi tiết)", "37", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "4", "Hoạt động khác", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "a", "Thu nhập khác (chi tiết)", "38", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "b", "Chi phí khác (chi tiết)", "39", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "5", "Phân phối cho các quỹ", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "a", "Quỹ khen thưởng", "40", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "b", "Quỹ phúc lợi", "41", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "c", "Quỹ bổ sung thu nhập", "42", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "d", "Quỹ phát triển hoạt động sự nghiệp", "43", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "e", "Quỹ khác (chi tiết)", "44", 5000000, 5000000, "" }); 
            g_table.Rows.Add(new object[] { "", "Tổng số đã phân phối cho các quỹ trong năm", "45", 5000000, 5000000, "   45 = 40 + 41 + 42 + 43 + 44" });
            g_table.Rows.Add(new object[] { "6", "Sử dụng kính phí tiết kiệm của đơn vị hành chính", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "a", "Bổ sung thu nhập cho CBCC và người lao động", "46", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "b", "Chi khen thưởng", "47", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "c", "Chi cho các hoạt động phúc lợi tập thể", "48", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "Tổng số đã sử dụng kinh phí tiết kiệm", "49", 5000000, 5000000, "   49 = 46 + 47 + 48" });
            g_table.Rows.Add(new object[] { "V", "Thông tin bổ sung cho các khoản mục trình bày trong báo cáo lưu chuyển tiền tệ tổng hợp", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Các giao dịch không bằng tiền trong kỳ ảnh hưởng đến báo cáo lưu chuyển tiền tệ", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Mua tài sản bằng nhận nợ", "50", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Tài sản được cấp từ cấp trên", "51", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "- Tài sản nhận chuyển giao từ đơn vị khác", "52", 2000000, 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Các giao dịch phi tiền tệ khác", "53", 20000000, 20000000, "" });
            g_table.Rows.Add(new object[] { "", "Tổng cộng", "54", 0, 0, "   54 = 50 + 51 + 52 + 53" });

            gridControlData.DataSource = g_table;
            //gridData.OptionsView.ColumnAutoWidth = true;
            gridData.BestFitColumns();
        }

        public void CreateRule(string colValidate) {
            for (int i = 0; i < g_table.Rows.Count; i++) {
                if (!(g_table.Rows[i]["ThuyetMinh"].Equals(""))) {
                    string CompareExpress = "";
                    var strThuyetMinh = g_table.Rows[i]["ThuyetMinh"].ToString();
                    strThuyetMinh = Regex.Replace(strThuyetMinh, @"\s+", " ").Trim();
                    List<string> separateComEx = strThuyetMinh.Split('&').ToList();
                    foreach (string itemStr in separateComEx) {
                        List<string> arrCode = itemStr.Trim().Split().ToList();
                        GetOperator(arrCode[1]);
                        if (arrCode[2].Equals("0")) {
                            g_listRule.Add(new RuleTable($"A.{arrCode[0]}.{colValidate}", OpeCommon, 0, g_table));
                        }
                        else {
                            List<string> arrComEx = arrCode.GetRange(2, arrCode.Count - 2);
                            for (int j = 0; j < arrComEx.Count; j++) {
                                if (arrComEx[j].Equals("+")) {
                                    CompareExpress += " + ";
                                    continue;
                                }
                                else if (arrComEx[j].Equals("-")) {
                                    CompareExpress += " - ";
                                    continue;
                                }
                                CompareExpress += $"A.{arrComEx[j]}.{colValidate}";
                            }
                            g_listRule.Add(new RuleTable($"A.{arrCode[0]}.{colValidate}", OpeCommon, CompareExpress, g_table));
                            CompareExpress = "";
                        }
                    }
                }
            }
        }
        public void GetOperator(string value) {
            switch (value) {
                case ">":
                    OpeCommon = OPERATOR.GREAT_THAN;
                    break;
                case ">=":
                    OpeCommon = OPERATOR.GREAT_THAN_OR_EQUAL;
                    break;
                case "<":
                    OpeCommon = OPERATOR.LESS_THAN;
                    break;
                case "<=":
                    OpeCommon = OPERATOR.LESS_THAN_OR_EQUAL;
                    break;
                case "=":
                    OpeCommon = OPERATOR.EQUAL;
                    break;
                case "!=":
                    OpeCommon = OPERATOR.NOT_EQUAL;
                    break;
            }
        }

        public void CreateListRule() {
            foreach (string item in g_listValidateColName) {
                CreateRule(item);
            }
        }
        //public void CreateListRule() {
        //    foreach (string item in g_listValidateColName) {

        //        g_listRule.Add(new RuleTable($"A.04.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));

        //        g_listRule.Add(new RuleTable($"A.06.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));

        //        g_listRule.Add(new RuleTable($"A.10.{item}", OPERATOR.EQUAL, $"A.02.{item} + A.03.{item} + A.04.{item} + A.05.{item} + A.06.{item}  + A.07.{item} + A.01.{item}", g_table));

        //        g_listRule.Add(new RuleTable($"A.23.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

        //        g_listRule.Add(new RuleTable($"A.24.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

        //        g_listRule.Add(new RuleTable($"A.30.{item}", OPERATOR.EQUAL, $"A.21.{item} + A.22.{item} + A.23.{item} + A.24.{item}", g_table));

        //        g_listRule.Add(new RuleTable($"A.33.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

        //        g_listRule.Add(new RuleTable($"A.34.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

        //        g_listRule.Add(new RuleTable($"A.35.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

        //        g_listRule.Add(new RuleTable($"A.40.{item}", OPERATOR.EQUAL, $"A.31.{item} + A.32.{item} + A.33.{item} + A.34.{item} + A.35.{item}", g_table));

        //        g_listRule.Add(new RuleTable($"A.50.{item}", OPERATOR.EQUAL, $"A.10.{item} + A.30.{item} + A.40.{item}", g_table));

        //        g_listRule.Add(new RuleTable($"A.80.{item}", OPERATOR.EQUAL, $"A.50.{item} + A.60.{item} + A.70.{item}", g_table));
        //    }

        //    g_listRule.Add(new RuleTable($"A.60.{g_listValidateColName[0]}", OPERATOR.EQUAL, $"A.80.{g_listValidateColName[1]}", g_table));

        //    g_listRule.Add(new RuleTable($"A.80.{g_listValidateColName[1]}", OPERATOR.EQUAL, $"A.60.{g_listValidateColName[0]}", g_table));
        //}

        public void FormatingRule() {
            foreach (GridColumn item in g_listValidateCol) {
                // Hightlight Error ======================================================
                GridFormatRule gridFormatRule1 = new GridFormatRule();
                FormatConditionRuleExpression formatConditionRuleExpression = new FormatConditionRuleExpression();
                gridFormatRule1.Column = item;

                formatConditionRuleExpression.PredefinedName = "Red Fill, Red Text";
                string colError = "Error" + item.FieldName;
                formatConditionRuleExpression.Expression = $"[{colError}] >= 0";

                gridFormatRule1.Rule = formatConditionRuleExpression;
                gridData.FormatRules.Add(gridFormatRule1);

                // IconSet ===============================================================
                GridFormatRule gridFormatRule2 = new GridFormatRule();
                gridFormatRule2.Column = gridData.Columns[colError];
                gridFormatRule2.ColumnApplyTo = item;
                FormatConditionRuleIconSet formatConditionRuleIconSet = new FormatConditionRuleIconSet();
                FormatConditionIconSet iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet();
                FormatConditionIconSetIcon icon1 = new FormatConditionIconSetIcon();

                //Choose predefined icons.
                icon1.PredefinedName = "Symbols23_3.png";

                //Specify the type of threshold values.
                iconSet.ValueType = FormatConditionValueType.Number;

                //Define ranges to which icons are applied by setting threshold values.
                icon1.Value = 0;
                icon1.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;

                //Add icons to the icon set.
                iconSet.Icons.Add(icon1);

                //Specify the rule type.
                gridFormatRule2.Rule = formatConditionRuleIconSet;
                //Specify the column to which formatting is applied.

                //Add the formatting rule to the GridView.
                gridFormatRule2.Rule = formatConditionRuleIconSet;
                gridData.FormatRules.Add(gridFormatRule2);
            }
        }
        public void ValidateTable() {
            CreateListRule();

            DatatableValidator validator = new DatatableValidator(g_table, g_listRule);
            var result = validator.Validate(g_table, options => {
                options.IncludeRuleSets("Validate");
            });

            if (result.IsValid) {
                MessageBox.Show("Validate Succees", "THÔNG BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControlData.DataSource = g_table;
            }
            else {
                // danh sách những gridcolumn cần validate , dùng để hiển thị lỗi
                foreach (string item in g_listValidateColName) {
                    g_listValidateCol.Add(gridData.Columns[item]);
                }

                foreach (GridColumn item in g_listValidateCol) {
                    gridData.Columns.AddVisible("Error" + item.FieldName, "Error" + item.FieldName);
                    gridData.Columns["Error" + item.FieldName].Visible = false;
                    g_table.Columns.Add("Error" + item.FieldName, typeof(int));

                    //lưu vị trí và ErrorMessage để hiển thị lỗi lên gridview cell
                    g_dictError = result.Errors.Where(x => x.CustomState.ToString() == item.FieldName).GroupBy(ms => ms.PropertyName).Select(y => y.First())
                        .Select((element, index) => new { element.ErrorMessage, element.PropertyName })
                        .ToDictionary(ele => Convert.ToInt32(ele.PropertyName), ele => ele.ErrorMessage);

                    g_listDictError.Add(g_dictError);

                    foreach (var failure in g_dictError) {
                        DataRow dr = g_table.Rows[Convert.ToInt32(failure.Key)];
                        dr["Error" + item.FieldName] = Convert.ToInt32(failure.Key);
                    }

                }
                gridControlData.DataSource = g_table;

                FormatingRule();
            }
            // Display format numeric 
            foreach (GridColumn item in g_listValidateCol) {
                item.DisplayFormat.FormatType = FormatType.Numeric;
                item.DisplayFormat.FormatString = "###,###";
            }
        }
        #endregion

        #region Events
        private void FormBaoCaoLuuChuyenTienTeTongHop_Load(object sender, EventArgs e) {
            LoadFakeData();
            //CreateListRule();
            ValidateTable();
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e) {
            if (e.SelectedControl != gridControlData) return;
            if (e.Info == null && e.SelectedControl == gridControlData) {
                GridView view = gridControlData.FocusedView as GridView;
                if (view == null) return;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);

                foreach (Dictionary<int, string> dicItem in g_listDictError) {
                    if (dicItem.Keys.Contains(info.RowHandle)) {
                        if (info.InRowCell) {
                            foreach (KeyValuePair<int, string> item in dicItem) {
                                if (info.RowHandle == item.Key) {
                                    foreach (GridColumn column in g_listValidateCol) {
                                        if (info.Column == column) {
                                            if (!(gridData.GetRowCellValue(info.RowHandle, gridData.Columns["Error" + column.FieldName]) is DBNull)) {
                                                if (Convert.ToInt32(gridData.GetRowCellValue(info.RowHandle, gridData.Columns["Error" + column.FieldName])) >= 0) {
                                                    string text = item.Value;
                                                    string cellkey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                                                    e.Info = new ToolTipControlInfo(cellkey, text, ToolTipIconType.Error);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e) {
            gridData.OptionsBehavior.Editable = true;
            foreach (GridColumn col in gridData.Columns)
                col.OptionsColumn.AllowEdit = false;
            foreach (GridColumn col in g_listValidateCol)
                col.OptionsColumn.AllowEdit = true;
        }

        private void btnValidate_Click(object sender, EventArgs e) {
            gridData.OptionsBehavior.Editable = false;
            g_listValidateCol.Clear();
            g_listRule.Clear();
            foreach (string colName in g_listValidateColName) {
                if (gridData.Columns.Contains(gridData.Columns["Error" + colName])) {
                    gridData.Columns.Remove(gridData.Columns["Error" + colName]);
                    g_table.Columns.Remove("Error" + colName);
                }
            }
            ValidateTable();
        }
        #endregion
    }
}

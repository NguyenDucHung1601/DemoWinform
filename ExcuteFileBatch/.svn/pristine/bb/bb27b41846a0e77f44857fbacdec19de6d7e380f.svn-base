using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DemoFluentValidation {
    public partial class FormPhanTichSoLieuDeLoaiTruGDNoiBo : Form {
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
        public FormPhanTichSoLieuDeLoaiTruGDNoiBo() {
            InitializeComponent();
            gridData.OptionsBehavior.Editable = false;
            g_table.Clear();
            g_table.Columns.Add("STT", typeof(string));
            g_table.Columns.Add("ChiTieu", typeof(string));
            g_table.Columns.Add("MaSo", typeof(string));
            g_table.Columns.Add("TongSo", typeof(double));
            g_table.Columns.Add("TrongDonViKeToanTrungGian1", typeof(double));
            g_table.Columns.Add("TrongDonViKeToanTrungGian2", typeof(double));
            g_table.Columns.Add("TrongDonViDuToanCap1", typeof(double));
            g_table.Columns.Add("NgoaiDonViDuToanCap1TrongCungTinh", typeof(double));
            g_table.Columns.Add("NgoaiDonViDuToanCap1TrongLinhVucKeToanNhaNuoc", typeof(double));
            g_table.Columns.Add("NgoaiKhuVucNhaNuoc", typeof(double));
            g_table.Columns.Add("ThuyetMinh", typeof(string));

            g_listValidateColName.AddRange(new string[] { "TongSo", "TrongDonViKeToanTrungGian1", "TrongDonViKeToanTrungGian2", "TrongDonViDuToanCap1", "NgoaiDonViDuToanCap1TrongCungTinh", "NgoaiDonViDuToanCap1TrongLinhVucKeToanNhaNuoc", "NgoaiKhuVucNhaNuoc" });
        }
        #endregion

        #region Business
        private void LoadFakeData() {
            g_table.Rows.Add(new object[] { "A", "B", "C", 1, 2, 3, 4, 5, 6, 7, "" });
            g_table.Rows.Add(new object[] { "A", "Phân tích số liệu để lập báo cáo tình hình tài chính tổng hợp", "", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "I", "Khoản đầu tư tài chính vào đơn vị khác", "01", 7000000, 0, 0, 0, 0, 0, 0, "01 = 02 + 03" });
            g_table.Rows.Add(new object[] { "", "- Ngắn hạn", "02", 2000000, 0, 0, 0, 0, 0, 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Dài hạn", "03", 5000000, 0, 0, 0, 0, 0, 5000000, "" });
            g_table.Rows.Add(new object[] { "II", "Các khoản phải thu", "05", 30000000, 0, 0, 0, 0, 0, 0, "05 = 06 + 07 + 08" });
            g_table.Rows.Add(new object[] { "1", "Phải thu khách hàng", "06", 20000000, 0, 0, 0, 0, 0, 20000000, "" });
            g_table.Rows.Add(new object[] { "2", "Trả trước cho người bán", "07", 15000000, 0, 0, 0, 0, 0, 15000000, "" });
            g_table.Rows.Add(new object[] { "3", "Các khoản phải thu khác", "08", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "III", "Nợ phải trả", "10", 10000000, 0, 0, 0, 0, 0, 0, "10 = 11 + 12 + 18" });
            g_table.Rows.Add(new object[] { "1", "Phải trả nhà cung cấp", "11", 1500000, 0, 0, 0, 0, 0, 1500000, "" });
            g_table.Rows.Add(new object[] { "2", "Các khoản nhận trước của khách hàng", "12", 3200000, 0, 0, 0, 0, 0, 3200000, "" });
            g_table.Rows.Add(new object[] { "3", "Nợ phải trả khác", "18", 6200000, 0, 0, 0, 0, 0, 6200000, "" });
            g_table.Rows.Add(new object[] { "IV", "Nguồn vốn nhận đầu tư từ đơn vị khác", "20", 0, 0, 0, 0, 0, 0, 0, "20 = 21 + 22" });
            g_table.Rows.Add(new object[] { "", "- Ngắn hạn", "21", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "- Dài hạn", "22", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "B", "Phân tích số liệu để lập báo cáo kết quả hoạt động tổng hợp", "", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Doanh thu từ nguồn viện trợ, vay nợ nước ngoài", "50", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "2", "Doanh thu từ nguồn phí được khấu trừ, để lại", "51", 15000000, 0, 0, 0, 0, 0, 15000000, "" });
            g_table.Rows.Add(new object[] { "3", "Doanh thu hoạt động sản xuất, kinh doanh dịch vụ", "52", 205520000, 0, 0, 0, 0, 0, 205520000, "" });
            g_table.Rows.Add(new object[] { "4", "Thu nhập khác", "53", 237145000, 0, 0, 0, 0, 0, 237145000, "" });
            g_table.Rows.Add(new object[] { "5", "Chi phí hoạt động", "60", 1979607757, 0, 0, 0, 0, 0, 1979607757, "" });
            g_table.Rows.Add(new object[] { "6", "Chi phí từ nguồn viện trợ, vay nợ nước ngoài", "61", 100000000, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "7", "Chi phí hoạt động thu phí", "62", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "8", "Chi phí khác", "63", 237145000, 0, 0, 0, 0, 0, 237145000, "" });
            g_table.Rows.Add(new object[] { "C", "Phân tích số liệu để lập báo cáo lưu chuyển", "", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "2", "Tiền chỉ đầu tư góp vồn vào các đơn vị khác", "71", 0, 0, 0, 0, 0, 0, 0, "" });
            g_table.Rows.Add(new object[] { "3", "Tiền nhận vốn góp", "72", 0, 0, 0, 0, 0, 0, 0, "" });

            gridControlData.DataSource = g_table;
            gridData.OptionsView.ColumnAutoWidth = true;
            gridData.BestFitColumns();
        }

        public void CreateRule(string colValidate) {
            for (int i = 0; i < g_table.Rows.Count; i++) {
                if (!(g_table.Rows[i]["ThuyetMinh"].Equals(""))) {
                    string CompareExpress = "";
                    var strThuyetMinh = g_table.Rows[i]["ThuyetMinh"].ToString();
                    strThuyetMinh = Regex.Replace(strThuyetMinh, @"\s+", " ").Trim();
                    List<string> arrCode = strThuyetMinh.Split().ToList();
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
        private void FormValidate_Load(object sender, EventArgs e) {

            LoadFakeData();

            //CreateListRule();

            ValidateTable();
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e) {
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
                                    if (!(gridData.GetRowCellValue(info.RowHandle, gridData.Columns["Error" + info.Column.FieldName]) is DBNull)) {
                                        if (Convert.ToInt32(gridData.GetRowCellValue(info.RowHandle, gridData.Columns["Error" + info.Column.FieldName])) >= 0) {
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

        private void btnEdit_Click(object sender, EventArgs e) {
            gridData.OptionsBehavior.Editable = true;
            foreach (GridColumn col in gridData.Columns)
                col.OptionsColumn.AllowEdit = false;
            foreach (GridColumn col in g_listValidateCol)
                col.OptionsColumn.AllowEdit = true;
        }

        private void btnValdiate_Click(object sender, EventArgs e) {
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


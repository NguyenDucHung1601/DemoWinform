using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FluentValidation;
using FluentValidation.Results;
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
    public partial class FormBoSungThongTinThuyetMinhTaiChinh : Form {
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
        public FormBoSungThongTinThuyetMinhTaiChinh() {
            InitializeComponent();
            gridData.OptionsBehavior.Editable = false;
            g_table.Clear();
            g_table.Columns.Add("STT", typeof(string));
            g_table.Columns.Add("ChiTieu", typeof(string));
            g_table.Columns.Add("MaSo", typeof(string));
            g_table.Columns.Add("NamNay", typeof(double));
            g_table.Columns.Add("ThuyetMinh", typeof(string));

            g_listValidateColName.AddRange(new string[] { "NamNay" });
        }
        #endregion

        #region Business
        private void LoadFakeData() {
            g_table.Rows.Add(new object[] { "1", "Khấu hao TSCĐ", "01", 1897091757, "" });
            g_table.Rows.Add(new object[] { "1", "Thuyết minh tài sản khác", "02", 1897091757, "    02 = 03 + 04" });
            g_table.Rows.Add(new object[] { "1.1", "Tải sản ngắn hạn khác", "03", 10000000, "" });
            g_table.Rows.Add(new object[] { "1.2", "Tải sản dài hạn khác", "04", 15000000, "" });
            g_table.Rows.Add(new object[] { "2", "Thuyết minh nợ phải trả khác", "05", 1994607757, "     05 = 06 + 07" });
            g_table.Rows.Add(new object[] { "2.1", "Nợ phải trả ngắn hạn khác", "06", 1979607757, "" });
            g_table.Rows.Add(new object[] { "2.2", "Nợ phải trả dài hạn khác", "07", 5000000, "" });
            g_table.Rows.Add(new object[] { "3", "Thuyết minh chi tiết chỉ tiêu chi phí hoạt động theo nguồn", "08", 10000000, "    08 = 09 + 14" });
            g_table.Rows.Add(new object[] { "3.1", "Chi phí nguồn NSNN", "09", 97516000, "      09 = 10 + 11 + 12 + 13" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương và chi phí khác cho nhân viên", "10", 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "11", 82516000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí khấu hao/ hao mòn TSCĐ", "12", 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "13", 0, "" });
            g_table.Rows.Add(new object[] { "3.2", "Hoạt động tài chính", "14", 0, "    14 = 15 + 16 + 17 + 18" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương và chi phí khác cho nhân viên", "15", 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "16", 82516000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí khấu hao/ hao mòn TSCĐ", "17", 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "18", 0, "" });
            g_table.Rows.Add(new object[] { "4", "Thuyết minh chi tiết chỉ tiêu Chi phí từ nguồn vốn viện trợ, vay nợ nước ngoài", "19", 237145000, "   19 = 20 + 25" });
            g_table.Rows.Add(new object[] { "4.1", "Chi từ nguồn viện trợ", "20", 237145000, "   20 = 21 + 22 + 23 + 24" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương và chi phí khác cho nhân viên", "21", 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "22", 82516000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí khấu hao/ hao mòn TSCĐ", "23", 0,"" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "24", 0, "" });
            g_table.Rows.Add(new object[] { "4.2", "Chỉ vay nợ nước ngoài", "25", 0, "   25 = 26 + 27 + 28 + 29" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương và chi phí khác cho nhân viên", "26", 2000000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "27", 82516000, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí khấu hao/ hao mòn TSCĐ", "28", 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "29", 0, "" });
            g_table.Rows.Add(new object[] { "5", "Thuyết minh chi tiết chỉ tiêu Chi phí hoạt động sản xuất kinh doanh, dịch vụ", "30", 0, "   30 = 31 + 32 + 33 + 34" });
            g_table.Rows.Add(new object[] { "", "- Chi phí tiền lương và chi phí khác cho nhân viên", "31", 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí vật tư, công cụ và dịch vụ đã sử dụng", "32", 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí khấu hao/ hao mòn TSCĐ", "33", 0, "" });
            g_table.Rows.Add(new object[] { "", "- Chi phí hoạt động khác", "34", 0, "" });
            g_table.Rows.Add(new object[] { "6", "Thuyết minh chi tiết chỉ tiêu Tiền thu từ các khoản đầu tư (Báo cáo LCTT)", "35", 0, "    35 = 36 + 37" });
            g_table.Rows.Add(new object[] { "", "- Tiền thu gốc", "36", 0, "" });
            g_table.Rows.Add(new object[] { "", "- Tiền thu lãi", "37", 0, "" });

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
        //public void CreateListRule() {
        //    foreach (string item in g_listValidateColName) {
        //        g_listRule.Add(new RuleTable($"A.01.{item}", OPERATOR.EQUAL, $"A.02.{item} + A.03.{item} + A.04.{item}", g_table));
        //        g_listRule.Add(new RuleTable($"A.05.{item}", OPERATOR.EQUAL, $"A.06.{item} + A.07.{item} + A.08.{item}", g_table));
        //        g_listRule.Add(new RuleTable($"A.09.{item}", OPERATOR.EQUAL, $"A.01.{item} - A.04.{item}", g_table));
        //        g_listRule.Add(new RuleTable($"A.12.{item}", OPERATOR.EQUAL, $"A.10.{item} - A.11.{item}", g_table));
        //        g_listRule.Add(new RuleTable($"A.22.{item}", OPERATOR.EQUAL, $"A.20.{item} - A.21.{item}", g_table));
        //        g_listRule.Add(new RuleTable($"A.32.{item}", OPERATOR.EQUAL, $"A.30.{item} - A.31.{item}", g_table));
        //        g_listRule.Add(new RuleTable($"A.50.{item}", OPERATOR.EQUAL, $"A.09.{item} + A.12.{item} + A.22.{item} + A.32.{item} - A.40.{item}", g_table));
        //    }
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


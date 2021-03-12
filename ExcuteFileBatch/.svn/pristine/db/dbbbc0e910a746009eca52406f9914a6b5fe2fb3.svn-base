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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoFluentValidation {
    public partial class FormBaoCaoLuuChuyenTienTeTongHop : Form {
        #region Variable
        DataTable g_table = new DataTable();
        Dictionary<int, string> g_dictError = new Dictionary<int, string>();
        List<GridColumn> g_listValidateCol = new List<GridColumn>();
        List<RuleTable> g_listRule = new List<RuleTable>();
        List<Dictionary<int, string>> g_listDictError = new List<Dictionary<int, string>>();
        List<string> g_listValidateColName = new List<string>();
        #endregion

        #region Constructor
        public FormBaoCaoLuuChuyenTienTeTongHop() {
            InitializeComponent();
            gridData.OptionsBehavior.Editable = false;
            g_table.Clear();
            g_table.Columns.Add("STT", typeof(string));
            g_table.Columns.Add("ChiTieu", typeof(string));
            g_table.Columns.Add("MaSo", typeof(string));
            g_table.Columns.Add("NamNay", typeof(double));
            g_table.Columns.Add("NamTruoc", typeof(double));
            g_table.Columns.Add("ThuyetMinh", typeof(string));

            g_listValidateColName.AddRange(new string[] { "NamNay", "NamTruoc" });
        }
        #endregion

        #region Business
        private void LoadFakeData() {
            g_table.Rows.Add(new object[] { "A", "B", "C", 1, 2, "" });
            g_table.Rows.Add(new object[] { "I", "LƯU CHUYỂN TIỀN TỪ HOẠT ĐỘNG CHÍNH", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "Thặng dư/ thâm hụt năm", "01", 10000000, 0, "" });
            g_table.Rows.Add(new object[] { "", "Điều chỉnh cho các khoản", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Khấu hao TSCĐ trong năm", "02", 136127757, 136127757, "" });
            g_table.Rows.Add(new object[] { "2", "Tăng/ giảm các khoản nợ phải trả", "03", 138946757, 138946757, "" });
            g_table.Rows.Add(new object[] { "3", "Tăng/ giảm hàng tồn kho", "04", 5000000, 5000000, "   04 >= 0" });
            g_table.Rows.Add(new object[] { "4", "Tăng/ giảm các khoản phải thu", "05", 20000000, 20000000, "" });
            g_table.Rows.Add(new object[] { "5", "Thu khác từ hoạt động chính", "06", 3000000, 3000000, "     06 >= 0" });
            g_table.Rows.Add(new object[] { "6", "Chi khác từ hoạt động chính", "07", 2000000, 2000000, "" });
            g_table.Rows.Add(new object[] { "", "Lưu chuyển tiền thuần hoạt động chính", "10", 17181000, 13181000, "     10 = 02 + 03 + 04 + 05 + 06 + 07 + 01" });
            g_table.Rows.Add(new object[] { "II", "LƯU CHUYỂN TIỀN TỪ HOẠT ĐỘNG ĐẦU TƯ", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Tiền thu từ thanh lý tài sản cố định", "21", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "2", "Tiền thu từ các khoản đầu tư", "22", 2000000, 2000000, "" });
            g_table.Rows.Add(new object[] { "3", "Tiền chi XDCB, mua tài sản cố định", "23", 20000000, 20000000, "      23 <= 0" });
            g_table.Rows.Add(new object[] { "4", "Tiền chi đầu tư góp vốn vào các đơn vị khác", "24", 500000, 500000, "     24 <= 0" });
            g_table.Rows.Add(new object[] { "", "Lưu chuyển tiền thuần từ hoạt động đầu tư", "30", 13500000, 12500000, "     30 = 21 + 22 + 23 + 24" });
            g_table.Rows.Add(new object[] { "III", "LƯU CHUYỂN TIỀN TỪ HOẠT ĐỘNG TÀI CHÍNH", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Tiền thu từ các khoản đi vay", "31", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "2", "Tiền nhận góp vốn", "32", 2000000, 2000000, "" });
            g_table.Rows.Add(new object[] { "3", "Tiền hoàn trả gốc vay", "33", 2000000, 2000000, "     33 <= 0" });
            g_table.Rows.Add(new object[] { "4", "Tiền hoàn trả góp vốn", "34", 4000000, 4000000, "     34 <= 0" });
            g_table.Rows.Add(new object[] { "5", "Tiền cổ tức/ lợi nhuận đã trả cho chủ sở hữu", "35", 1000000, 1000000, "     35 <= 0" });
            g_table.Rows.Add(new object[] { "", "Lưu chuyển tiền thuần từ hoạt động tài chính", "40", 0, 1000000, "     40 = 31 + 32 + 33 + 34 + 35" });
            g_table.Rows.Add(new object[] { "IV", "Lưu chuyển tiền thuần trong năm", "50", 0, 3681000, "     50 = 10 + 30 + 40" });
            g_table.Rows.Add(new object[] { "V", "Số dư tiền đầu năm", "60", 0, 5420509, "     60(Năm Nay) = 80(Năm Trước)" });
            g_table.Rows.Add(new object[] { "VI", "Ảnh hưởng của chênh lệch tỷ giá", "70", 0, 0, "" });
            g_table.Rows.Add(new object[] { "VII", "Số dư tiền cuối năm", "80", 9101509, 4420509, "     80(Năm Trước) = 60(Năm Nay)   &   80 = 50 + 60 + 70" });

            gridControlData.DataSource = g_table;
            //gridData.OptionsView.ColumnAutoWidth = true;
            gridData.BestFitColumns();
        }
        public void CreateListRule() {
            foreach (string item in g_listValidateColName) {

                g_listRule.Add(new RuleTable($"A.04.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));

                g_listRule.Add(new RuleTable($"A.06.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));

                g_listRule.Add(new RuleTable($"A.10.{item}", OPERATOR.EQUAL, $"A.02.{item} + A.03.{item} + A.04.{item} + A.05.{item} + A.06.{item}  + A.07.{item} + A.01.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.23.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

                g_listRule.Add(new RuleTable($"A.24.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

                g_listRule.Add(new RuleTable($"A.30.{item}", OPERATOR.EQUAL, $"A.21.{item} + A.22.{item} + A.23.{item} + A.24.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.33.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

                g_listRule.Add(new RuleTable($"A.34.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

                g_listRule.Add(new RuleTable($"A.35.{item}", OPERATOR.LESS_THAN_OR_EQUAL, 0, g_table));

                g_listRule.Add(new RuleTable($"A.40.{item}", OPERATOR.EQUAL, $"A.31.{item} + A.32.{item} + A.33.{item} + A.34.{item} + A.35.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.50.{item}", OPERATOR.EQUAL, $"A.10.{item} + A.30.{item} + A.40.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.80.{item}", OPERATOR.EQUAL, $"A.50.{item} + A.60.{item} + A.70.{item}", g_table));
            }

            g_listRule.Add(new RuleTable($"A.60.{g_listValidateColName[0]}", OPERATOR.EQUAL, $"A.80.{g_listValidateColName[1]}", g_table));

            g_listRule.Add(new RuleTable($"A.80.{g_listValidateColName[1]}", OPERATOR.EQUAL, $"A.60.{g_listValidateColName[0]}", g_table));
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

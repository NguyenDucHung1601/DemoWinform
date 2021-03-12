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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoFluentValidation {
    public partial class FormBaoCaoKetQuaHoatDongTongHop : Form {
        #region Variable
        DataTable g_table = new DataTable();
        Dictionary<int, string> g_dictError = new Dictionary<int, string>();
        List<GridColumn> g_listValidateCol = new List<GridColumn>();
        List<RuleTable> g_listRule = new List<RuleTable>();
        List<Dictionary<int, string>> g_listDictError = new List<Dictionary<int, string>>();
        List<string> g_listValidateColName = new List<string>();

        #endregion

        #region Constructor
        public FormBaoCaoKetQuaHoatDongTongHop() {
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
            g_table.Rows.Add(new object[] { "I", "Hoạt động hành chính, sự nghiệp", "", 0, 0, ""});
            g_table.Rows.Add(new object[] { "1", "Doanh thu", "01", 1897091757, 1922091757, "     01 = 02 + 03 + 04" });
            g_table.Rows.Add(new object[] { "", "a. Từ NSNN", "02", 1897091757, 1897091757, "" });
            g_table.Rows.Add(new object[] { "", "b. Từ nguồn viện trợ, vay nợ nước ngoài", "03", 10000000, 10000000, "" });
            g_table.Rows.Add(new object[] { "", "c. Từ nguồn phí được khấu trừ, để lại", "04", 15000000, 15000000, "" });
            g_table.Rows.Add(new object[] { "2", "Chi phí", "05", 1994607757, 1994607757, "     05 = 06 + 07 + 08" });
            g_table.Rows.Add(new object[] { "", "a. Chi phí hoạt động", "06", 1979607757, 1979607757, "" });
            g_table.Rows.Add(new object[] { "", "b. Chi phí từ nguồn viện trợ, vay nợ nước ngoài", "07", 5000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "", "c. Chi phí hoạt động thu phí", "08", 10000000, 10000000, "" });
            g_table.Rows.Add(new object[] { "3", "Thặng dư/ thâm hụt", "09", 97516000, 82516000, "      09 = 01 - 05" });
            g_table.Rows.Add(new object[] { "II", "Hoạt động sản xuất kinh doanh, dịch vụ", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Doanh thu", "10", 205520000, 205520000, "" });
            g_table.Rows.Add(new object[] { "2", "Chi phí", "11", 123004000, 123004000, "" });
            g_table.Rows.Add(new object[] { "3", "Thặng dư/ thâm hụt", "12", 82516000, 82516000, "12 = 10 - 11" });
            g_table.Rows.Add(new object[] { "III", "Hoạt động tài chính", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Doanh thu", "20", 40000000, 40000000, "" });
            g_table.Rows.Add(new object[] { "2", "Chi phí", "21", 30000000, 30000000, "" });
            g_table.Rows.Add(new object[] { "3", "Thặng dư/ thâm hụt", "22", 5000000, 10000000, "    22 = 20 - 21" });
            g_table.Rows.Add(new object[] { "IV", "Hoạt động khác", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "1", "Thu nhập khác", "30", 237145000, 237145000, "" });
            g_table.Rows.Add(new object[] { "2", "Chi phí khác", "31", 237145000, 237145000, "" });
            g_table.Rows.Add(new object[] { "3", "Thặng dư/ thâm hụt", "32", 0, 0, "    32 = 30 - 31" });
            g_table.Rows.Add(new object[] { "V", "Chi phí thuế TNDN", "40", 0, 0, "" });
            g_table.Rows.Add(new object[] { "VI", "Thặng dư/ thâm hụt trong năm của đơn vị thực hiện CĐKT", "45", 0, 0, "" });
            g_table.Rows.Add(new object[] { "VII", "Thặng dư/ thâm hụt trong năm", "50", 2601509, 0, "      50 = 9 + 12 + 22 + 32 - 40 + 45" });
            g_table.Rows.Add(new object[] { "1", "Sử dụng kinh phí tiết kiệm của đơn vị hành chính", "51", 0, 0, "" });
            g_table.Rows.Add(new object[] { "2", "Phân phối cho các quỹ", "52", 2000000, 5000000, "" });
            g_table.Rows.Add(new object[] { "3", "Kinh phí cải cách tiền lương", "53", 82516000, 58000000, "" });
            g_table.Rows.Add(new object[] { "4", "Phân phối khác", "54", 0, 0, "" });

            gridControlData.DataSource = g_table;
            gridData.OptionsView.ColumnAutoWidth = true;
            gridData.BestFitColumns();
        }
        public void CreateListRule() {
            foreach (string item in g_listValidateColName) {
                g_listRule.Add(new RuleTable($"A.01.{item}", OPERATOR.EQUAL, $"A.02.{item} + A.03.{item} + A.04.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.05.{item}", OPERATOR.EQUAL, $"A.06.{item} + A.07.{item} + A.08.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.09.{item}", OPERATOR.EQUAL, $"A.01.{item} - A.05.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.12.{item}", OPERATOR.EQUAL, $"A.10.{item} - A.11.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.22.{item}", OPERATOR.EQUAL, $"A.20.{item} - A.21.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.32.{item}", OPERATOR.EQUAL, $"A.30.{item} - A.31.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.50.{item}", OPERATOR.EQUAL, $"A.09.{item} + A.12.{item} + A.22.{item} + A.32.{item} - A.40.{item} + A.45.{item}", g_table));
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


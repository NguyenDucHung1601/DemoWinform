using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FluentValidation;
using FluentValidation.Results;
using org.mariuszgromada.math.mxparser;
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
    public partial class FormBaoCaoTaiChinhTongHop : Form {
        #region Variable
        DataTable g_table = new DataTable();
        Dictionary<int, string> g_dictError = new Dictionary<int, string>();
        List<GridColumn> g_listValidateCol = new List<GridColumn>();
        List<RuleTable> g_listRule = new List<RuleTable>();
        List<Dictionary<int, string>> g_listDictError = new List<Dictionary<int, string>>();
        List<string> g_listValidateColName = new List<string>();
        #endregion

        #region Constructor
        public FormBaoCaoTaiChinhTongHop() {
            InitializeComponent();
            gridData.OptionsBehavior.Editable = false;
            g_table.Clear();
            g_table.Columns.Add("STT", typeof(string));
            g_table.Columns.Add("ChiTieu", typeof(string));
            g_table.Columns.Add("MaSo", typeof(string));
            g_table.Columns.Add("SoDauNam", typeof(double));
            g_table.Columns.Add("SoCuoiNam", typeof(double));
            g_table.Columns.Add("ThuyetMinh", typeof(string));

            g_listValidateColName.AddRange(new string[] { "SoDauNam", "SoCuoiNam" });
        }
        #endregion

        #region Business
        private void LoadFakeData() {
            g_table.Rows.Add(new object[] { "", "TÀI SẢN", "", null, null, "" });
            g_table.Rows.Add(new object[] { "I", "Tiền", "01", 2601509, 5000000, "     1 >= 0" });
            g_table.Rows.Add(new object[] { "II", "Đầu tư tài chính ngắn hạn", "05", 0, 0, "" });
            g_table.Rows.Add(new object[] { "III", "Các khoản phải thu", "10", 2000000, 4700000, "     10 = 11 + 12 + 14" });
            g_table.Rows.Add(new object[] { "1", "Phải thu khách hàng", "11", 3000000, 3000000, "" });
            g_table.Rows.Add(new object[] { "2", "Trả trước cho người bán", "12", 1500000, 1500000, "" });
            g_table.Rows.Add(new object[] { "3", "Các khoản phải thu khác", "14", 200000, 200000, "" });
            g_table.Rows.Add(new object[] { "IV", "Hàng tồn kho", "20", 500000, 0, "     20 >= 0" });
            g_table.Rows.Add(new object[] { "V", "Đầu tư tài chính dài hạn", "25", 0, 0, "" });
            g_table.Rows.Add(new object[] { "VI", "Tài sản cố định trang bị cho đơn vị", "30", 3319371588, 3319371588, "     30 = 31 + 33" });
            g_table.Rows.Add(new object[] { "1", "Tài sản cố định hữu hình", "31", 297931588, 297931588, "     31 = 32 + 33" });
            g_table.Rows.Add(new object[] { "", "- Nguyên giá", "32", 2235937000, 2235937000, "" });
            g_table.Rows.Add(new object[] { "", "- Khấu hao và hao mòn lũy kế", "33", 1938005412, 1938005412, "     33 <= 0" });
            g_table.Rows.Add(new object[] { "2", "Tài sản cố định vô hình", "35", 3021440000, 3021440000, "     35 = 36 + 37" });
            g_table.Rows.Add(new object[] { "", "- Nguyên giá", "36", 3027820000, 3027820000, "" });
            g_table.Rows.Add(new object[] { "", "- Khấu hao và hao mòn lũy kế", "37", 6380000, 6380000, "     37 <= 0" });
            g_table.Rows.Add(new object[] { "VII", "Xây dựng cơ bản dở dang", "40", 0, 0, "" });
            g_table.Rows.Add(new object[] { "VIII", "Tài sản khác", "45", 0, 0, "" });
            g_table.Rows.Add(new object[] { "IX", "Tài sản thuần của đơn vị thực hiện CĐKT khác", "46", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "TỔNG CỘNG TÀI SẢN", "50", 3323473097, 0, "     50 = 80     &     50 = 01 + 05 + 10 + 20 + 25 + 30 + 40 + 45 + 46" });
            g_table.Rows.Add(new object[] { "", "NGUỒN VỐN", "", 0, 0, "" });
            g_table.Rows.Add(new object[] { "I", "Nợ phải trả", "60", 3321973097, 0, "     60 = 61 + 62 + 64 + 65 + 66 + 67 + 68" });
            g_table.Rows.Add(new object[] { "1", "Phải trả nhà cung cấp", "61", 200000, 0, "" });
            g_table.Rows.Add(new object[] { "2", "Các khoản nhận trước của khách hàng", "62", 15000000, 0, "" });
            g_table.Rows.Add(new object[] { "3", "Phải trả nợ vay", "64", 300000000, 0, "" });
            g_table.Rows.Add(new object[] { "4", "Tạm thu", "65", 2601509, 0, "" });
            g_table.Rows.Add(new object[] { "5", "Các quỹ đặc thù", "66", 0, 0, "" });
            g_table.Rows.Add(new object[] { "6", "Các khoản nhận trước chưa ghi thu", "67", 3319371588, 0, "" });
            g_table.Rows.Add(new object[] { "7", "Nợ phải trả khác", "68", 0, 0, "" });
            g_table.Rows.Add(new object[] { "II", "Tài sản thuần", "70", 26500000, 25000000, "     70 = 71 + 72 + 73 + 74 + 75" });
            g_table.Rows.Add(new object[] { "1", "Nguồn vốn kinh doanh", "71", 20000000, 20000000, "" });
            g_table.Rows.Add(new object[] { "2", "Thặng dư/ thâm hụt kinh tế", "72", 2500000, 2500000, "" });
            g_table.Rows.Add(new object[] { "3", "Các quỹ", "73", 4000000, 4000000, "" });
            g_table.Rows.Add(new object[] { "4", "Tài sản thuần khác", "74", 0, 0, "" });
            g_table.Rows.Add(new object[] { "5", "Tài sản thuần của đơn vị thực hiện CĐKT khác", "75", 0, 0, "" });
            g_table.Rows.Add(new object[] { "", "TỔNG CỘNG NGUỒN VỐN", "80", 3348473097, 0, "     80 = 50     &     80 = 60 + 70" });

            gridControlData.DataSource = g_table;
            //gridData.OptionsView.ColumnAutoWidth = true;
            gridData.BestFitColumns();
        }
        public void CreateListRule() {
            g_listRule = DataProvider.GetListRule("B01/BCTC-TH", g_table);
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


using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace DemoFluentValidation {
    public partial class FormValidate : Form {
        public FormValidate() {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Dictionary<int, string> diction = new Dictionary<int, string>();
        List<GridColumn> lstColumnValidate = new List<GridColumn>();

        private void FormValidate_Load(object sender, EventArgs e) {
            gridData.OptionsBehavior.Editable = false;
            dt.Clear();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("ChiTieu", typeof(string));
            dt.Columns.Add("MaSo", typeof(int));
            dt.Columns.Add("SoCuoiNam", typeof(int));
            dt.Rows.Add(new object[] { 1, "Các khoản phải thu", 10, 160 });
            dt.Rows.Add(new object[] { 2, "Phải thu khách hàng", 11, 50 });
            dt.Rows.Add(new object[] { 3, "Trả trước cho người bán", 12, 50 });
            dt.Rows.Add(new object[] { 4, "Các khoản phải thu khác", 14, 50 });
            dt.Rows.Add(new object[] { 5, "Tài sản cố định hữu hình", 31, 100 });
            dt.Rows.Add(new object[] { 6, "Nguyên giá", 32, 100 });
            dt.Rows.Add(new object[] { 7, "khấu hao và hao mòn lũy kế", 33, 10 });
            dt.Rows.Add(new object[] { 8, "Tài sản cố định vô hình", 35, 100 });
            dt.Rows.Add(new object[] { 9, "Nguyên giá", 36, 150 });
            dt.Rows.Add(new object[] { 10, "Khấu hao và hao mòn lũy kế", 37, -50 });
            dt.Rows.Add(new object[] { 11, "Tổng cộng tài sản", 50, 50 });
            dt.Rows.Add(new object[] { 12, "Nợ phải trả", 60, 250 });
            dt.Rows.Add(new object[] { 13, "Phải trả nhà cung cấp", 61, 50 });
            dt.Rows.Add(new object[] { 14, "Các khoản nhận trước của khách hàng", 62, 50 });
            dt.Rows.Add(new object[] { 15, "Phải trả nợ vay", 64, 50 });
            dt.Rows.Add(new object[] { 16, "Tạm thu", 65, 50 });
            dt.Rows.Add(new object[] { 17, "Các quỹ đặc thù", 66, 50 });
            dt.Rows.Add(new object[] { 18, "Tổng cộng nguồn vốn", 80, 50 });



            //DatatableValidator validator = new DatatableValidator();
            //var result = validator.Validate(dt, options => {
            //    options.IncludeRuleSets("SoCuoiNamValidate");
            //    // đưa vào thuộc tính cụ thể của đối tượng cần validate
            //    options.IncludeProperties(x => x.Columns).Equals("SoCuoiNam");
            //});

            ValidationResult result = TableValdiation.Validate(dt, CreateRuleSet());


            if (result.IsValid) {
                MessageBox.Show("Validate Succees", "THÔNG BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControlData.DataSource = dt;
            }
            else {
                dt.Columns.Add("ErrorMessage", typeof(int));
                //lưu vị trí và ErrorMessage để hiển thị lỗi lên gridview cell
                diction = result.Errors.Select((element, index) => new { element.ErrorMessage, element.PropertyName })
                    .ToDictionary(ele => Convert.ToInt32(ele.PropertyName), ele => ele.ErrorMessage);

                foreach (var failure in result.Errors) {
                    DataRow dr = dt.Rows[Convert.ToInt32(failure.PropertyName)];
                    dr["ErrorMessage"] = Convert.ToInt32(failure.PropertyName);
                }
                gridControlData.DataSource = dt;
            }
            // danh sách những gridcolumn cần validate
            lstColumnValidate.Add(gridData.Columns["SoCuoiNam"]);
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e) {
            if (e.SelectedControl != gridControlData) return;
            if (e.Info == null && e.SelectedControl == gridControlData) {
                GridView view = gridControlData.FocusedView as GridView;
                if (view == null) return;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                if (diction.Keys.Contains(info.RowHandle)) {
                    if (info.InRowCell) {
                        foreach (KeyValuePair<int, string> item in diction) {
                            if (info.RowHandle == item.Key) {
                                foreach (GridColumn column in lstColumnValidate) {
                                    if (info.Column == column) {
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

        public List<RuleTable> CreateRuleSet() {
            string validateCol = "SoCuoiNam";
            List<RuleTable> listRule = new List<RuleTable>();

            // rule 1
            DtCell cell = RuleTable.DtCell("10", validateCol);
            double valueCell = RuleTable.CellValue(dt, cell);
            OPERATOR voperator = OPERATOR.EQUAL;
            double compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("11", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("12", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("14", validateCol))
            });
            string message = "10 = 11 + 12 +14";


            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message));

            // rule 2
            cell = RuleTable.DtCell("31", validateCol);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("32", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("33", validateCol)),
            });
            message = "31 = 32 + 33";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message));

            // rule 3
            cell = RuleTable.DtCell("33", validateCol);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.LESS_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "33 <= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message));

            // rule 4
            cell = RuleTable.DtCell("35", validateCol);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("36", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("37", validateCol)),
            });
            message = "35 = 36 + 37";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message));

            // rule 5
            cell = RuleTable.DtCell("37", validateCol);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.LESS_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "37 <= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message));

            // rule 6
            cell = RuleTable.DtCell("50", validateCol);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.CellValue(dt, RuleTable.DtCell("80", validateCol));
            message = "50 = 80";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message));

            // rule 7
            cell = RuleTable.DtCell("60", validateCol);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("61", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("62", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("64", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("65", validateCol)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("66", validateCol)),
            });
            message = "60 = 61 + 62 + 64 + 65 + 66";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message));


            return listRule;
        }
    }
}

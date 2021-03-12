using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FluentValidation.Results;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace DemoFluentValidation {
    public partial class FormValidate_1_table : Form {

        #region Variable
        DataTable dt = new DataTable();
        Dictionary<double, string> diction1 = new Dictionary<double, string>();
        Dictionary<double, string> diction2 = new Dictionary<double, string>();
        List<GridColumn> lstColumnValidate = new List<GridColumn>();
        #endregion

        #region Constructor
        public FormValidate_1_table() {
            InitializeComponent();
        }
        #endregion

        #region Bussiness
        private void LoadFakeData() {
            dt.Rows.Add(new object[] { "", "TÀI SẢN", "", null, null, "" });
            dt.Rows.Add(new object[] { "I", "Tiền", "01", 2601509, 5000000, "     1 >= 0" });
            dt.Rows.Add(new object[] { "II", "Đầu tư tài chính ngắn hạn", "05", 0, 0, "" });
            dt.Rows.Add(new object[] { "III", "Các khoản phải thu", "10", 2000000, 4700000, "     10 = 11 + 12 + 14" });
            dt.Rows.Add(new object[] { "1", "Phải thu khách hàng", "11", 3000000, 3000000, "" });
            dt.Rows.Add(new object[] { "2", "Trả trước cho người bán", "12", 1500000, 1500000, "" });
            dt.Rows.Add(new object[] { "3", "Các khoản phải thu khác", "14", 200000, 200000, "" });
            dt.Rows.Add(new object[] { "IV", "Hàng tồn kho", "20", 500000, 0, "     20 >= 0" });
            dt.Rows.Add(new object[] { "V", "Đầu tư tài chính dài hạn", "25", 0, 0, "" });
            dt.Rows.Add(new object[] { "VI", "Tài sản cố định trang bị cho đơn vị", "30", 3319371588, 3319371588, "     30 = 31 + 35" });
            dt.Rows.Add(new object[] { "1", "Tài sản cố định hữu hình", "31", 297931588, 297931588, "     31 = 32 + 33" });
            dt.Rows.Add(new object[] { "", "- Nguyên giá", "32", 2235937000, 2235937000, "" });
            dt.Rows.Add(new object[] { "", "- Khấu hao và hao mòn lũy kế", "33", 1938005412, 1938005412, "     33 <= 0" });
            dt.Rows.Add(new object[] { "2", "Tài sản cố định vô hình", "35", 3021440000, 3021440000, "     35 = 36 + 37" });
            dt.Rows.Add(new object[] { "", "- Nguyên giá", "36", 3027820000, 3027820000, "" });
            dt.Rows.Add(new object[] { "", "- Khấu hao và hao mòn lũy kế", "37", 6380000, 6380000, "     37 <= 0" });
            dt.Rows.Add(new object[] { "VII", "Xây dựng cơ bản dở dang", "40", 0, 0, "" });
            dt.Rows.Add(new object[] { "VIII", "Tài sản khác", "45", 0, 0, "" });
            dt.Rows.Add(new object[] { "IX", "Tài sản thuần của đơn vị thực hiện CĐKT khác", "46", 0, 0, "" });
            dt.Rows.Add(new object[] { "", "TỔNG CỘNG TÀI SẢN", "50", 3323473097, 0, "     50 = 80     &     50 = 01 + 05 + 10 + 20 + 25 + 30 + 40 + 45 + 46" });
            dt.Rows.Add(new object[] { "", "NGUỒN VỐN", "", 0, 0, "" });
            dt.Rows.Add(new object[] { "I", "Nợ phải trả", "60", 3321973097, 0, "     60 = 61 + 62 + 64 + 65 + 66 + 67 + 68" }); ;
            dt.Rows.Add(new object[] { "1", "Phải trả nhà cung cấp", "61", 200000, 0, "" });
            dt.Rows.Add(new object[] { "2", "Các khoản nhận trước của khách hàng", "62", 15000000, 0, "" });
            dt.Rows.Add(new object[] { "3", "Phải trả nợ vay", "64", 300000000, 0, "" });
            dt.Rows.Add(new object[] { "4", "Tạm thu", "65", 2601509, 0, "" });
            dt.Rows.Add(new object[] { "5", "Các quỹ đặc thù", "66", 0, 0, "" });
            dt.Rows.Add(new object[] { "6", "Các khoản nhận trước chưa ghi thu", "67", 3319371588, 0, "" });
            dt.Rows.Add(new object[] { "7", "Nợ phải trả khác", "68", 0, 0, "" });
            dt.Rows.Add(new object[] { "II", "Tài sản thuần", "70", 26500000, 25000000, "     70 = 71 + 72 + 73 + 74 + 75" });
            dt.Rows.Add(new object[] { "1", "Nguồn vốn kinh doanh", "71", 20000000, 20000000, "" });
            dt.Rows.Add(new object[] { "2", "Thặng dư/ thâm hụt kinh tế", "72", 2500000, 2500000, "" });
            dt.Rows.Add(new object[] { "3", "Các quỹ", "73", 4000000, 4000000, "" });
            dt.Rows.Add(new object[] { "4", "Tài sản thuần khác", "74", 0, 0, "" });
            dt.Rows.Add(new object[] { "5", "Tài sản thuần của đơn vị thực hiện CĐKT khác", "75", 0, 0, "" });
            dt.Rows.Add(new object[] { "", "TỔNG CỘNG NGUỒN VỐN", "80", 3348473097, 0, "     80 = 50     &     80 = 60 + 70" });

            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
        }

        public List<RuleTable> CreateRuleSet() {
            string validateCol1 = "SoDauNam";
            string validateCol2 = "SoCuoiNam";
            List<RuleTable> listRule = new List<RuleTable>();

            // Rule for column "SoDauNam"
            // rule 1
            DtCell cell = RuleTable.DtCell("01", validateCol1);
            double valueCell = RuleTable.CellValue(dt, cell);
            OPERATOR voperator = OPERATOR.GREAT_THAN_OR_EQUAL;
            double compareExpression = 0;
            List<double> multiCompareExpression;
            string message = "01 >= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 2
            cell = RuleTable.DtCell("10", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("11", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("12", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("14", validateCol1)),
            });
            message = "10 = 11 + 12 + 14";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 3
            cell = RuleTable.DtCell("20", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.GREAT_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "20 >= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 4
            cell = RuleTable.DtCell("30", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("31", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("35", validateCol1)),
            });
            message = "30 = 31 + 35";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 5
            cell = RuleTable.DtCell("31", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("32", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("33", validateCol1)),
            });
            message = "31 = 32 + 33";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 6
            cell = RuleTable.DtCell("33", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.LESS_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "33 <= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 7
            cell = RuleTable.DtCell("35", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("36", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("37", validateCol1)),
            });
            message = "35 = 36 + 37";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 8
            cell = RuleTable.DtCell("37", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.LESS_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "37 <= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 9
            cell = RuleTable.DtCell("50", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.MULTI_EQUAL;
            multiCompareExpression = new List<double>() {
                RuleTable.CellValue(dt, RuleTable.DtCell("80", validateCol1)),
                RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("01", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("05", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("10", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("20", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("25", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("30", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("40", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("45", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("46", validateCol1))
                })
            };
            message = "50 = 80   &   50 = 01 + 05 + 10 + 20 + 25 + 30 + 40 + 45 + 46";
            listRule.Add(new RuleTable(dt, cell, voperator, multiCompareExpression, message, 1));

            // rule 10
            cell = RuleTable.DtCell("60", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("61", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("62", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("64", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("65", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("66", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("67", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("68", validateCol1))
            });
            message = "60 = 61 + 62 + 64 + 65 + 66 + 67 + 68";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 11
            cell = RuleTable.DtCell("70", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("71", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("72", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("73", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("74", validateCol1)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("75", validateCol1)),
            });
            message = "70 = 71 + 72 + 73 + 74 + 75";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 1));

            // rule 12
            cell = RuleTable.DtCell("80", validateCol1);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.MULTI_EQUAL;
            multiCompareExpression = new List<double>() {
                RuleTable.CellValue(dt, RuleTable.DtCell("50", validateCol1)),
                RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("60", validateCol1)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("70", validateCol1))
                })
            };
            message = "80 = 50   &   80 = 60 + 70";
            listRule.Add(new RuleTable(dt, cell, voperator, multiCompareExpression, message, 1));


            // Rule for column "SoCuoiNam"
            // rule 1
            cell = RuleTable.DtCell("01", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.GREAT_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "01 >= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 2
            cell = RuleTable.DtCell("10", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("11", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("12", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("14", validateCol2)),
            });
            message = "10 = 11 + 12 + 14";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 3
            cell = RuleTable.DtCell("20", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.GREAT_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "20 >= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 4
            cell = RuleTable.DtCell("30", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("31", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("35", validateCol2)),
            });
            message = "30 = 31 + 35";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 5
            cell = RuleTable.DtCell("31", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("32", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("33", validateCol2)),
            });
            message = "31 = 32 + 33";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 6
            cell = RuleTable.DtCell("33", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.LESS_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "33 <= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 7
            cell = RuleTable.DtCell("35", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("36", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("37", validateCol2)),
            });
            message = "35 = 36 + 37";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 8
            cell = RuleTable.DtCell("37", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.LESS_THAN_OR_EQUAL;
            compareExpression = 0;
            message = "37 <= 0";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 9
            cell = RuleTable.DtCell("50", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.MULTI_EQUAL;
            multiCompareExpression = new List<double>() {
                RuleTable.CellValue(dt, RuleTable.DtCell("80", validateCol2)),
                RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("01", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("05", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("10", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("20", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("25", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("30", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("40", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("45", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("46", validateCol2))
                })
            };
            message = "50 = 80   &   50 = 01 + 05 + 10 + 20 + 25 + 30 + 40 + 45 + 46";
            listRule.Add(new RuleTable(dt, cell, voperator, multiCompareExpression, message, 2));

            // rule 10
            cell = RuleTable.DtCell("60", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("61", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("62", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("64", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("65", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("66", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("67", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("68", validateCol2))
            });
            message = "60 = 61 + 62 + 64 + 65 + 66 + 67 + 68";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 11
            cell = RuleTable.DtCell("70", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.EQUAL;
            compareExpression = RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                RuleTable.ExpressionItem(1, RuleTable.DtCell("71", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("72", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("73", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("74", validateCol2)),
                RuleTable.ExpressionItem(1, RuleTable.DtCell("75", validateCol2)),
            });
            message = "70 = 71 + 72 + 73 + 74 + 75";
            listRule.Add(new RuleTable(dt, cell, voperator, compareExpression, message, 2));

            // rule 12
            cell = RuleTable.DtCell("80", validateCol2);
            valueCell = RuleTable.CellValue(dt, cell);
            voperator = OPERATOR.MULTI_EQUAL;
            multiCompareExpression = new List<double>() {
                RuleTable.CellValue(dt, RuleTable.DtCell("50", validateCol2)),
                RuleTable.ToCompareExrpession(dt, new List<ExpressionItem>() {
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("60", validateCol2)),
                    RuleTable.ExpressionItem(1, RuleTable.DtCell("70", validateCol2))
                })
            };
            message = "80 = 50   &   80 = 60 + 70";
            listRule.Add(new RuleTable(dt, cell, voperator, multiCompareExpression, message, 2));


            return listRule;
        }
        #endregion

        #region Event
        private void FormValidate_1_table_Load(object sender, EventArgs e) {
            gridView1.OptionsBehavior.Editable = false;

            gridView1.Columns.AddVisible("STT");
            gridView1.Columns.AddVisible("ChiTieu");
            gridView1.Columns.AddVisible("MaSo");
            gridView1.Columns.AddVisible("SoDauNam");
            gridView1.Columns.AddVisible("SoCuoiNam");
            gridView1.Columns.AddVisible("ThuyetMinh");

            gridView1.Columns["STT"].FieldName = "STT";
            gridView1.Columns["ChiTieu"].FieldName = "ChiTieu";
            gridView1.Columns["MaSo"].FieldName = "MaSo";
            gridView1.Columns["SoDauNam"].FieldName = "SoDauNam";
            gridView1.Columns["SoDauNam"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns["SoDauNam"].DisplayFormat.FormatString = "###,###";
            gridView1.Columns["SoCuoiNam"].FieldName = "SoCuoiNam";
            gridView1.Columns["SoCuoiNam"].DisplayFormat.FormatType = FormatType.Numeric;
            gridView1.Columns["SoCuoiNam"].DisplayFormat.FormatString = "###,###";
            gridView1.Columns["ThuyetMinh"].FieldName = "ThuyetMinh";


            dt.Clear();
            dt.Columns.Add("STT", typeof(string));
            dt.Columns.Add("ChiTieu", typeof(string));
            dt.Columns.Add("MaSo", typeof(string));
            dt.Columns.Add("SoDauNam", typeof(double));
            dt.Columns.Add("SoCuoiNam", typeof(double));
            dt.Columns.Add("ThuyetMinh", typeof(string));

            LoadFakeData();
        }

        private void toolTipController1_GetActiveObjectInfo_1(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e) {
            if (e.SelectedControl != gridControl1) return;
            if (e.Info == null && e.SelectedControl == gridControl1) {
                GridView view = gridControl1.FocusedView as GridView;
                if (view == null) return;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                if (diction1.Keys.Contains(info.RowHandle)) {
                    if (info.InRowCell) {
                        foreach (KeyValuePair<double, string> item in diction1) {
                            if (info.RowHandle == item.Key) {
                                foreach (GridColumn column in lstColumnValidate) {
                                    if (info.Column == column) {
                                        string text = item.Value;
                                        string cellkey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                                        e.Info = new ToolTipControlInfo(cellkey, text, ToolTipIconType.Warning);
                                    }
                                }
                            }
                        }
                    }
                }
                if (diction2.Keys.Contains(info.RowHandle)) {
                    if (info.InRowCell) {
                        foreach (KeyValuePair<double, string> item in diction2) {
                            if (info.RowHandle == item.Key) {
                                foreach (GridColumn column in lstColumnValidate) {
                                    if (info.Column == column) {
                                        string text = item.Value;
                                        string cellkey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                                        e.Info = new ToolTipControlInfo(cellkey, text, ToolTipIconType.Warning);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {
            gridView1.OptionsBehavior.Editable = false;
            gridControl1.DataSource = null;
            dt.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            dt.Clear();
            gridView1.OptionsBehavior.Editable = false;
            LoadFakeData();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.Editable = true;
            if (dt.Columns.Contains("ErrorMessage1") && dt.Columns.Contains("ErrorMessage2")) {
                dt.Columns.Remove("ErrorMessage1");
                dt.Columns.Remove("ErrorMessage2");
            }

            for (int i = 0; i < dt.Rows.Count; i++) {
                dt.Rows[i]["SoDauNam"] = 0;
                dt.Rows[i]["SoCuoiNam"] = 0;
            }
        }

        private void btnValidate_Click(object sender, EventArgs e) {

            // highlight
            GridFormatRule gridFormatRule1 = new GridFormatRule();
            FormatConditionRuleExpression formatConditionRuleExpression = new FormatConditionRuleExpression();
            gridFormatRule1.Column = gridView1.Columns["SoDauNam"];
            formatConditionRuleExpression.PredefinedName = "Red Fill, Red Text";
            formatConditionRuleExpression.Expression = "[ErrorMessage1] >= 0";
            gridFormatRule1.Rule = formatConditionRuleExpression;
            gridView1.FormatRules.Add(gridFormatRule1);

            // iconset
            GridFormatRule gridFormatRule2 = new GridFormatRule();
            gridFormatRule2.Column = gridView1.Columns["ErrorMessage1"];
            gridFormatRule2.ColumnApplyTo = gridView1.Columns["SoDauNam"];
            FormatConditionRuleIconSet formatConditionRuleIconSet = new FormatConditionRuleIconSet();
            FormatConditionIconSet iconSet = formatConditionRuleIconSet.IconSet = new FormatConditionIconSet();
            FormatConditionIconSetIcon icon1 = new FormatConditionIconSetIcon();
            icon1.PredefinedName = "Symbols23_3.png";
            iconSet.ValueType = FormatConditionValueType.Number;
            icon1.Value = 0;
            icon1.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
            iconSet.Icons.Add(icon1);
            gridFormatRule2.Rule = formatConditionRuleIconSet;
            gridFormatRule2.Rule = formatConditionRuleIconSet;
            gridView1.FormatRules.Add(gridFormatRule2);

            // highlight
            GridFormatRule gridFormatRule3 = new GridFormatRule();
            FormatConditionRuleExpression formatConditionRuleExpression3 = new FormatConditionRuleExpression();
            gridFormatRule3.Column = gridView1.Columns["SoCuoiNam"];
            formatConditionRuleExpression3.PredefinedName = "Red Fill, Red Text";
            formatConditionRuleExpression3.Expression = "[ErrorMessage2] >= 0";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            gridView1.FormatRules.Add(gridFormatRule3);

            // iconset
            GridFormatRule gridFormatRule4 = new GridFormatRule();
            gridFormatRule4.Column = gridView1.Columns["ErrorMessage2"];
            gridFormatRule4.ColumnApplyTo = gridView1.Columns["SoCuoiNam"];
            FormatConditionRuleIconSet formatConditionRuleIconSet4 = new FormatConditionRuleIconSet();
            FormatConditionIconSet iconSet4 = formatConditionRuleIconSet4.IconSet = new FormatConditionIconSet();
            FormatConditionIconSetIcon icon4 = new FormatConditionIconSetIcon();
            icon4.PredefinedName = "Symbols23_3.png";
            iconSet4.ValueType = FormatConditionValueType.Number;
            icon4.Value = 0;
            icon4.ValueComparison = FormatConditionComparisonType.GreaterOrEqual;
            iconSet4.Icons.Add(icon4);
            gridFormatRule4.Rule = formatConditionRuleIconSet4;
            gridFormatRule4.Rule = formatConditionRuleIconSet4;
            gridView1.FormatRules.Add(gridFormatRule4);



            gridView1.OptionsBehavior.Editable = true;
            if (dt.Columns.Contains("ErrorMessage1") && dt.Columns.Contains("ErrorMessage2")) {
                dt.Columns.Remove("ErrorMessage1");
                dt.Columns.Remove("ErrorMessage2");
            }

            ValidationResult result = TableValdiation.Validate(dt, CreateRuleSet());

            if (result.IsValid) {
                MessageBox.Show("Validate Succees", "THÔNG BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControl1.DataSource = dt;
            }
            else {
                dt.Columns.Add("ErrorMessage1", typeof(int));
                dt.Columns.Add("ErrorMessage2", typeof(int));
                List<ValidationFailure> listError1 = new List<ValidationFailure>();
                List<ValidationFailure> listError2 = new List<ValidationFailure>();

                for (int i = 0; i < result.Errors.Count; i++) {
                    if (result.Errors.ElementAt(i).AttemptedValue.Equals((object)1))
                        listError1.Add(result.Errors.ElementAt(i));
                    else if (result.Errors.ElementAt(i).AttemptedValue.Equals((object)2))
                        listError2.Add(result.Errors.ElementAt(i));
                }

                diction1 = listError1.Select((element, index) => new { element.ErrorMessage, element.PropertyName })
                    .ToDictionary(ele => Convert.ToDouble(ele.PropertyName), ele => ele.ErrorMessage);

                diction2 = listError2.Select((element, index) => new { element.ErrorMessage, element.PropertyName })
                    .ToDictionary(ele => Convert.ToDouble(ele.PropertyName), ele => ele.ErrorMessage);

                foreach (var failure in listError1) {
                    DataRow dr = dt.Rows[Convert.ToInt32(failure.PropertyName)];
                    dr["ErrorMessage1"] = Convert.ToInt32(failure.PropertyName);
                }

                foreach (var failure in listError2) {
                    DataRow dr = dt.Rows[Convert.ToInt32(failure.PropertyName)];
                    dr["ErrorMessage2"] = Convert.ToInt32(failure.PropertyName);
                }
                gridControl1.DataSource = dt;
            }
            // danh sách những gridcolumn cần validate
            lstColumnValidate.Add(gridView1.Columns["SoDauNam"]);
            lstColumnValidate.Add(gridView1.Columns["SoCuoiNam"]);
            gridView1.BestFitColumns();
        }
        #endregion
    }
}

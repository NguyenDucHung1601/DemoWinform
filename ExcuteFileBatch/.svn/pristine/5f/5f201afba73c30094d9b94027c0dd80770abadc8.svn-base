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
    public partial class FormThuyetMinhBaoCaoTaiChinhTongHop : Form {
        #region Variable
        DataTable g_table = new DataTable();
        Dictionary<int, string> g_dictError = new Dictionary<int, string>();
        List<GridColumn> g_listValidateCol = new List<GridColumn>();
        List<RuleTable> g_listRule = new List<RuleTable>();
        List<Dictionary<int, string>> g_listDictError = new List<Dictionary<int, string>>();
        List<string> g_listValidateColName = new List<string>();
        #endregion

        #region Constructor
        public FormThuyetMinhBaoCaoTaiChinhTongHop() {
            InitializeComponent();
            gridData.OptionsBehavior.Editable = false;
            g_table.Clear();
            g_table.Columns.Add("STT", typeof(string));
            g_table.Columns.Add("ChiTieu", typeof(string));
            g_table.Columns.Add("MaSo", typeof(string));
            g_table.Columns.Add("SoDauNam", typeof(double));
            g_table.Columns.Add("SoCuoiNam", typeof(double));
            //g_table.Columns.Add("ThuyetMinh", typeof(string));

            g_listValidateColName.AddRange(new string[] { "SoDauNam", "SoCuoiNam" });
        }
        #endregion

        #region Business
        private void LoadFakeData() {
            g_table.Rows.Add(new object[] { "1", "Tiền", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Tiền mặt", "01", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Tiền gửi kho bạc", "02", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Tiền gửi ngân hàng", "03", 0, 0 });
            g_table.Rows.Add(new object[] { "", "d. Tiền đang chuyển", "04", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng cộng tiền", "05", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "2", "Các khoản phải thu khác", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Tạm chi", "06", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Tạm ứng cho nhân viên", "07", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Thuế GTGT được khấu trừ", "08", 0, 0 });
            g_table.Rows.Add(new object[] { "", "d. Chi phí trả trước", "09", 0, 0 });
            g_table.Rows.Add(new object[] { "", "đ. Đặt cọc, ký quỹ, ký cược", "10", 0, 0 });
            g_table.Rows.Add(new object[] { "", "e. Phải thu khác", "13", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng các khoản phải thu khác", "14", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "3", "Hàng tồn kho", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Nguyên liệu vật liệu", "15", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Công cụ dụng cụ", "16", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Chi phí SX, kinh doanh, dịch vụ dở dang", "17", 0, 0 });
            g_table.Rows.Add(new object[] { "", "d. Sản phẩm", "18", 0, 0 });
            g_table.Rows.Add(new object[] { "", "đ. Hàng hóa", "19", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng hàng tồn kho", "20", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            // ====
            //g_table.Rows.Add(new object[] { "4", "Tài sản cố định trang bị cho đơn vị", "", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "a. TSCĐ hữu hình", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Nguyên giá", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Số dư đầu năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Tăng trong năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Giảm trong năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Giá trị hao mòn", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Khấu hao lũy kế", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Giá trị còn lại cuối năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "b. TSCĐ vô hình", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Nguyên giá", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Số dư đầu năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Tăng trong năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Giảm trong năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Giá trị hao mòn", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Khấu hao lũy kế", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "  - Giá trị còn lại cuối năm", "22", 0, 0 });
            //g_table.Rows.Add(new object[] { "", "", "", null, null });
            // ==
            g_table.Rows.Add(new object[] { "5", "Xây dựng cơ bản dở dang", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Mua sắm TSCĐ", "21", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. XDCB dở dang", "22", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Nâng cấp TSCĐ", "23", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng giá trị xây dựng dở dang", "24", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "6", "Tài sản khác", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng giá trị tài sản khác", "25", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "7", "Phải trả nợ vay", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Vay ngắn hạn", "26", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Vay dài hạn", "27", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng các khoản vay", "28", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "8", "Tạm thu", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Kinh phí hoạt động bằng tiền", "29", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Viện trợ, vay nợ nước ngoài", "30", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Tạm thu phí, lệ phí", "31", 0, 0 });
            g_table.Rows.Add(new object[] { "", "d. Ứng trước dự toán", "32", 0, 0 });
            g_table.Rows.Add(new object[] { "", "đ. Tạm thu khác", "33", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng các khoản tạm thu trong năm", "34", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "9", "Các quỹ đặc thù", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Quỹ ...", "35", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng các quỹ đặc thù", "36", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "10", "Các khoản nhận trước chưa ghi thu", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Giá trị còn lại của TSCĐ", "37", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Nguyên liệu, vật liệu, CCDC tồn kho", "38", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Kinh phí đầu tư XDCB", "39", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng các khoản nhận trước chưa ghi thu", "40", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "11", "Nợ phải trả khác", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Các khoản phải nộp theo lương", "41", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Các khoản phải nộp nhà nước", "42", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Phải trả người lao động", "43", 0, 0 });
            g_table.Rows.Add(new object[] { "", "d. Các khoản thu hộ, chi hộ", "44", 0, 0 });
            g_table.Rows.Add(new object[] { "", "đ. Nhận đặt cọc, ký quỹ, ký cược", "45", 0, 0 });
            g_table.Rows.Add(new object[] { "", "e. Nợ phải trả khác", "46", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng các khoản nợ phải trả khác", "47", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "12", "Nguồn vốn kinh doanh", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Do NSNN cấp", "48", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Vốn góp", "49", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Khác", "50", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng nguồn vốn kinh doanh", "51", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "13", "Các quỹ", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Quỹ khen thưởng", "52", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Quỹ phúc lợi", "53", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Quỹ bổ sung thu nhập", "54", 0, 0 });
            g_table.Rows.Add(new object[] { "", "d. Quỹ phát triển hoạt động sự nghiệp", "55", 0, 0 });
            g_table.Rows.Add(new object[] { "", "đ. Quỹ dự phòng ổn định thu nhập", "56", 0, 0 });
            g_table.Rows.Add(new object[] { "", "e. Quỹ khác (chi tiết tên quỹ)", "57", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng các quỹ", "58", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "14", "Tài sản thuần khác", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "a. Chênh lệch tỷ giá hối đoái", "59", 0, 0 });
            g_table.Rows.Add(new object[] { "", "b. Nguồn cải cách tiền lương", "60", 0, 0 });
            g_table.Rows.Add(new object[] { "", "c. Tài sản thuần khác", "61", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng tài sản thuần khác", "62", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });
            g_table.Rows.Add(new object[] { "15", "Tài sản thuần của đơn vị thực hiện kế toán khác", "", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Đơn vị ...", "63", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Đơn vị ...", "64", 0, 0 });
            g_table.Rows.Add(new object[] { "", "Tổng tài sản thuần của đơn vị thực hiện chế độ kế toán khác", "65", 0, 0 });
            g_table.Rows.Add(new object[] { "", "", "", null, null });





            //g_table.Rows.Add(new object[] { "1", "Tiền", "01", 2601509, 4500000, "     01 = 02 + 03 + 04 + 05" });
            //g_table.Rows.Add(new object[] { "1", "Tiền mặt", "02", 2601509, 5000000, "" });
            //g_table.Rows.Add(new object[] { "2", "Tiền gửi kho bạc", "03", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "3", "Tiền gửi ngân hàng", "04", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "4", "Tiền đang chuyển", "05", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "II", "Các khoản phải thu khác", "06", 3000000, 5500000, "     06 = 07 + 08 + 09 + 10 + 11 + 12" });
            //g_table.Rows.Add(new object[] { "1", "Tạm chi", "07", 2000000, 3000000, "" });
            //g_table.Rows.Add(new object[] { "2", "Tạm ứng cho nhân viên", "08", 1500000, 2500000, "" });
            //g_table.Rows.Add(new object[] { "3", "Thuế GTGT được khấu trừ", "09", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "4", "Chi phí trả trước", "10", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "5", "Đặc cọc, ký quỹ, ký cược", "11", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "6", "Phải thu", "12", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "III", "Hàng tồn kho", "13", 3000000, 8000000, "     13 = 14 + 15 + 16 + 17 + 18" });
            //g_table.Rows.Add(new object[] { "1", "Nguyên liệu vật liệu", "14", 0, 1000000, "" });
            //g_table.Rows.Add(new object[] { "2", "Công cụ dụng cụ", "15", 3000000, 2000000, "" });
            //g_table.Rows.Add(new object[] { "3", "Chi phí sản xuất, kinh doanh, dịch vụ dở dang", "16", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "4", "Sản phẩm", "17", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "5", "Hàng hóa", "18", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "IV", "Tài sản cố định trang bị cho đơn vị", "19", 0, 0, "     19 = 20 + 26" });
            //g_table.Rows.Add(new object[] { "1", "Tài sản cố định hữu hình", "20", 0, 0, "     20 = 21 - 25" });
            //g_table.Rows.Add(new object[] { "", "- Nguyên giá", "21", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Số dư đầu năm", "22", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Tăng trong năm", "23", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Giảm trong năm", "24", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Giá trị hao mòn, khấu hao lũy kế", "25", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Tài sản cố định vô hình", "26", 0, 0, "     26 = 27 - 31" });
            //g_table.Rows.Add(new object[] { "", "- Nguyên giá", "27", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Số dư đầu năm", "28", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Tăng trong năm", "29", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Giảm trong năm", "30", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "", "- Giá trị hao mòn, khấu hao lũy kế", "31", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "V", "Xây dựng cơ bản dở dang", "32", 370000000, 150000000, "     32 = 33 + 34 + 35" });
            //g_table.Rows.Add(new object[] { "1", "Mua sắm TSCĐ", "33", 20000000, 10000000, "" });
            //g_table.Rows.Add(new object[] { "2", "XDCB dở dang", "34", 350000000, 120000000, "" });
            //g_table.Rows.Add(new object[] { "3", "Nâng cấp TSCĐ", "35", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "VI", "Tài sản khác", "36", 0, 0, "     36 = 37" });
            //g_table.Rows.Add(new object[] { "1", "Đơn vị thuyết minh chi tiết", "37", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "VII", "Phải trả nợ vay", "38", 200000000, 120000000, "     38 = 39 + 40" });
            //g_table.Rows.Add(new object[] { "1", "Vay ngắn hạn", "39", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Vay dài hạn", "40", 200000000, 120000000, "" });
            //g_table.Rows.Add(new object[] { "VIII", "Tạm thu", "41", 2601509, 40000000, "     41 = 42 + 43 + 44 + 45 + 46" });
            //g_table.Rows.Add(new object[] { "1", "Kinh phí hoạt động bằng tiền", "42", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Viện trợ, vay nợ nước ngoài", "43", 0, 20000000, "" });
            //g_table.Rows.Add(new object[] { "3", "Tạm thu phí, lệ phí", "44", 0, 15000000, "" });
            //g_table.Rows.Add(new object[] { "4", "Ứng trước dự toán", "45", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "5", "Tạm thu khác", "46", 2601509, 0, "" });
            //g_table.Rows.Add(new object[] { "IX", "Các quỹ đặc thù", "47", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "X", "Các khoản nhận trước chưa ghi thu", "48", 3319371588, 0, "     48 = 49 + 50 + 51" });
            //g_table.Rows.Add(new object[] { "1", "Giá trị còn lại của TSCĐ", "49", 3319371588, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Nguyên liệu, vật liệu, CCDC tồn kho", "50", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "3", "Kinh phí đầu tư XDCB", "51", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "XI", "Nợ phải trả khác", "52", 0, 0, "     52 = 53 + 54 + 55 + 56 + 57 + 58" });
            //g_table.Rows.Add(new object[] { "1", "Các khoản phải nộp theo lương", "53", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Các khoản phải nộp nhà nước", "54", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "3", "Phải trả người lao động", "55", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "4", "Các khoản thu hộ, chi hộ", "56", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "5", "Nhận đặc cọc, ký quỹ, ký cược", "57", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "6", "Nợ phải trả khác", "58", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "XII", "Nguồn vốn kinh doanh", "59", 0, 0, "     59 = 60 + 61 + 62" });
            //g_table.Rows.Add(new object[] { "1", "Do NSNN cấp", "60", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Vốn góp", "61", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "3", "Khác", "62", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "XIII", "Các quỹ", "63", 0, 0, "     63 = 64 + 65 + 66 + 67 + 68 + 69" });
            //g_table.Rows.Add(new object[] { "1", "Quỹ khen thưởng", "64", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Quỹ phúc lợi", "65", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "3", "Quỹ bổ sung thu nhập", "66", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "4", "Quỹ phát triển hoạt động sự nghiệp", "67", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "5", "Quỹ dự phòng ổn định thu nhập", "68", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "6", "Quỹ khác (chi tiết tên quỹ)", "69", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "XIV", "Tài sản thuần khác", "70", 0, 0, "     70 = 71 + 72 + 73" });
            //g_table.Rows.Add(new object[] { "1", "Chênh lệch tỷ giá hối đoái", "71", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Nguồn cải cách tiền lương", "72", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "3", "Tài sản thuần khác", "73", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "XV", "Tài sản thuần của đơn vị thực hiện chế độ kế toán khác", "74", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "XVI", "Biến động của nguồn vốn", "75", 247548000, 247548000, "     75 = 76 + 77 + 78 + 79 + 80 + 81" });
            //g_table.Rows.Add(new object[] { "1", "Nguồn vốn kinh doanh", "76", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "2", "Chênh lệch tỷ giá", "77", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "3", "Thặng dư (thâm hụt) lũy kế", "78", 165032000, 165032000, "" });
            //g_table.Rows.Add(new object[] { "4", "Các quỹ", "79", 0, 0, "" });
            //g_table.Rows.Add(new object[] { "5", "Nguồn cải cách tiền lương", "80", 82516000, 82516000, "" });
            //g_table.Rows.Add(new object[] { "6", "Khác", "81", 0, 0, "" });

            gridControlData.DataSource = g_table;
            //gridData.OptionsView.ColumnAutoWidth = true;
            gridData.BestFitColumns();
        }
        public void CreateListRule() {
            foreach (string item in g_listValidateColName) {

                g_listRule.Add(new RuleTable($"A.01.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.02.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.03.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.04.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.05.{item}", OPERATOR.EQUAL, $"A.01.{item} + A.02.{item} + A.03.{item} + A.04.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.06.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.07.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.08.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.09.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.10.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.13.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.14.{item}", OPERATOR.EQUAL, $"A.06.{item} + A.07.{item} + A.08.{item} + A.09.{item} + A.10.{item} + A.13.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.15.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.16.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.17.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.18.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.19.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.20.{item}", OPERATOR.EQUAL, $"A.15.{item} + A.16.{item} + A.17.{item} + A.18.{item} + A.19.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.21.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.22.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.23.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.24.{item}", OPERATOR.EQUAL, $"A.21.{item} + A.22.{item} + A.23.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.26.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.27.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.28.{item}", OPERATOR.EQUAL, $"A.26.{item} + A.27.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.29.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.30.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.31.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.32.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.33.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.34.{item}", OPERATOR.EQUAL, $"A.29.{item} + A.30.{item} + A.31.{item} + A.32.{item} + A.33.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.35.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.36.{item}", OPERATOR.EQUAL, $"A.35.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.37.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.38.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.39.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.40.{item}", OPERATOR.EQUAL, $"A.37.{item} + A.38.{item} + A.39.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.41.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.42.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.43.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.44.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.45.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.46.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.47.{item}", OPERATOR.EQUAL, $"A.41.{item} + A.42.{item} + A.43.{item} + A.44.{item} + A.45.{item} + A.46.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.48.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.49.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.50.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.51.{item}", OPERATOR.EQUAL, $"A.48.{item} + A.49.{item} + A.50.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.52.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.53.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.54.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.55.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.56.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.57.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.58.{item}", OPERATOR.EQUAL, $"A.52.{item} + A.53.{item} + A.54.{item} + A.55.{item} + A.56.{item} + A.57.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.59.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.60.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.61.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.62.{item}", OPERATOR.EQUAL, $"A.59.{item} + A.60.{item} + A.61.{item}", g_table));

                g_listRule.Add(new RuleTable($"A.63.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.64.{item}", OPERATOR.GREAT_THAN_OR_EQUAL, 0, g_table));
                g_listRule.Add(new RuleTable($"A.65.{item}", OPERATOR.EQUAL, $"A.63.{item} + A.64.{item}", g_table));



                //g_listRule.Add(new RuleTable($"A.01.{item}", OPERATOR.EQUAL, $"A.02.{item} + A.03.{item} + A.04.{item} + A.05.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.06.{item}", OPERATOR.EQUAL, $"A.07.{item} + A.08.{item} + A.09.{item} + A.10.{item} + A.11.{item} + A.12.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.13.{item}", OPERATOR.EQUAL, $"A.14.{item} + A.15.{item} + A.16.{item} + A.17.{item} + A.18.{item}", g_table));

                //// ============ RulrFor Tài sản cố định trang bị cho đơn vị
                //g_listRule.Add(new RuleTable($"A.19.{item}", OPERATOR.EQUAL, $"A.20.{item} + A.26.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.20.{item}", OPERATOR.EQUAL, $"A.21.{item} - A.25.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.26.{item}", OPERATOR.EQUAL, $"A.27.{item} - A.31.{item}", g_table));
                //// ===========

                //g_listRule.Add(new RuleTable($"A.32.{item}", OPERATOR.EQUAL, $"A.33.{item} + A.34.{item} + A.35.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.36.{item}", OPERATOR.EQUAL, $"A.37.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.38.{item}", OPERATOR.EQUAL, $"A.39.{item} + A.40.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.41.{item}", OPERATOR.EQUAL, $"A.42.{item} + A.43.{item} + A.44.{item} + A.45.{item} + A.46.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.48.{item}", OPERATOR.EQUAL, $"A.49.{item} + A.50.{item} + A.51.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.52.{item}", OPERATOR.EQUAL, $"A.53.{item} + A.54.{item} + A.55.{item} + A.56.{item} + A.57.{item} + A.58.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.59.{item}", OPERATOR.EQUAL, $"A.60.{item} + A.61.{item} + A.62.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.63.{item}", OPERATOR.EQUAL, $"A.64.{item} + A.65.{item} + A.66.{item} + A.67.{item} + A.68.{item} + A.69.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.70.{item}", OPERATOR.EQUAL, $"A.71.{item} + A.72.{item} + A.73.{item}", g_table));

                //g_listRule.Add(new RuleTable($"A.75.{item}", OPERATOR.EQUAL, $"A.76.{item} + A.77.{item} + A.78.{item} + A.79.{item} + A.80.{item} + A.81.{item}", g_table));

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

            // danh sách những gridcolumn cần validate , dùng để hiển thị lỗi
            foreach (string item in g_listValidateColName) {
                g_listValidateCol.Add(gridData.Columns[item]);
            }

            if (result.IsValid) {
                MessageBox.Show("Validate Succees", "THÔNG BÁO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControlData.DataSource = g_table;
            }
            else {

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
                //gridData.Columns["MaSo"].Visible = false;
                //gridData.Columns["ThuyetMinh"].Visible = false;

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


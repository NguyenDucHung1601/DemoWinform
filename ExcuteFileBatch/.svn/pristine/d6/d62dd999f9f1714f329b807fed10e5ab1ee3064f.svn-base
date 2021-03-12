using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFluentValidation {
    public class Cell {
        public string ColName { get; private set; }
        public string IdRow { get; private set; }
        public Cell(string idRow, string colName) {
            this.IdRow = idRow;
            this.ColName = colName;
        }
        public int IndexCell(DataTable dt) {
            return dt.Rows.IndexOf(dt.AsEnumerable().Where(d => d.Field<string>("MaSo") == this.IdRow).First());
        }

        public double ValueCell(DataTable table) {
            return Convert.ToDouble(table.Rows[this.IndexCell(table)][this.ColName]);
        }
    }
}

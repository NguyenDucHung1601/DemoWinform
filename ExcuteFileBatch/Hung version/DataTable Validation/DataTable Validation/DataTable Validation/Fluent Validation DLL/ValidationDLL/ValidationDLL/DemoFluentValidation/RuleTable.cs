using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFluentValidation {
    public struct DtCell {
        public string rowID;
        public string colName;
    }

    public struct ExpressionItem {
        public int sign;
        public DtCell cell;
    }

    public enum OPERATOR {
        GREAT_THAN,
        GREAT_THAN_OR_EQUAL,
        LESS_THAN,
        LESS_THAN_OR_EQUAL,
        EQUAL,
        NOT_EQUAL,
        MULTI_EQUAL
    }

    public class RuleTable {
        public static string validateCol = "MaSo";
        public DataTable ValidateTable { get; set; }
        public DtCell Cell { get; set; }
        public double ValueCell { get; set; }
        public OPERATOR Operator { get; set; }
        public double CompareExpression { get; private set; }
        public List<double> MultiCompareExpresstion { get; set; }
        public string Message { get; private set; }

        public object attemptedValue { get; set; }

        public RuleTable(DtCell _cell, double _valuecell, OPERATOR _operator, double _compareExpression, string _message) {
            this.Cell = _cell;
            this.ValueCell = _valuecell;
            this.Operator = _operator;
            this.CompareExpression = _compareExpression;
            this.Message = _message;
        }

        public RuleTable(DataTable _table, DtCell _cell, OPERATOR _operator, double _compareExpression, string _message) {
            this.ValidateTable = _table;
            this.Cell = _cell;
            this.ValueCell = CellValue(_table, _cell);
            this.Operator = _operator;
            this.CompareExpression = _compareExpression;
            this.Message = _message;
        }

        public RuleTable(DataTable _table, DtCell _cell, OPERATOR _operator, double _compareExpression, string _message, object _attemptedvalue) {
            this.ValidateTable = _table;
            this.Cell = _cell;
            this.ValueCell = CellValue(_table, _cell);
            this.Operator = _operator;
            this.CompareExpression = _compareExpression;
            this.Message = _message;
            this.attemptedValue = _attemptedvalue;
        }

        public RuleTable(DataTable _table, DtCell _cell, OPERATOR _operator, List<double> _multiCompareExpression, string _message, object _attemptedvalue) {
            this.ValidateTable = _table;
            this.Cell = _cell;
            this.ValueCell = CellValue(_table, _cell);
            this.Operator = _operator;
            this.MultiCompareExpresstion = _multiCompareExpression;
            this.Message = _message;
            this.attemptedValue = _attemptedvalue;
        }

        public static DtCell DtCell(string _rowid, string _colname) {
            DtCell cell;
            cell.rowID = _rowid;
            cell.colName = _colname;
            return cell;
        }

        public static ExpressionItem ExpressionItem(int _sign, DtCell _cell) {
            ExpressionItem item;
            item.sign = _sign;
            item.cell = _cell;
            return item;
        }

        public static double ToCompareExrpession(DataTable table, List<ExpressionItem> listItem) {
            double expression = 0;
            foreach (ExpressionItem item in listItem) {
                if (item.sign == 1)
                    expression += Convert.ToDouble(table.Rows[GetRowIndexByRowCode(table, item.cell.rowID)][item.cell.colName]);
                else
                    expression -= Convert.ToDouble(table.Rows[GetRowIndexByRowCode(table, item.cell.rowID)][item.cell.colName]);
            }
            return expression;
        }

        public static double CellValue(DataTable table, DtCell cell) {
            return Convert.ToDouble(table.Rows[GetRowIndexByRowCode(table, cell.rowID)][cell.colName]);
        }

        public static int GetRowIndexByRowCode(DataTable dt, string rowId) {
            //int index = new System.Data.DataView(dt).ToTable(false, new[] { validateCol })
            //      .AsEnumerable()
            //      .Select(row => row.Field<int>(validateCol))
            //      .ToList()
            //      .FindIndex(col => col == Convert.ToInt32(rowId));
            //return index;
            int index = new System.Data.DataView(dt).ToTable(false, new[] { validateCol })
                  .AsEnumerable()
                  .Select(row => row.Field<string>(validateCol))
                  .ToList()
                  .FindIndex(col => col == rowId);
            return index;
        }
    }
}

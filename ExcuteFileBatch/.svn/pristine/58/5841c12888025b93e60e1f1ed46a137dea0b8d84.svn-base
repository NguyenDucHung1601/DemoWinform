using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoFluentValidation {

    public class RuleTable {
        #region Property
        // common
        //public double CompareCell { get; private set; }
        public string Operator { get; private set; }
        public double CompareExpression { get; private set; }
        public string ErrorMessage { get; private set; }
        // cell
        public Cell DtCell { get; private set; }
        #endregion

        #region Constructor
        public RuleTable(string strCompareCell, string strOperator, string strCompareExpression, Argument[] listArg) {
            this.Operator = strOperator;
            this.DtCell = ToCompareCell(strCompareCell);
            try {
                this.CompareExpression = double.Parse(strCompareExpression);
            }
            catch {
                this.CompareExpression = ToCompareExpressionValue(strCompareExpression,listArg);
            }
            this.ErrorMessage = (strCompareCell + " " + strOperator + " " + strCompareExpression).Replace("_",".");
        }
        #endregion

        #region Business
        public Cell ToCompareCell(string strCompareCell) {
            string[] strCell = strCompareCell.Split('_');
            return new Cell(strCell[1], strCell[2]);
        }

        public double ToCompareExpressionValue(string strCompareExpression, Argument[] listArg) {
            Expression expression = new Expression(strCompareExpression, listArg);
            return expression.calculate();
        }
        #endregion
    }
}

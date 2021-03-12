using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFluentValidation {
    public class TableValdiation {

        public static ValidationResult Validate(DataTable table, List<RuleTable> listRule) {
            ValidationResult result = new ValidationResult();

            foreach (RuleTable rule in listRule) {
                switch (rule.Operator) {
                    case OPERATOR.GREAT_THAN:
                        if (!(rule.ValueCell > rule.CompareExpression))
                            result.Errors.Add(new ValidationFailure(RuleTable.GetRowIndexByRowCode(table, rule.Cell.rowID).ToString(), rule.Message, rule.attemptedValue));
                        break;
                    case OPERATOR.GREAT_THAN_OR_EQUAL:
                        if (!(rule.ValueCell >= rule.CompareExpression))
                           result.Errors.Add(new ValidationFailure(RuleTable.GetRowIndexByRowCode(table, rule.Cell.rowID).ToString(), rule.Message, rule.attemptedValue));
                        break;
                    case OPERATOR.LESS_THAN:
                        if (!(rule.ValueCell < rule.CompareExpression))
                           result.Errors.Add(new ValidationFailure(RuleTable.GetRowIndexByRowCode(table, rule.Cell.rowID).ToString(), rule.Message, rule.attemptedValue));
                        break;
                    case OPERATOR.LESS_THAN_OR_EQUAL:
                        if (!(rule.ValueCell <= rule.CompareExpression))
                           result.Errors.Add(new ValidationFailure(RuleTable.GetRowIndexByRowCode(table, rule.Cell.rowID).ToString(), rule.Message, rule.attemptedValue));
                        break;
                    case OPERATOR.EQUAL:
                        if (!(rule.ValueCell == rule.CompareExpression))
                           result.Errors.Add(new ValidationFailure(RuleTable.GetRowIndexByRowCode(table, rule.Cell.rowID).ToString(), rule.Message, rule.attemptedValue));
                        break;
                    case OPERATOR.NOT_EQUAL:
                        if (!(rule.ValueCell != rule.CompareExpression))
                           result.Errors.Add(new ValidationFailure(RuleTable.GetRowIndexByRowCode(table, rule.Cell.rowID).ToString(), rule.Message, rule.attemptedValue));
                        break;
                    case OPERATOR.MULTI_EQUAL:
                        bool check = true;
                        foreach (double expression in rule.MultiCompareExpresstion) {
                            if (!(rule.ValueCell == expression)) {
                                check = false;
                                break;
                            }
                        }
                        if(!check)
                            result.Errors.Add(new ValidationFailure(RuleTable.GetRowIndexByRowCode(table, rule.Cell.rowID).ToString(), rule.Message, rule.attemptedValue));
                        break;
                }
            }

            return result;
        }
    }
}

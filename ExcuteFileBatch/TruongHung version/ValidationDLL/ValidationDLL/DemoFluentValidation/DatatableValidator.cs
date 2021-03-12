using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFluentValidation {
    public class DatatableValidator : AbstractValidator<DataTable> {
        public DatatableValidator(DataTable dt, List<RuleTable> listRuleTable) {

            RuleSet("Validate", () => {
                foreach (RuleTable rule in listRuleTable) {
                    int index = rule.DtCell.IndexCell(dt);
                    switch (rule.Operator) {
                        case ">":
                            RuleFor(x => x.Rows[index].Field<double>(rule.DtCell.ColName)).
                                GreaterThan(rule.CompareExpression).
                                    OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage).WithState(x => rule.DtCell.ColName);
                            break;

                        case ">=":
                            RuleFor(x => x.Rows[index].Field<double>(rule.DtCell.ColName)).
                                GreaterThanOrEqualTo(rule.CompareExpression).
                                    OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage).WithState(x => rule.DtCell.ColName);
                            break;

                        case "<":
                            RuleFor(x => x.Rows[index].Field<double>(rule.DtCell.ColName)).
                                LessThan(rule.CompareExpression).
                                    OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage).WithState(x => rule.DtCell.ColName);
                            break;

                        case "<=":
                            RuleFor(x => x.Rows[index].Field<double>(rule.DtCell.ColName)).
                                LessThanOrEqualTo(rule.CompareExpression).
                                    OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage).WithState(x => rule.DtCell.ColName);
                            break;

                        case "=":
                            RuleFor(x => x.Rows[index].Field<double>(rule.DtCell.ColName)).
                                Equal(rule.CompareExpression).
                                    OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage).WithState(x => rule.DtCell.ColName);
                            break;

                        case "!=":
                            RuleFor(x => x.Rows[index].Field<double>(rule.DtCell.ColName)).
                                NotEqual(rule.CompareExpression).
                                    OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage).WithState(x => rule.DtCell.ColName);
                            break;
                    }
                }

                #region comment

                //Truy xuất dữ liệu của bảng dùng Index

                //switch (rule.Operator) {
                //    case OPERATOR.GREAT_THAN:
                //        RuleFor(x => Convert.ToDouble(x.Rows[index].Field<int>(rule.Cell.ColName))).
                //            GreaterThan(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.GREAT_THAN_OR_EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.Rows[index].Field<int>(rule.Cell.ColName))).
                //            GreaterThanOrEqualTo(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.LESS_THAN:
                //        RuleFor(x => Convert.ToDouble(x.Rows[index].Field<int>(rule.Cell.ColName))).
                //            LESS_THAN(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.LESS_THAN_OR_EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.Rows[index].Field<int>(rule.Cell.ColName))).
                //            LESS_THANOrEqualTo(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.Rows[index].Field<int>(rule.Cell.ColName))).
                //              Equal(rule.valueCompareExpression).
                //                 OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.NOT_EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.Rows[index].Field<int>(rule.Cell.ColName))).
                //            NOT_EQUAL(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;
                //}


                //switch (rule.Operator) {
                //    case OPERATOR.GREAT_THAN:
                //        RuleFor(x => Convert.ToDouble(x.AsEnumerable().Where(y => y.Field<int>("MaSo") == Convert.ToInt32(rule.Cell.IdRow)).Select(r => r.Field<int>(rule.Cell.ColName)).First())).
                //            GreaterThan(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.GREAT_THAN_OR_EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.AsEnumerable().Where(y => y.Field<int>("MaSo") == Convert.ToInt32(rule.Cell.IdRow)).Select(r => r.Field<int>(rule.Cell.ColName)).First())).
                //            GreaterThanOrEqualTo(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.LESS_THAN:
                //        RuleFor(x => Convert.ToDouble(x.AsEnumerable().Where(y => y.Field<int>("MaSo") == Convert.ToInt32(rule.Cell.IdRow)).Select(r => r.Field<int>(rule.Cell.ColName)).First())).
                //            LESS_THAN(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.LESS_THAN_OR_EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.AsEnumerable().Where(y => y.Field<int>("MaSo") == Convert.ToInt32(rule.Cell.IdRow)).Select(r => r.Field<int>(rule.Cell.ColName)).First())).
                //            LESS_THANOrEqualTo(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.AsEnumerable().Where(y => y.Field<int>("MaSo") == Convert.ToInt32(rule.Cell.IdRow)).Select(r => r.Field<int>(rule.Cell.ColName)).First())).
                //              Equal(rule.valueCompareExpression).
                //                 OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;

                //    case OPERATOR.NOT_EQUAL:
                //        RuleFor(x => Convert.ToDouble(x.AsEnumerable().Where(y => y.Field<int>("MaSo") == Convert.ToInt32(rule.Cell.IdRow)).Select(r => r.Field<int>(rule.Cell.ColName)).First())).
                //            NOT_EQUAL(rule.valueCompareExpression).
                //                OverridePropertyName(index.ToString()).WithMessage(rule.ErrorMessage);
                //        break;
                //}

                #endregion
            });
        }
    }
}


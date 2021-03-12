using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFluentValidation {
    public class DatatableValidator : AbstractValidator<DataTable> {

        public DatatableValidator() {

            RuleSet("SoCuoiNamValidate", () => {

                RuleFor(x => x.Rows[0].Field<int>("SoCuoiNam")).
                        Equal(x => x.Rows[1].Field<int>("SoCuoiNam") + x.Rows[2].Field<int>("SoCuoiNam") + x.Rows[3].Field<int>("SoCuoiNam")).
                            OverridePropertyName("0").WithMessage("10 = 11 + 12 + 14");

                RuleFor(x => x.Rows[4].Field<int>("SoCuoiNam")).
                    Equal(x => x.Rows[5].Field<int>("SoCuoiNam") + x.Rows[6].Field<int>("SoCuoiNam")).
                        OverridePropertyName("4").WithMessage("31 = 32 + 33");

                RuleFor(x => x.Rows[6].Field<int>("SoCuoiNam")).
                    LessThanOrEqualTo(0).OverridePropertyName("6").WithMessage("33 <= 0");

                RuleFor(x => x.Rows[7].Field<int>("SoCuoiNam")).
                    Equal(x => x.Rows[8].Field<int>("SoCuoiNam") + x.Rows[9].Field<int>("SoCuoiNam")).
                        OverridePropertyName("7").WithMessage("35 = 36 + 37");

                RuleFor(x => x.Rows[9].Field<int>("SoCuoiNam")).
                    LessThanOrEqualTo(0).OverridePropertyName("9").WithMessage("37 <= 0");

                RuleFor(x => x.Rows[10].Field<int>("SoCuoiNam")).
                    Equal(x => x.Rows[17].Field<int>("SoCuoiNam")).
                        OverridePropertyName("10").WithMessage("50 = 80");

                RuleFor(x => x.Rows[11].Field<int>("SoCuoiNam")).
                    Equal(x => x.Rows[12].Field<int>("SoCuoiNam") + x.Rows[13].Field<int>("SoCuoiNam") + x.Rows[14].Field<int>("SoCuoiNam") + x.Rows[15].Field<int>("SoCuoiNam") + x.Rows[16].Field<int>("SoCuoiNam")).
                        OverridePropertyName("11").WithMessage("60 = 61 + 62 + 64 + 65 + 66");

                RuleFor(x => x.Rows[17].Field<int>("SoCuoiNam")).
                    Equal(x => x.Rows[10].Field<int>("SoCuoiNam")).
                        OverridePropertyName("17").WithMessage("80 = 50");



                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 10).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    Equal(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 11 || y.Field<int>("MaSo") == 12 || y.Field<int>("MaSo") == 14).Select(r => r.Field<int>("SoCuoiNam")).Sum()).
                //        OverridePropertyName("0").WithMessage("10 = 11 + 12 + 14");

                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 31).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    Equal(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 32 || y.Field<int>("MaSo") == 33).Select(r => r.Field<int>("SoCuoiNam")).Sum()).
                //        OverridePropertyName("4").WithMessage("31 = 32 + 33");

                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 33).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    LessThanOrEqualTo(0).OverridePropertyName("6").WithMessage("33 <= 0");

                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 35).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    Equal(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 36 || y.Field<int>("MaSo") == 37).Select(r => r.Field<int>("SoCuoiNam")).Sum()).
                //        OverridePropertyName("7").WithMessage("35 = 36 + 37");

                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 37).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    LessThanOrEqualTo(0).OverridePropertyName("9").WithMessage("37 <= 0");

                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 50).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    Equal(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 80).Select(r => r.Field<int>("SoCuoiNam")).Sum()).
                //        OverridePropertyName("10").WithMessage("50 = 80");

                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 60).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    Equal(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 61 || y.Field<int>("MaSo") == 62 || y.Field<int>("MaSo") == 64 || y.Field<int>("MaSo") == 65 || y.Field<int>("MaSo") == 66).Select(r => r.Field<int>("SoCuoiNam")).Sum()).
                //        OverridePropertyName("11").WithMessage("60 = 61 + 62 + 64 + 65 + 66");

                //RuleFor(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 80).Select(r => r.Field<int>("SoCuoiNam")).First()).
                //    Equal(x => x.AsEnumerable().Where(y => y.Field<int>("MaSo") == 50).Select(r => r.Field<int>("SoCuoiNam")).Sum()).
                //    OverridePropertyName("17").WithMessage("80 = 50");
            });

        }

        public static ValidationResult Validate(DataTable table, List<RuleTable> listRule) {
            foreach (RuleTable rule in listRule) {
               
            }
            return new ValidationResult();
        }
    }
}


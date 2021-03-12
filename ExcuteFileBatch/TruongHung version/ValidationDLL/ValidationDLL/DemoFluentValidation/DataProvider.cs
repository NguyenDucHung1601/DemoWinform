using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Common;
using System.Text.RegularExpressions;
using org.mariuszgromada.math.mxparser;
using org.mariuszgromada.math.mxparser.parsertokens;

namespace DemoFluentValidation {
    public class DataProvider {
        public static string conStr = @"Data Source=VCS06-2\SQLEXPRESS;Initial Catalog=DataTableValidation;User ID=sa; Password=123456";
        public static DataTable dt;
        public static HashSet<Argument> listArg = new HashSet<Argument>();
        public static void GetListArgument(string reportCode, DataTable table) {
            List<RuleTable> listRule = new List<RuleTable>();
            SqlConnection cnn = new SqlConnection(conStr);
            using (cnn) {
                string sql = $"SELECT * FROM RuleTableCollection WHERE ReportCode = '{reportCode}'";
                SqlCommand com = new SqlCommand(sql, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                StringBuilder strExpression = new StringBuilder();
                HashSet<string> listKey = new HashSet<string>();
                dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++) {
                    try {
                        double.Parse(dt.Rows[i]["CompareExpression"].SafeToString());
                    }
                    catch {
                        strExpression.Append(dt.Rows[i]["CompareExpression"].SafeToString() + " ");
                    }
                }
                Expression ex = new Expression(strExpression.ToString());
                listKey = ex.getMissingUserDefinedArguments().ToHashSet();
                ToListArgument(ToDictionaryValue(listKey, table));
            }
        }

        public static Dictionary<string, double> ToDictionaryValue(HashSet<string> _listKey, DataTable table) {
            Dictionary<string, double> dictionaryValue = new Dictionary<string, double>();
            Cell cell;
            string[] keySplit;
            foreach (string key in _listKey) {
                keySplit = key.Split('_');
                cell = new Cell(keySplit[1], keySplit[2]);
                dictionaryValue.Add(key, cell.ValueCell(table));
            }
            return dictionaryValue;
        }
        public static void ToListArgument(Dictionary<string, double> dicValue) {
            foreach(KeyValuePair<string,double> item in dicValue) {
                listArg.Add(new Argument(item.Key, item.Value));
            }
        }
        public static List<RuleTable> GetListRule(string reportCode, DataTable table) {
            List<RuleTable> listRule = new List<RuleTable>();
            GetListArgument(reportCode, table);
            for (int i = 0; i < dt.Rows.Count; i++) {
                listRule.Add(new RuleTable(
                    dt.Rows[i]["ValidateCell"].SafeToString(),
                    dt.Rows[i]["VOperator"].SafeToString(),
                    dt.Rows[i]["CompareExpression"].SafeToString(),
                    listArg.ToArray()
                    )
                );
            }
            return listRule;
        }
    }
}

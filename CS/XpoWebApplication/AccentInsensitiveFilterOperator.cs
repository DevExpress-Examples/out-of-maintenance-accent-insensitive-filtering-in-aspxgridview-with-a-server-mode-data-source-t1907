using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XpoWebApplication {
    public static class AccentInsensitiveFilterStatic {
        public static string Name { get { return "AccentInsensitive"; } }
    }
    public class AccentInsensitiveFilterOperator : ICustomFunctionOperator, ICustomFunctionOperatorFormattable {
        public string Name {
            get { return AccentInsensitiveFilterStatic.Name; }
        }
        string ICustomFunctionOperatorFormattable.Format(Type providerType, params String[] operands) {
            var operand = string.Format("N'%{0}%'", operands[0].Split('\'')[1]);
            return string.Format("{0} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE {1} ", operands[1], operand);
        }
        public Type ResultType(params Type[] operands) {
            return typeof(bool);
        }
        public object Evaluate(params object[] operands) {
            return null;
        }
    }
}
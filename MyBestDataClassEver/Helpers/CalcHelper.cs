using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestDataClassEver.Helpers {
    public class CalcHelper {
        public static double EvaluateExpression(string expression) {
            Expression expr = new Expression(expression);
            object result = expr.Evaluate();
            return Convert.ToDouble(result);
        }
    }
}

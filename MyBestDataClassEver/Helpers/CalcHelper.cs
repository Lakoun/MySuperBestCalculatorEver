using Microsoft.Extensions.Logging;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestDataClassEver.Helpers {
    public class CalcHelper {

        //public readonly ILogger _logger;
        //public CalcHelper(FileLogger logger) {
        //    _logger = logger;          
        //}

        public static double EvaluateExpression(string expression) {
            Expression expr = new Expression(expression);
            try {
                object result = expr.Evaluate();
                return Convert.ToDouble(result);
            } catch (Exception ex) {
                return 0;
                throw;
            }           
        }
    }
}

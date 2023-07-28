using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBestDataClassEver;
using MyBestDataClassEver.Helpers;

namespace MySuperBestCalculatorEver.ViewModels {
    public class DefaultViewModel : MasterPageViewModel {

        private readonly ILogger _logger;

        public CalcDataDal _calcRes;
        public string Title { get; set; }

        public string expression { get; set; } = "";

        public double? result { get; set; } = 0;

        public bool IsRsultNotDouble { get; set; }

        public List<string> List { get; set; } = new List<string>();

        public DefaultViewModel(FileLogger logger, CalcDataDal calcRes) {
            _calcRes = calcRes;

            _logger = logger;

            _logger.LogInformation("This is a log message.");

            Title = "Hello my super calculator!";
        }

        public override Task Init() {
            GetLastValues();
            return base.Init();
        }

        public override async Task PreRender() {
            GetLastValues();

            await base.PreRender();
        }

        public void Calc() {
            if (expression != "") { 
                result = CalcHelper.EvaluateExpression(expression);
                if (IsRsultNotDouble) result = Math.Round((double)result);
                _calcRes.InsertNew("myRes", new MyBestDataClassEver.Entities.SavedResults() { 
                BrowserId = "", Expresion = expression + " = " + result
                });
                SaveResultsToCookie(expression + " = " + result);
                GetLastValues();
            }
        }

        public void GetLastValues() {
            List = UserPreferences.LastResults.TakeLast(10).ToList();
        }

        public void AddChar(string Character) {
            if (Character == "C" || result != 0) {
                result = 0;
                expression = "";
                if(Character != "C") expression += Character;
            } else {
                expression += Character;
            }
        }
        public void RemoveChar() {
            expression = expression.Remove(expression.Length - 1);
        }
    }
}

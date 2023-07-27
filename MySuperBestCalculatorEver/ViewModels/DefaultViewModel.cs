using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MySuperBestCalculatorEver.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly ILogger _logger;
        public string Title { get; set;}

        public DefaultViewModel(FileLogger logger) { 
            _logger = logger;
            _logger.LogInformation("This is a log message.");

            Title = "Hello my super calculator!";
		}
    }
}

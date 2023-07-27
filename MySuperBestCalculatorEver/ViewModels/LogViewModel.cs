using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using System.IO;

namespace MySuperBestCalculatorEver.ViewModels
{
    public class LogViewModel : MasterPageViewModel
    {
        string filePath = "MySuper.log";
        public string log { get; set; }
        public List<string> loglines { get; set; } = new List<string>();
        public LogViewModel() {
           
           
            try {
                using (StreamReader reader = new StreamReader(filePath)) {
                    log = reader.ReadToEnd();
                    string[] linesArray = log.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    loglines = new List<string>(linesArray);
                }
            } catch (Exception ex) {

            }
        }   
    }
}


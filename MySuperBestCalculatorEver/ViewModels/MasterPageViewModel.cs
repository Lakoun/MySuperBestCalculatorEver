using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using MyBestDataClassEver;
using MyBestDataClassEver.Entities;
using Newtonsoft.Json;

namespace MySuperBestCalculatorEver.ViewModels
{
    public class MasterPageViewModel : DotvvmViewModelBase
    {
       
        public UserPreferences UserPreferences { get; set; } = new UserPreferences();

        

        public override Task Init() {
            initCookies();

            return base.Init();
        }
        public override async Task PreRender() {
            initCookies();

            await base.PreRender();
        }

        public void initCookies() {
            if (!Context.IsPostBack) {
                if (Context.GetAspNetCoreContext().Request.Cookies.TryGetValue("UserPreferences", out var preferencesJson)) {
                    try {
                        JsonConvert.PopulateObject(preferencesJson, UserPreferences);
                    } catch (Exception e) {
                        //TODO
                    }
                }
            }

            Context.GetAspNetCoreContext().Response.Cookies.Append("UserPreferences", JsonConvert.SerializeObject(UserPreferences), new() {
                Expires = DateTime.Now.AddDays(60)
            });
        }

        public void SaveResultsToCookie(string expression) {
            UserPreferences.LastResults.Add(expression);
            Context.GetAspNetCoreContext().Response.Cookies.Append("UserPreferences", JsonConvert.SerializeObject(UserPreferences), new() {
                Expires = DateTime.Now.AddDays(60)
            });
        }

    }
}

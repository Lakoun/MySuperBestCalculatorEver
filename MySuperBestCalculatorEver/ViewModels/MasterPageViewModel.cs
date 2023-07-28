using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using MyBestDataClassEver.Entities;
using Newtonsoft.Json;

namespace MySuperBestCalculatorEver.ViewModels
{
    public class MasterPageViewModel : DotvvmViewModelBase
    {
        public UserPreferences UserPreferences { get; set; } = new UserPreferences();

        public override Task Init() {

            if (!Context.IsPostBack) {
                if (Context.GetAspNetCoreContext().Request.Cookies.TryGetValue("UserPreferences", out var preferencesJson)) {
                    try {
                        JsonConvert.PopulateObject(preferencesJson, UserPreferences);
                    } catch (Exception e) {
                        //TODO
                    }
                }

                //if (UserPreferences.CurrentGroupId != null) {
                //    SelectedGroup = AvalibleGroups.Where(g => g.GroupId == UserPreferences.CurrentGroupId).FirstOrDefault();
                //}

                ////TODO: If selected
                //if (SelectedGroup == null && AvalibleGroups.Count() > 0) {
                //    SelectedGroup = AvalibleGroups.FirstOrDefault();
                //    UserPreferences.CurrentGroupId = SelectedGroup.GroupId;
                //}
            }

            return base.Init();
        }
        public override async Task PreRender() {
            if (!Context.IsPostBack) {
                if (Context.GetAspNetCoreContext().Request.Cookies.TryGetValue("UserPreferences", out var preferencesJson)) {
                    try {
                        JsonConvert.PopulateObject(preferencesJson, UserPreferences);
                    } catch (Exception e) {
                        //TODO
                    }
                }

                //if (UserPreferences.CurrentGroupId != null) {
                //    SelectedGroup = AvalibleGroups.Where(g => g.GroupId == UserPreferences.CurrentGroupId).FirstOrDefault();
                //}

                ////TODO: If selected
                //if (SelectedGroup == null && AvalibleGroups.Count() > 0) {
                //    SelectedGroup = AvalibleGroups.FirstOrDefault();
                //    UserPreferences.CurrentGroupId = SelectedGroup.GroupId;
                //}
            }

            Context.GetAspNetCoreContext().Response.Cookies.Append("UserPreferences", JsonConvert.SerializeObject(UserPreferences), new() {
                Expires = DateTime.Now.AddDays(60)
            });

            await base.PreRender();
        }

        public void SaveResultsToCookie(string expression) {
            UserPreferences.LastResults.Add(expression);
            Context.GetAspNetCoreContext().Response.Cookies.Append("UserPreferences", JsonConvert.SerializeObject(UserPreferences), new() {
                Expires = DateTime.Now.AddDays(60)
            });
        }

    }
}

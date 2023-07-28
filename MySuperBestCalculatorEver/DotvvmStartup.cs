using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MySuperBestCalculatorEver {
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath) {

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath) {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.Add("Log", "log", "Views/Log.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath) {
            config.Markup.AddMarkupControl("cc", "CalculatorCard", "Views/Controls/CalculatorCard.dotcontrol");
            config.Markup.AddMarkupControl("cc", "ResultsCard", "Views/Controls/ResultsCard.dotcontrol");
            config.Markup.AddMarkupControl("cc", "Navbar", "Views/Controls/Navbar.dotcontrol");
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath) {
            config.Resources.Register("TablerCss", new StylesheetResource {
                Location = new UrlResourceLocation("https://cdn.jsdelivr.net/npm/@tabler/core@1.0.0-beta17/dist/css/tabler.min.css")
            });
            config.Resources.Register("Tabler", new ScriptResource {
                Location = new UrlResourceLocation("https://cdn.jsdelivr.net/npm/@tabler/core@1.0.0-beta17/dist/js/tabler.min.js"),
                Dependencies = new[] { "TablerCss" }
            });
            config.Resources.Register("Styles", new StylesheetResource() {
                Location = new UrlResourceLocation("~/Resources/style.css")
            });
        }

        public void ConfigureServices(IDotvvmServiceCollection options) {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
        }
    }
}

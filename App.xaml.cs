using System.Windows;
using PRK2.Models;
using PRK2.Services;

namespace PRK2 {
    public partial class App : Application {
        public static User CurrentUser = new User();
        public static string Language = "UA";

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SettingsService.Load();
        }
    }
}
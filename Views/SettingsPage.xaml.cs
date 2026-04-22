using System.Windows;
using System.Windows.Controls;
using PRK2.Services;

namespace PRK2.Views {
    public partial class SettingsPage : Page {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            // Мова
            if (LanguageComboBox.SelectedIndex == 0)
                SettingsService.ChangeLanguage("UA");
            else
                SettingsService.ChangeLanguage("EN");

            // Тема
            if (ThemeComboBox.SelectedIndex == 0)
                SettingsService.ChangeTheme("Light");
            else
                SettingsService.ChangeTheme("Dark");

            MessageBox.Show("Налаштування застосовано");
        }
    }
}
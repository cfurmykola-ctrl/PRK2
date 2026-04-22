using System.Windows;
using System.Windows.Controls;
using PRK2.Views;

namespace PRK2 {
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();

            // 👉 стартова сторінка
            MainFrame.Navigate(new MainPage());
        }

        // 🏠 Головна
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        // 📋 Список тем
        private void List_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListPage());
        }

        // ⚙️ Налаштування
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingsPage());
        }

        // 🔙 Назад
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        // ❌ Вихід
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
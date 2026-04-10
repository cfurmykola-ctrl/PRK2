using System.Windows;
using KnowledgeMap.Views;
using PRK2.Views;

namespace KnowledgeMap {
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
            StatusText.Text = "Головна сторінка";
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListPage());
            StatusText.Text = "Список тем";
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Views.SettingsPage());
            StatusText.Text = "Налаштування";
        }
    }
}
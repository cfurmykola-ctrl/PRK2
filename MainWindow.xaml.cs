using System.Windows;
using PRK2.Views;

namespace PRK2 {
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
            MainFrame.Navigate(new ListPage((MainPage)MainFrame.Content));
            StatusText.Text = "Список тем";
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingsPage());
            StatusText.Text = "Налаштування";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
                StatusText.Text = "Повернення назад";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

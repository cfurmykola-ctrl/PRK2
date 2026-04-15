using System;
using System.Windows;
using System.Windows.Controls;
using PRK2.Models;

namespace PRK2.Views {
    public partial class MainPage : Page {
        public User CurrentUser { get; set; }

        public MainPage()
        {
            InitializeComponent();

            DataContext = App.CurrentUser;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginBox.Text;
                string password = PasswordBox.Password;

                if (login == "teacher" && password == "123")
                {
                    App.CurrentUser.IsAdmin = true;
                    MessageBox.Show("Ви увійшли як викладач");
                }
                else
                {
                    App.CurrentUser.IsAdmin = false;
                    MessageBox.Show("Невірний логін або пароль. Режим студента.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}

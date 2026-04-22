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

            DataContext = App.CurrentUser as User;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login))
            {
                ErrorText.Text = "Введіть логін";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ErrorText.Text = "Введіть пароль";
                return;
            }

            ErrorText.Text = "";

            bool isTeacher = login == "teacher" && password == "123";

            App.CurrentUser.IsAdmin = isTeacher;

            if (isTeacher)
                MessageBox.Show("Ви увійшли як викладач");
            else
                MessageBox.Show("Невірний логін або пароль. Доступний тільки режим студента.");
        }
    }
}
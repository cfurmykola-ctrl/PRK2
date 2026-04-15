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
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            bool isTeacher = login == "teacher" && password == "123";

            App.CurrentUser.IsAdmin = isTeacher;

            MessageBox.Show(isTeacher
                ? "Ви увійшли як викладач"
                : "Режим студента");
        }
    }
}

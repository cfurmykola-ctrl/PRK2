using System.Windows;
using System.Windows.Controls;

namespace KnowledgeMap.Views {
    public partial class MainPage : Page {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = "Ти ввів: " + InputBox.Text;
        }
    }
}
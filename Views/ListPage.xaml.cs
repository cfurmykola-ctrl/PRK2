using System.Windows;
using System.Windows.Controls;
using PRK2.Models;
using PRK2.ViewModels;

namespace PRK2.Views {
    public partial class ListPage : Page {
        private MainViewModel vm;

        public ListPage()
        {
            InitializeComponent();

            vm = new MainViewModel();
            DataContext = vm;

            ApplyRoleAccess();
        }

        private void ApplyRoleAccess()
        {
            bool isAdmin = App.CurrentUser.IsAdmin;

            if (NewTopicUkBox != null)
                NewTopicUkBox.IsEnabled = isAdmin;

            if (NewTopicEnBox != null)
                NewTopicEnBox.IsEnabled = isAdmin;

            if (NewSubtopicUkBox != null)
                NewSubtopicUkBox.IsEnabled = isAdmin;

            if (NewSubtopicEnBox != null)
                NewSubtopicEnBox.IsEnabled = isAdmin;

            if (EditTitleUkBox != null)
                EditTitleUkBox.IsReadOnly = !isAdmin;

            if (EditTitleEnBox != null)
                EditTitleEnBox.IsReadOnly = !isAdmin;

            if (EditDescriptionUkBox != null)
                EditDescriptionUkBox.IsReadOnly = !isAdmin;

            if (EditDescriptionEnBox != null)
                EditDescriptionEnBox.IsReadOnly = !isAdmin;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            vm.SelectedTopic = e.NewValue as Topic;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!App.CurrentUser.IsAdmin)
            {
                MessageBox.Show("Тільки викладач може додавати теми.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(NewTopicUkBox.Text) &&
                !string.IsNullOrWhiteSpace(NewTopicEnBox.Text))
            {
                vm.AddTopic(NewTopicUkBox.Text, NewTopicEnBox.Text);
                NewTopicUkBox.Text = "";
                NewTopicEnBox.Text = "";

                if (TopicsTree != null)
                    TopicsTree.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Введіть назву теми українською та англійською.");
            }
        }

        private void AddSubtopic_Click(object sender, RoutedEventArgs e)
        {
            if (!App.CurrentUser.IsAdmin)
            {
                MessageBox.Show("Тільки викладач може додавати підтеми.");
                return;
            }

            if (vm.SelectedTopic == null)
            {
                MessageBox.Show("Спочатку виберіть тему.");
                return;
            }

            if (string.IsNullOrWhiteSpace(NewSubtopicUkBox.Text) ||
                string.IsNullOrWhiteSpace(NewSubtopicEnBox.Text))
            {
                MessageBox.Show("Введіть назву підтеми українською та англійською.");
                return;
            }

            vm.AddSubtopic(vm.SelectedTopic, NewSubtopicUkBox.Text, NewSubtopicEnBox.Text);
            NewSubtopicUkBox.Text = "";
            NewSubtopicEnBox.Text = "";

            if (TopicsTree != null)
                TopicsTree.Items.Refresh();
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!App.CurrentUser.IsAdmin)
            {
                MessageBox.Show("Тільки викладач може редагувати теми.");
                return;
            }

            if (vm.SelectedTopic == null)
            {
                MessageBox.Show("Спочатку виберіть тему.");
                return;
            }

            vm.SaveEdit();

            if (TopicsTree != null)
                TopicsTree.Items.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!App.CurrentUser.IsAdmin)
            {
                MessageBox.Show("Тільки викладач може видаляти теми.");
                return;
            }

            if (vm.SelectedTopic == null)
            {
                MessageBox.Show("Спочатку виберіть тему.");
                return;
            }

            vm.DeleteTopic(vm.SelectedTopic);

            if (TopicsTree != null)
                TopicsTree.Items.Refresh();
        }
    }
}
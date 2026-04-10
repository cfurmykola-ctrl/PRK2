using KnowledgeMap.Models;
using System.Collections.ObjectModel;

namespace KnowledgeMap.ViewModels {
    public class MainViewModel : BaseViewModel {
        public ObservableCollection<Topic> Topics { get; set; }

        private Topic _selectedTopic;
        public Topic SelectedTopic
        {
            get => _selectedTopic;
            set
            {
                _selectedTopic = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            // Тестові дані для першого запуску
            Topics = new ObservableCollection<Topic>
            {
                new Topic
                {
                    Title = "Множини",
                    Description = "Основи теорії множин",
                    Subtopics =
                    {
                        new Topic { Title = "Операції над множинами", Description = "Об'єднання, перетин" }
                    }
                },
                new Topic
                {
                    Title = "Графи",
                    Description = "Теорія графів"
                }
            };
        }
    }
}
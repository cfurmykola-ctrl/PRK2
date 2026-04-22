using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PRK2.Models;
using PRK2.Services;

namespace PRK2.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {
        public ObservableCollection<Topic> Topics { get; set; } = new ObservableCollection<Topic>();
        public ObservableCollection<Topic> FilteredTopics { get; set; } = new ObservableCollection<Topic>();

        private Topic selectedTopic;
        public Topic SelectedTopic
        {
            get { return selectedTopic; }
            set
            {
                selectedTopic = value;

                if (selectedTopic != null)
                {
                    EditTitleUk = selectedTopic.TitleUk;
                    EditTitleEn = selectedTopic.TitleEn;
                    EditDescriptionUk = selectedTopic.DescriptionUk;
                    EditDescriptionEn = selectedTopic.DescriptionEn;
                }

                OnPropertyChanged(nameof(SelectedTopic));
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterTopics();
            }
        }

        private string editTitleUk;
        public string EditTitleUk
        {
            get { return editTitleUk; }
            set
            {
                editTitleUk = value;
                OnPropertyChanged(nameof(EditTitleUk));
            }
        }

        private string editTitleEn;
        public string EditTitleEn
        {
            get { return editTitleEn; }
            set
            {
                editTitleEn = value;
                OnPropertyChanged(nameof(EditTitleEn));
            }
        }

        private string editDescriptionUk;
        public string EditDescriptionUk
        {
            get { return editDescriptionUk; }
            set
            {
                editDescriptionUk = value;
                OnPropertyChanged(nameof(EditDescriptionUk));
            }
        }

        private string editDescriptionEn;
        public string EditDescriptionEn
        {
            get { return editDescriptionEn; }
            set
            {
                editDescriptionEn = value;
                OnPropertyChanged(nameof(EditDescriptionEn));
            }
        }

        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            var data = JsonService.LoadTopics();

            Topics.Clear();

            foreach (var item in data)
                Topics.Add(item);

            FilterTopics();
        }

        private void FilterTopics()
        {
            FilteredTopics.Clear();

            var result = string.IsNullOrWhiteSpace(SearchText)
                ? Topics
                : new ObservableCollection<Topic>(
                    Topics.Where(t =>
                        t.Title != null &&
                        t.Title.ToLower().Contains(SearchText.ToLower())
                    )
                );

            foreach (var item in result)
                FilteredTopics.Add(item);
        }

        public void AddTopic(string titleUk, string titleEn)
        {
            if (!string.IsNullOrWhiteSpace(titleUk) && !string.IsNullOrWhiteSpace(titleEn))
            {
                Topics.Add(new Topic
                {
                    TitleUk = titleUk,
                    TitleEn = titleEn,
                    DescriptionUk = "Новий опис",
                    DescriptionEn = "New description",
                    Subtopics = new System.Collections.Generic.List<Topic>()
                });

                Save();
                FilterTopics();
            }
        }

        public void AddSubtopic(Topic parentTopic, string subtopicTitleUk, string subtopicTitleEn)
        {
            if (parentTopic != null &&
                !string.IsNullOrWhiteSpace(subtopicTitleUk) &&
                !string.IsNullOrWhiteSpace(subtopicTitleEn))
            {
                parentTopic.Subtopics.Add(new Topic
                {
                    TitleUk = subtopicTitleUk,
                    TitleEn = subtopicTitleEn,
                    DescriptionUk = "Новий опис підтеми",
                    DescriptionEn = "New subtopic description",
                    Subtopics = new System.Collections.Generic.List<Topic>()
                });

                Save();
                OnPropertyChanged(nameof(Topics));
                OnPropertyChanged(nameof(FilteredTopics));
                OnPropertyChanged(nameof(SelectedTopic));
            }
        }

        public void DeleteTopic(Topic topic)
        {
            if (topic != null)
            {
                Topics.Remove(topic);
                Save();
                FilterTopics();
            }
        }

        public void SaveEdit()
        {
            if (SelectedTopic != null)
            {
                SelectedTopic.TitleUk = EditTitleUk;
                SelectedTopic.TitleEn = EditTitleEn;
                SelectedTopic.DescriptionUk = EditDescriptionUk;
                SelectedTopic.DescriptionEn = EditDescriptionEn;

                Save();
                FilterTopics();
                OnPropertyChanged(nameof(SelectedTopic));
            }
        }

        private void Save()
        {
            JsonService.SaveTopics(Topics.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
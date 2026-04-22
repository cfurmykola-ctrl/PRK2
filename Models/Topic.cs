using System.Collections.Generic;
using System.ComponentModel;

namespace PRK2.Models {
    public class Topic : INotifyPropertyChanged {
        private string titleUk;
        private string titleEn;
        private string descriptionUk;
        private string descriptionEn;

        // 🇺🇦 Українська
        public string TitleUk
        {
            get => titleUk;
            set
            {
                titleUk = value;
                OnPropertyChanged(nameof(TitleUk));
                OnPropertyChanged(nameof(Title));
            }
        }

        public string DescriptionUk
        {
            get => descriptionUk;
            set
            {
                descriptionUk = value;
                OnPropertyChanged(nameof(DescriptionUk));
                OnPropertyChanged(nameof(Description));
            }
        }

        // 🇬🇧 Англійська
        public string TitleEn
        {
            get => titleEn;
            set
            {
                titleEn = value;
                OnPropertyChanged(nameof(TitleEn));
                OnPropertyChanged(nameof(Title));
            }
        }

        public string DescriptionEn
        {
            get => descriptionEn;
            set
            {
                descriptionEn = value;
                OnPropertyChanged(nameof(DescriptionEn));
                OnPropertyChanged(nameof(Description));
            }
        }

        // 🌍 Автоматичний переклад
        public string Title
        {
            get => App.Language == "EN" ? TitleEn : TitleUk;
        }

        public string Description
        {
            get => App.Language == "EN" ? DescriptionEn : DescriptionUk;
        }

        // 🌳 ПІДТЕМИ (повернули)
        public List<Topic> Subtopics { get; set; } = new List<Topic>();

        // 🔄 ОНОВЛЕННЯ UI
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

            // 🔥 важливо для перекладу підтем
            if (name == nameof(TitleUk) || name == nameof(TitleEn))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));

            if (name == nameof(DescriptionUk) || name == nameof(DescriptionEn))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
        }
    }
}
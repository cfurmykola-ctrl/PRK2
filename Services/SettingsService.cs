using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using PRK2.Models;

namespace PRK2.Services {
    public static class SettingsService {
        private static readonly string path = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "settings.json"
        );

        private static AppSettings currentSettings = new AppSettings();

        public static void Load()
        {
            try
            {
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    AppSettings loaded = JsonSerializer.Deserialize<AppSettings>(json);

                    if (loaded != null)
                        currentSettings = loaded;
                }
            }
            catch
            {
                currentSettings = new AppSettings();
            }

            App.Language = currentSettings.Language;

            ApplyTheme(currentSettings.Theme);
            ApplyLanguage(currentSettings.Language);
        }

        public static void ChangeLanguage(string lang)
        {
            currentSettings.Language = lang;
            App.Language = lang;

            ApplyLanguage(lang);
            Save();
        }

        public static void ChangeTheme(string theme)
        {
            currentSettings.Theme = theme;

            ApplyTheme(theme);
            Save();
        }

        private static void ApplyLanguage(string lang)
        {
            var dict = new ResourceDictionary
            {
                Source = new Uri(
                    lang == "EN"
                        ? "Resources/Strings.en.xaml"
                        : "Resources/Strings.uk.xaml",
                    UriKind.Relative
                )
            };

            ReplaceDictionary("Strings.uk.xaml", "Strings.en.xaml", dict);
        }

        private static void ApplyTheme(string theme)
        {
            var dict = new ResourceDictionary
            {
                Source = new Uri(
                    theme == "Dark"
                        ? "Resources/DarkTheme.xaml"
                        : "Resources/Styles.xaml",
                    UriKind.Relative
                )
            };

            ReplaceDictionary("Styles.xaml", "DarkTheme.xaml", dict);
        }

        private static void ReplaceDictionary(string file1, string file2, ResourceDictionary newDict)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;

            for (int i = 0; i < dictionaries.Count; i++)
            {
                if (dictionaries[i].Source == null)
                    continue;

                string source = dictionaries[i].Source.OriginalString;

                if (source.Contains(file1) || source.Contains(file2))
                {
                    dictionaries[i] = newDict;
                    return;
                }
            }

            dictionaries.Add(newDict);
        }

        private static void Save()
        {
            string json = JsonSerializer.Serialize(currentSettings, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }
    }
}
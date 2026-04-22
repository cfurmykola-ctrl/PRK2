using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PRK2.Models;

namespace PRK2.Services {
    public static class JsonService {
        private static string path = Path.Combine(
            System.AppDomain.CurrentDomain.BaseDirectory,
            "Data",
            "topics.json"
        );

        // 📥 Завантаження
        public static List<Topic> LoadTopics()
        {
            if (!File.Exists(path))
                return new List<Topic>();

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Topic>>(json);
        }

        // 💾 ЗБЕРЕЖЕННЯ
        public static void SaveTopics(List<Topic> topics)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // красивий JSON
            };

            string json = JsonSerializer.Serialize(topics, options);
            File.WriteAllText(path, json);
        }
    }
}
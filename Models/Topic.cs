using System.Collections.Generic;

namespace KnowledgeMap.Models {
    public class Topic {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Topic> Subtopics { get; set; } = new List<Topic>();
    }
}
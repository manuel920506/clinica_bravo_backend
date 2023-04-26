using clinica_bravo_backend.Entities; 

namespace clinica_bravo_backend.DTOs {
    public class TopicDTO { 
        public string Name { get; set; } 
        public string? Photo { get; set; }

        public List<SubTopicDTO>? SubTopics { get; set; }

        public int Order { get; set; }
    }
}

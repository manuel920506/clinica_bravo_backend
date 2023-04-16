using clinica_bravo_backend.Entities; 

namespace clinica_bravo_backend.DTOs {
    public class TopicDTO {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string URL { get; set; }

        public List<SubTopicDTO> SubTopics { get; set; }

        public int Order { get; set; }
    }
}

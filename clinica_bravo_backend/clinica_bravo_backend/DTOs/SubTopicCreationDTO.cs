using System.ComponentModel.DataAnnotations;

namespace clinica_bravo_backend.DTOs {
    public class SubTopicCreationDTO {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string URL { get; set; }
        public int Order { get; set; }
    }
}

using clinica_bravo_backend.Entities;
using clinica_bravo_backend.Validations;
using System.ComponentModel.DataAnnotations;

namespace clinica_bravo_backend.DTOs {
    public class SubTopicDTO {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string URL { get; set; }
        public int Order { get; set; }
    }
}

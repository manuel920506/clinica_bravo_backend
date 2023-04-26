using clinica_bravo_backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;  
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using clinica_bravo_backend.Utils;
using clinica_bravo_backend.Validations;

namespace clinica_bravo_backend.DTOs {
    public class TopicCreationDTO {
        [Required(ErrorMessage = "The field {0} is required")]
        [FirstCapitalLetter]
        public string Name { get; set; } 
        public IFormFile? Photo { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<SubTopicCreationDTO>>))]
        public List<SubTopicCreationDTO>? SubTopics { get; set; }

        public int Order { get; set; } 
    }
}

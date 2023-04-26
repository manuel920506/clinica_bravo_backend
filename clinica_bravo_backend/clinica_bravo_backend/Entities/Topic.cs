using clinica_bravo_backend.Validations;
using System.ComponentModel.DataAnnotations;

namespace clinica_bravo_backend.Entities {
    public class Topic : IValidatableObject {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")] 
        [FirstCapitalLetter]
        public string Name { get; set; }  

        [Url]
        public string? Photo { get; set; }

        public int Order { get; set; }

        public List<SubTopic>? SubTopics { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (!string.IsNullOrEmpty(Name)) {
                var firstLetter = Name[0].ToString();

                if (firstLetter != firstLetter.ToUpper()) {
                    yield return new ValidationResult("The first letter must be uppercase",
                        new string[] { nameof(Name) });
                }
            }
        }
    }
}

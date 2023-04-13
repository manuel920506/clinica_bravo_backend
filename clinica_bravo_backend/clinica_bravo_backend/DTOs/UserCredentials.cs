﻿using System.ComponentModel.DataAnnotations;

namespace clinica_bravo_backend.DTOs {
    public class UserCredentials {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

﻿namespace clinica_bravo_backend.DTOs {
    public class AuthenticationResponse {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

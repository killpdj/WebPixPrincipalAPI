﻿namespace WebPixPrincipalRepository.Entity
{
    public class Usuario : Base
    {
        public string Login { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string VAdmin { get; set; }
        public string Avatar { get; set; }
    }
}

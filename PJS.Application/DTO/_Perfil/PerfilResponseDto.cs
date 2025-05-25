using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Application.DTO._Usuario._Perfil
{
    public class PerfilResponseDto
    {
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? FotoUrl { get; set; }
        public UsuarioResponseDto? Usuario { get; set; }
    }
}
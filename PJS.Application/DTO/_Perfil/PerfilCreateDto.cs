using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.DTO._Usuario;

namespace PJS.Application.DTO._Perfil
{
    public class PerfilCreateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }
        public string? FotoUrl { get; set; }
        [Required(ErrorMessage = "O id do usuário é obrigatório.")]
        public Guid UsuarioId { get; set; }
        [Required(ErrorMessage = "O id do nivel é obrigatório.")]
        public Guid NivelId { get; set; }
    }
}
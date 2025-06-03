using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Application.DTO._Usuario
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }
    }
}
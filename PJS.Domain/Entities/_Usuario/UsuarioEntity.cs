using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;

namespace PJS.Domain.Entities._Usuario
{
    public class UsuarioEntity : BaseEntity
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(255, ErrorMessage = "Hash da senha inválido")]
        public string? SenhaHash { get; private set; }

        protected UsuarioEntity() { }

        public UsuarioEntity(string email, string senhaHash) : base()
        {
            Email = email;
            SenhaHash = senhaHash;
        }

        public void AlterarSenha(string novaSenhaHash)
        {
            SenhaHash = novaSenhaHash;
            MarcarComoAtualizado();
        }
    }
}
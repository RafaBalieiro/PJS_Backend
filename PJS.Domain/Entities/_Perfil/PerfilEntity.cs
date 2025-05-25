using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;
using PJS.Domain.Entities._Usuario;

namespace PJS.Domain.Entities._Perfil
{
    public class PerfilEntity : BaseEntity
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }
        public string? FotoUrl { get; set; }
        [Required(ErrorMessage = "O id do usuário é obrigatório.")]
        public Guid UsuarioId { get; set; }
        public UsuarioEntity? Usuario { get; set; }

        protected PerfilEntity() { }

        public PerfilEntity(string nome, DateTime dataNascimento, Guid usuarioId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            UsuarioId = usuarioId;
        }
    }
}
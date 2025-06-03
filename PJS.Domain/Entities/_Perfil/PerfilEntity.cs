using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Assoc._ConquistaPerfilAssoc;
using PJS.Domain.Entities._Base;
using PJS.Domain.Entities._Nivel;
using PJS.Domain.Entities._Usuario;

namespace PJS.Domain.Entities._Perfil
{
    public class PerfilEntity : BaseEntity
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; private set; }
        public string? FotoUrl { get; private set; }
        [Required(ErrorMessage = "O id do usuário é obrigatório.")]
        public Guid UsuarioId { get; private set; }
        public UsuarioEntity? Usuario { get; private set; }
        public ICollection<ConquistaPerfilAssocEntity> Conquistas { get; private set; }
        
        [Required(ErrorMessage = "O id do nivel é obrigatorio!")]
        public Guid NivelId { get; private set; }
        public NivelEntity Nivel { get; private set; }
        protected PerfilEntity() { }

        public PerfilEntity(string nome, DateTime dataNascimento, Guid usuarioId, Guid nivelId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            UsuarioId = usuarioId;
            Conquistas = new List<ConquistaPerfilAssocEntity>();
            NivelId = nivelId;
        }
    }
}
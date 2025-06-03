using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;
using PJS.Domain.Entities._Conquista;
using PJS.Domain.Entities._Perfil;

namespace PJS.Domain.Entities._Assoc._ConquistaPerfilAssoc
{
    public class ConquistaPerfilAssocEntity : BaseEntity
    {
        [Required(ErrorMessage = "O id da conquista é obrigatório!")]
        public Guid ConquistaId { get; private set; }
        public ConquistaEntity Conquista { get; private set; }

        [Required(ErrorMessage = "O id do perfil é obrigatório")]
        public Guid PerfilId { get; private set; }

        public PerfilEntity Perfil { get; private set; }

        protected ConquistaPerfilAssocEntity() { }

        public ConquistaPerfilAssocEntity(Guid conquistaId, Guid perfilId)
        {
            ConquistaId = conquistaId;
            PerfilId = perfilId;
        }
    }
}
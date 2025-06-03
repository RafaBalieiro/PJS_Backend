using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Assoc._ConquistaPerfilAssoc;
using PJS.Domain.Entities._Base;
using PJS.Domain.Entities._Perfil;

namespace PJS.Domain.Entities._Conquista
{
    public class ConquistaEntity : BaseEntity
    {
        [Required(ErrorMessage = "O nome da Conquista é obrigatório!")]
        [MaxLength(50)]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "A descrição da conquista é obrigatória!")]
        [MaxLength(150)]
        public string Descricao { get; private set; }
        [Required(ErrorMessage = "O xp bonus é obrigatório!")]
        public int XpBonus { get; private set; }

        [Required(ErrorMessage = "O logo é obrigatório!")]
        public byte[] Logo { get; set; }
        public ICollection<ConquistaPerfilAssocEntity> Perfis { get; private set; }

        protected ConquistaEntity() { }

        public ConquistaEntity(string nome, string descricao, int xpBonus, byte[] logo)
        {
            Nome = nome;
            Descricao = descricao;
            XpBonus = xpBonus;
            Logo = logo;
            Perfis = new List<ConquistaPerfilAssocEntity>();
        }
    }
}
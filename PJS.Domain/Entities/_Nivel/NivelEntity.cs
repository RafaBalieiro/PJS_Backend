using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;

namespace PJS.Domain.Entities._Nivel
{
    public class NivelEntity : BaseEntity
    {
        [Required(ErrorMessage = "O nome do nível é obrigatório")]
        public int Nivel { get; private set; }
        [Required(ErrorMessage = "A quantidade de XP do nível é obrigatória!")]
        public int QuantidadeXp { get; private set; }
        protected NivelEntity() { }

        public NivelEntity(int nivel, int quantidadeXp)
        {
            Nivel = nivel;
            QuantidadeXp = quantidadeXp;
        }

    }
}
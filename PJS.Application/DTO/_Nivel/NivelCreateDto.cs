using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Application.DTO._Nivel
{
    public class NivelCreateDto
    {
        [Required(ErrorMessage = "O nome do nível é obrigatório")]
        public int Nivel { get;  set; }
        [Required(ErrorMessage = "A quantidade de XP do nível é obrigatória!")]
        public int QuantidadeXp { get; set; }
    }
}
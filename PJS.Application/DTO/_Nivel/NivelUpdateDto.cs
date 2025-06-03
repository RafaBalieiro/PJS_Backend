using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Application.DTO._Nivel
{
    public class NivelUpdateDto
    {
        [Required(ErrorMessage = "O id do nivel é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O nome do nível é obrigatório")]
        public int Nivel { get; set; }
        [Required(ErrorMessage = "A quantidade de XP do nível é obrigatória!")]
        public int QuantidadeXp { get; set; }
    }
}
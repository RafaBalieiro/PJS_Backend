using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Application.DTO._Conquista
{
    public class ConquistaCreateDto
    {
        [Required(ErrorMessage = "O nome da Conquista é obrigatório!")]
        [MaxLength(50)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "A descrição da conquista é obrigatória!")]
        [MaxLength(150)]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "O xp bonus é obrigatório!")]
        public int XpBonus { get; set; }

        [Required(ErrorMessage = "O logo é obrigatório!")]
        public byte[] Logo { get; set; }
    }
}
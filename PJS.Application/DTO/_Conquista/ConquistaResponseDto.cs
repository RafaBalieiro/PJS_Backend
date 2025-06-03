using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Application.DTO._Conquista
{
    public class ConquistaResponseDto
    {
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public int XpBonus { get; private set; }
        public byte[]? Logo { get; set; }
    }
}
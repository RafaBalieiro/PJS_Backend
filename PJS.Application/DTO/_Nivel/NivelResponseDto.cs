using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Application.DTO._Nivel
{
    public class NivelResponseDto
    {
        public Guid Id { get; set; }
        public int Nivel { get; private set; }
        public int QuantidadeXp { get; private set; }
    }
}
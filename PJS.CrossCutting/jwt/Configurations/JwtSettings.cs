using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.CrossCutting.jwt.Configurations
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInMinutes { get; set; }
    }
}
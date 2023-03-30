using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Serialization
{
    public class Faturamento
    {
        [JsonProperty("dia")]
        public int Dia { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }

    }
}

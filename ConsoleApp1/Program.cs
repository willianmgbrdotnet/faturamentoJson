using ConsoleApp1.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, 
// faça um programa, na linguagem que desejar, que calcule e retorne:
// • O menor valor de faturamento ocorrido em um dia do mês;
// • O maior valor de faturamento ocorrido em um dia do mês;
// • Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.
// IMPORTANTE:
// a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
// b) Podem existir dias sem faturamento, como nos finais de semana e feriados. 
// Estes dias devem ser ignorados no cálculo da média;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\dados.json");

            List<Faturamento> faturamento = JsonConvert.DeserializeObject<List<Faturamento>>(json);

            //Console.WriteLine(json);

            Console.ReadKey();

        }
        
    }
}

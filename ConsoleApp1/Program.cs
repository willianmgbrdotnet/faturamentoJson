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

            List<Faturamento> faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(json);

            // Encontrando o maior valor da propriedade Valor
            double maiorValor = 0;
            foreach (Faturamento faturamento in faturamentos)
            {
                if (faturamento.Valor > maiorValor)
                {
                    maiorValor = faturamento.Valor;
                }
            }
            Console.WriteLine("O maior valor faturado é: " + maiorValor);

            // Encontrando o menor valor da propriedade Valor
            double menorValor = maiorValor;
            foreach (Faturamento faturamento in faturamentos)
            {
                if (faturamento.Valor < menorValor && faturamento.Valor > 0)
                {
                    menorValor = faturamento.Valor;
                }
            }
            Console.WriteLine("O menor valor é: " + menorValor);

            // Calculando quantos dias uteis de Faturamento.
            int count = 0;
            foreach (Faturamento faturamento in faturamentos)
            {
                if (faturamento.Valor > 0)
                {
                    count++;
                }
            }
            var diasValidos = count;
            //Console.WriteLine("Tivemos faturamento em {0} dia(s) úteis", diasValidos);

            // Somando os valores maiores que 0
            double soma = 0;
            foreach (Faturamento faturamento in faturamentos)
            {
                if (faturamento.Valor > 0)
                {
                    soma += faturamento.Valor;
                }
            }
            //Console.WriteLine("$ {0} foi o faturamento total mensal", soma);

            //MEDIA
            double media = soma / diasValidos;
            //Console.WriteLine("A média de Faturamento mensal é $ {0}", media);

            // Calculando quantos dias uteis de Faturamento acima da Media mensal.
            int acimaDaMedia = 0;
            foreach (Faturamento faturamento in faturamentos)
            {
                if (faturamento.Valor > media)
                {
                    acimaDaMedia++;
                }
            }
            Console.WriteLine("Tivemos {0} dia(s) de Faturamento acima da Média Mensal", acimaDaMedia);

        }

    }
}

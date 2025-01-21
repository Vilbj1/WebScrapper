using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScrapper
{
    class Program
    {
        static void Main (string[] args)
        {
            // Envia um request de get para weather.com
            String url = "https://weather.com/pt-BR/clima/hoje/l/eeae1b226a57b29772e765cc1bcf6c44edca9f0aaed4b88eb83e263d939c9745cf8e84592f582afcedb0d1d44cad7cb4";          
            var httpClient = new HttpClient ();
            var html = httpClient.GetStringAsync (url).Result;           
            var htmlDocument = new HtmlDocument ();
            htmlDocument.LoadHtml (html);

            // Get da temperatura
            var temperaturaElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--zUBSz']");
            // Busca exatamente o numero da temperatura, ao invés de trazer todo o texto contido na classe.
            var temperature = temperaturaElement.InnerText.Trim();
            Console.WriteLine("Temperatura: " + temperature);

            // Get para condições do dia
            var condicaoElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue---VS-k']");          
            var condicao = condicaoElement.InnerText.Trim();
            Console.WriteLine("Condição: " + condicao);

            // Get para lugar
            var localElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--yub4l']");
            var local = localElement.InnerText.Trim();
            Console.WriteLine("Local: " + local);

            // Novo request para proximos dias da semana
            String url2 = "https://weather.com/pt-BR/clima/fimdesemana/l/eeae1b226a57b29772e765cc1bcf6c44edca9f0aaed4b88eb83e263d939c9745cf8e84592f582afcedb0d1d44cad7cb4";
            var httpClient2 = new HttpClient();
            var html2 = httpClient2.GetStringAsync(url2).Result;
            var htmlDocument2 = new HtmlDocument();
            htmlDocument2.LoadHtml(html2);

            Console.WriteLine("------------------------------------");
            //Get para sexta
            var sextaElement = htmlDocument2.DocumentNode.SelectSingleNode("(//span[@class='DetailsSummary--highTempValue--VHKaO'])[1]");
            var sexta = sextaElement.InnerText.Trim();
            var sextaCondition = htmlDocument2.DocumentNode.SelectSingleNode("(//span[@class='DetailsSummary--extendedData--eJzhb'])[1]");
            var sexta2 = sextaCondition.InnerText.Trim();
            Console.WriteLine("Sexta feira: " + sexta);
            Console.WriteLine("Condição: "+ sexta2);

            Console.WriteLine("------------------------------------");
            //Get para sabado
            var sabadoElement = htmlDocument2.DocumentNode.SelectSingleNode("(//span[@class='DetailsSummary--highTempValue--VHKaO'])[2]");
            var sabado = sabadoElement.InnerText.Trim();
            var sabadoCondition = htmlDocument2.DocumentNode.SelectSingleNode("(//span[@class='DetailsSummary--extendedData--eJzhb'])[2]");
            var sabado2 = sabadoCondition.InnerText.Trim();
            Console.WriteLine("sabado: " + sabado);
            Console.WriteLine("Condição: " + sabado2);

            Console.WriteLine("------------------------------------");
            //Get para domingo         
            var domingoElement = htmlDocument2.DocumentNode.SelectSingleNode("(//span[@class='DetailsSummary--highTempValue--VHKaO'])[3]");
            var domingo = domingoElement.InnerText.Trim();
            var domingoCondition = htmlDocument2.DocumentNode.SelectSingleNode("(//span[@class='DetailsSummary--extendedData--eJzhb'])[3]");
            var domingo2 = domingoCondition.InnerText.Trim();
            Console.WriteLine("domingo: " + domingo);
            Console.WriteLine("Condição: " + domingo2);
        }
    }


}
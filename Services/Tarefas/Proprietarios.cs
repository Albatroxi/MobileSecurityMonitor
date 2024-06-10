using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSecurityMonitor.Services.Tarefas
{
    public class Proprietarios
    {
        public async Task criaProprietario(string cProprietario)
        {
            // URL da API
            string apiUrl_regPropt = $"https://api.troxsistemas.com.br/api/proprietarios/criarNovo";

            // Cria uma instância de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Faz a chamada GET para a URL da API
                    HttpResponseMessage responseRegisterDisp = await client.GetAsync(apiUrl_regPropt);

                    var newPropt = new
                    {
                        nome = "",
                        cpf = cProprietario
                    };


                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(newPropt),
                        Encoding.UTF8, "application/json");

                    var responsRegister = await client.PostAsync(apiUrl_regPropt, content);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Erro na requisição HTTP:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

using MobileSecurityMonitor.Models.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSecurityMonitor.Services.Tarefas
{
    public class ProprietariosServices
    {
        public async Task carregaProprietarios()
        {
            // URL da API
            string apiUrl = "https://api.troxsistemas.com.br/api/proprietarios/obterTodos";

            // Cria uma instância de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Faz a chamada GET para a URL da API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Verifica se a chamada foi bem-sucedida
                    response.EnsureSuccessStatusCode();

                    // Lê o conteúdo da resposta como string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Desserializa a string JSON em uma lista de objetos User
                    List<Proprietarios> propts = JsonConvert.DeserializeObject<List<Proprietarios>>(responseBody);

                    // Exibe os usuários obtidos
                    Console.WriteLine("Usuários obtidos da API:");
                    foreach (var proprietariosInfos in propts)
                    {
                        Console.WriteLine("CÓDIGO: " + proprietariosInfos.codigo + " NOME: " + proprietariosInfos.nome + " CPF: " + proprietariosInfos.cpf);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Erro na requisição HTTP:");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public async Task checkProprietarios()
        {
            // URL da API
            string apiUrl = "https://api.troxsistemas.com.br/api/proprietarios/obterTodos";

            // Cria uma instância de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Faz a chamada GET para a URL da API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Verifica se a chamada foi bem-sucedida
                    response.EnsureSuccessStatusCode();

                    // Lê o conteúdo da resposta como string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Desserializa a string JSON em uma lista de objetos User
                    List<Proprietarios> propts = JsonConvert.DeserializeObject<List<Proprietarios>>(responseBody);

                    // Exibe os usuários obtidos
                    Console.WriteLine("Usuários obtidos da API:");
                    foreach (var proprietariosInfos in propts)
                    {
                        Console.WriteLine("CÓDIGO: " + proprietariosInfos.codigo + " NOME: " + proprietariosInfos.nome + " CPF: " + proprietariosInfos.cpf);
                    }
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

using MobileSecurityMonitor.Models.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSecurityMonitor.Services.Tarefas
{
    public class Localizacao
    {
        public async Task obterLocalizacao(string imeiINFO)
        {


            // URL da API para criar um novo usuário
            string apiUrl = "https://api.troxsistemas.com.br/api/localizacoes/criarNova";


            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                // Cria uma instância do objeto User que você deseja inserir
                Localizacoes newLocation = new Localizacoes
                {
                    lon = location.Longitude,
                    lat = location.Latitude,
                    c_imei = imeiINFO,
                    registro = DateTime.Now
                };

                // Serializa o objeto User em uma string JSON
                string jsonContent = JsonConvert.SerializeObject(newLocation);

                // Cria um objeto StringContent usando a string JSON
                StringContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Faz a chamada POST para a URL da API
                        HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);

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
}

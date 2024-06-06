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

            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    // Cria uma instância do objeto User que você deseja inserir
                    Localizacoes newLocation = new Localizacoes
                    {
                        lon = location.Longitude,
                        lat = location.Latitude,
                        c_imei = imeiINFO

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

                            // Verifica o status code da resposta
                            if (response.IsSuccessStatusCode)
                            {
                                // Lê o conteúdo da resposta como string
                                string responseBody = await response.Content.ReadAsStringAsync();


                                /*
                                // Desserializa a string JSON em um objeto User
                                Localizacoes createdLocation = JsonConvert.DeserializeObject<Localizacoes>(responseBody);

                                // Exibe os dados do usuário criado
                                Console.WriteLine("Usuário criado na API:");
                                Console.WriteLine("ID: " + createdLocation.id);
                                Console.WriteLine("LONG: " + createdLocation.lon);
                                Console.WriteLine("LAT: " + createdLocation.lat);
                                Console.WriteLine("C_IMEI: " + createdLocation.c_imei);
                                */

                            }
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("Erro na requisição HTTP:");
                            Console.WriteLine(e.Message);
                        }
                    }
                    //Console.WriteLine("IMEI LOCATION: " + imeiINFO);
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                }
            }
            else
            {
                Console.WriteLine("Permissão para acessar a localização foi negada");
            }
        }
    }
}

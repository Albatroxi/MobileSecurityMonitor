
using MobileSecurityMonitor.Models.Rest;
using Newtonsoft.Json;
using System.Text;

namespace MobileSecurityMonitor.Services.Tarefas
{
    public class Dispositivo 
    {
        public async Task obterIMEi()
        {
            var meuValor = await SecureStorage.GetAsync("IMEI");

            Console.WriteLine("IMEI GUARDADO RECUPERADO");

            await checkDispositivo(meuValor);

        }

        public async Task checkDispositivo(string IMEIdisp)
        {
            string imei = IMEIdisp;
            // URL da API
            string apiUrl = $"https://api.troxsistemas.com.br/api/dispositivos/obterPor{imei}";

            // Cria uma instância de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Faz a chamada GET para a URL da API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Verifica se a chamada foi bem-sucedida
                    //response.EnsureSuccessStatusCode();

                    // Verifica o status code da resposta
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("EXISTE IMEI JÁ");

                        var teste = new Localizacao();

                        await teste.obterLocalizacao(IMEIdisp);
                    }

                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Lê o conteúdo da resposta como string
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Desserializa a string JSON em um objeto User
                        Dispositivos disP = JsonConvert.DeserializeObject<Dispositivos>(responseBody);

                        /*
                        // Exibe os dados do usuário obtido
                        Console.WriteLine("Dispositivos obtido da API:");
                        Console.WriteLine("IMEI: " + disP.imei);
                        Console.WriteLine("MODELO: " + disP.modelo);
                        Console.WriteLine("FABRICANTE: " + disP.fabricante);
                        Console.WriteLine("PLATAFORMA: " + disP.plataforma);
                        Console.WriteLine("TIPO: " + disP.tipo);
                        Console.WriteLine("CÓD. PROPRIETÁRIO: " + disP.cproprietario);
                        */

                        Console.WriteLine("NAO POSSUI CADASTRO O DISPOSITIVO");
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

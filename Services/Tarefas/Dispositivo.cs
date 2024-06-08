
using Microsoft.Maui.Controls.PlatformConfiguration;
using MobileSecurityMonitor.Models.Rest;
using MobileSecurityMonitor.Pages;
using Newtonsoft.Json;
using System.Text;

namespace MobileSecurityMonitor.Services.Tarefas
{
    public class Dispositivo 
    {
        public async Task obterIMEi()
        {
            var meuIMEI = await SecureStorage.GetAsync("IMEI");
            var meuCPF = await SecureStorage.GetAsync("CPF");

            int.TryParse(meuCPF, out int cpfInt);

            //Console.WriteLine("IMEI GUARDADO RECUPERADO");
            //Console.WriteLine("IMEI: " + meuValor);

            await checkAndRegister(meuIMEI, cpfInt);

        }

        public async Task checkAndRegister(string IMEIdisp, int cProprietario)
        {
            var meuValor = await SecureStorage.GetAsync("IMEI");
            var meuCPF = await SecureStorage.GetAsync("CPF");

            string imei = IMEIdisp;
            int cpf = cProprietario;
            // URL da API
            string apiUrl_checkDisp = $"https://api.troxsistemas.com.br/api/dispositivos/obterPor{imei}";
            string apiUrl_regDisp = $"https://api.troxsistemas.com.br/api/dispositivos/criarNovo";
            string apiUrl_checkCPF = $"https://api.troxsistemas.com.br/api/proprietarios/obterPor{cpf}";

            {
                // Cria uma instância de HttpClient
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Faz a chamada GET para a URL da API
                        HttpResponseMessage responseCheck = await client.GetAsync(apiUrl_checkDisp);
                        HttpResponseMessage responseRegisterDisp = await client.GetAsync(apiUrl_regDisp);
                        HttpResponseMessage responsecheckCPF = await client.GetAsync(apiUrl_checkCPF);

                        // Verifica se a chamada foi bem-sucedida
                        //response.EnsureSuccessStatusCode();

                        // Verifica o status code da resposta
                        if (responseCheck.IsSuccessStatusCode)
                        {
                            //Console.WriteLine("EXISTE IMEI JÁ");

                            var localiza = new Localizacao();

                            await localiza.obterLocalizacao(IMEIdisp);
                        }

                        if (responsecheckCPF.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            Console.WriteLine("SEM CPF");
                        }



                        var newDisp = new
                        {
                            imei = meuValor,
                            modelo = DeviceInfo.Current.Model,
                            fabricante = DeviceInfo.Current.Manufacturer,
                            plataforma = DeviceInfo.Current.Platform.ToString(),
                            tipo = DeviceInfo.Current.DeviceType.ToString(),
                            cproprietario = cProprietario


                        };

                        var newProprt = new
                        {
                            codigo = cProprietario,
                            nome = "",
                            cpf = meuCPF

                        };

                        var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(newDisp),
                            Encoding.UTF8,"application/json");

                        var responsRegister = await client.PostAsync(apiUrl_regDisp, content);


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

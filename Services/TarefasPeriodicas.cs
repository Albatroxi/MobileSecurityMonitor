using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSecurityMonitor.Services
{
    public class TarefasPeriodicas
    {
        private CancellationTokenSource _cts;
        public async Task IniciarTarefasPeriodicas(CancellationToken token)
        {
            //var hourday = new Services.Tarefas.Data_Hora();
            var infoDetals = new Services.Tarefas.Dispositivo();
            var infoLocals = new Services.Tarefas.Localizacao();

            var meuIMEI = await SecureStorage.GetAsync("IMEI");


            while (!token.IsCancellationRequested)
            {
                infoLocals.obterLocalizacao(meuIMEI);



                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(300), token);
                }
                catch (TaskCanceledException)
                {
                    // Tarea cancelada
                    break;
                }
            }
        }

        public void StopPeriodicTask()
        {
            _cts?.Cancel();
        }
    }
}

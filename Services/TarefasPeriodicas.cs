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
            var hourday = new Services.Tarefas.Data_Hora();
            var infoDetals = new Services.Tarefas.Dispositivo();


            while (!token.IsCancellationRequested)
            {
                hourday.datahora();
                await infoDetals.obterIMEi();
                //await infoDetals.obterDetalhes();



                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(5), token);
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

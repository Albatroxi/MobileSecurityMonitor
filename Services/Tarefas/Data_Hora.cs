using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSecurityMonitor.Services.Tarefas
{
    public class Data_Hora
    {
        public string datahora()
        {
            // INFORMAÇÕES DE DATA E HORA
            //Console.WriteLine("DATA E HORA ATUAL: ", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
            Console.WriteLine("DATA E HORA ATUAL " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

            return null; ;
        }
    }
}

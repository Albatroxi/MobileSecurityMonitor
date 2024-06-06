using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSecurityMonitor.Models.Rest
{
    public class Dispositivos
    {
        public string imei { get; set; }
        public string modelo { get; set; }
        public string fabricante { get; set; }
        public string plataforma { get; set; }
        public string tipo { get; set; }

        public int cproprietario { get; set; }
    }
}

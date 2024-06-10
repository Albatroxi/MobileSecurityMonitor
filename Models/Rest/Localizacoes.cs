using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileSecurityMonitor.Models.Rest
{
    public class Localizacoes
    {
        public int id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        [Key]
        public string c_imei { get; set; }

        public DateTime registro { get; set; }
    }
}

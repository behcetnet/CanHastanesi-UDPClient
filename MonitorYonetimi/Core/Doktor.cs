using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitorYonetimi.Core
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string DoktorAdi { get; set; }
        public string BolumAdi { get; set; }
        public string IP { get; set; }
        public string Detay { get; set; }
    }
}

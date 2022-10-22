using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonitorYonetimi.Core
{
    [Table("DoktorMap")]
    public class Doktor
    {
        [Key]
        public int DoktorId { get; set; }
        public string DoktorAdi { get; set; }
        public string IP { get; set; }

        public static Doktor Make(int _id, string _adi, string _ip)
        {
            Doktor d = new Doktor();
            d.DoktorId = _id;
            d.DoktorAdi = _adi;
            d.IP = _ip;

            return d;
        }
    }
}

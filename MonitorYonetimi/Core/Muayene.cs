using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorYonetimi.Core
{
    public class Muayene
    {
        public int DoktorId { get; set; }
        public int SiraNo { get; set; }
        public string DoktorAdi { get; set; }
        public string HastaAdi { get; set; }
        public string PolkAdi { get; set; }
        public string Mesaj { get; set; }
    }
}

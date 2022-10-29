using System.ComponentModel;

namespace MonitorYonetimi.Core
{
    public class MiscParameter
    {
        [DisplayName("Sağlayıcı"), Description("Veritabanı Sağlayıcısını seçmelisiniz"), Category("Veritabanı")]
        public DBProvider Provider { get; set; }

        [DisplayName("Server IP"), Description("Veritabanı sunucu adresini giriniz. Port girmek isterseniz HOST, PORT şeklinde girmelisiniz."), Category("Veritabanı")]
        public string Host { get; set; }

        [DisplayName("Veritabanı Adı"), Description("Veritabanı adını giriniz."), Category("Veritabanı")]
        public string Name { get; set; }

        [DisplayName("Veritabanı Kullanıcı"), Description("Veritabanı kullanıcı adını giriniz."), Category("Veritabanı")]
        public string Username { get; set; }

        [DisplayName("Veritabanı Şifre"), Description("Veritabanı şifresini giriniz."), Category("Veritabanı")]
        public string Password { get; set; }


        [DisplayName("Alt. Mesaj"), Description("Ekranların alt kısmında gösterilen mesaj. Polk. özelinde mesaj yoksa ve özel durum yoksa mesaj gönderilir."), Category("Genel")]
        public string CommonMessage { get; set; }
    }

    public enum DBProvider
    {
        MSSQL
    }
}

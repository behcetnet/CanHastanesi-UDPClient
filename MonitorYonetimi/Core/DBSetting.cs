using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MonitorYonetimi.Core
{
    public class DBSetting
    {
        [Description("Veritabanı Sağlayıcısını seçmelisiniz"), DisplayName("Sağlayıcı")]
        public DBProvider Provider { get; set; }

        [Description("Veritabanı sunucu adresini giriniz"), DisplayName("Server IP")]
        public string Host { get; set; }

        [Description("Veritabanı port numarasını giriniz. Boş bırakırsanız varsayılan Port kullanılır."), DisplayName("Veritabanı Portu")]
        public string Port { get; set; }

        [Description("Veritabanı adını giriniz."), DisplayName("Veritabanı Adı")]
        public string Name { get; set; }

        [Description("Veritabanı kullanıcı adını giriniz."), DisplayName("Veritabanı Kullanıcı")]
        public string Username { get; set; }
        [Description("Veritabanı şifresini giriniz."), DisplayName("Veritabanı Şifre")]
        public string Password { get; set; }
    }

    public enum DBProvider
    {
        MSSQL
    }
}

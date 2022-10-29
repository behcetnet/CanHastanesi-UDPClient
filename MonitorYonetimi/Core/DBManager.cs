using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorYonetimi.Core
{
    public class DBManager
    {
        SqliteConnection connection;

        private static DBManager instance = null;
        public static DBManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBManager();
                }
                return instance;
            }
        }

        public DBManager()
        {
            var connStr = @"";
            var conn = new SqliteConnectionStringBuilder(connStr)
            {
                DataSource = "data\\main.db",
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = ""
            }.ToString();

            connection = new SqliteConnection(conn);
        }

        public Dictionary<string, string> GetPrefs()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT ParamName, ParamValue FROM Settings ORDER BY ID ASC";

            Dictionary<string, string> prefs = new Dictionary<string, string>();

            using (var reader = command.ExecuteReader())
            {
                string _isValue = "";
                while (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                        _isValue = reader.GetString(1);

                    prefs.Add(reader.GetString(0), _isValue);
                }
            }

            return prefs;
        }

        public string GetPref(string k)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT ParamName, ParamValue FROM Settings WHERE ParamName = @k";
            command.Parameters.AddWithValue("@k", k);

            using (var reader = command.ExecuteReader())
            {
                string _isValue = "";
                if (reader.Read())
                {
                    if (!reader.IsDBNull(1))
                        _isValue = reader.GetString(1);
                }

                return _isValue;
            }
        }

        public void SetPref(string p, string v)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Settings SET ParamValue = @v WHERE ParamName = @p";
            command.Parameters.AddWithValue("@p", p);
            command.Parameters.AddWithValue("@v", v);

            command.ExecuteNonQuery();
        }

        public List<Doktor> DoktorList()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT DoktorId, DoktorAdi, BolumAdi, IPAdres, Mesaj FROM DoktorMap ORDER BY DoktorId ASC";

            List<Doktor> list = new List<Doktor>();

            using (var reader = command.ExecuteReader())
            {
                string _isValue = "";
                while (reader.Read())
                {
                    int i1 = reader.GetOrdinal("DoktorId");
                    int i2 = reader.GetOrdinal("DoktorAdi");
                    int i3 = reader.GetOrdinal("BolumAdi");
                    int i4 = reader.GetOrdinal("IPAdres");
                    int i5 = reader.GetOrdinal("Mesaj");


                    Doktor d = new Doktor();
                    d.DoktorId = reader.GetInt32(i1);

                    if (reader.IsDBNull(i2) == false)
                        d.DoktorAdi = reader.GetString(i2);
                    else
                        d.DoktorAdi = "";

                    if (reader.IsDBNull(i3) == false)
                        d.BolumAdi = reader.GetString(i3);
                    else
                        d.BolumAdi = "";

                    if (reader.IsDBNull(i4) == false)
                        d.IP = reader.GetString(i4);
                    else
                        d.IP = "";

                    if (reader.IsDBNull(i5) == false)
                        d.Detay = reader.GetString(i5);
                    else
                        d.Detay = "";

                    list.Add(d);
                }
            }

            return list;
        }

        public void DoktorTemizle()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM DoktorMap";

            command.ExecuteNonQuery();
        }

        public void DoktorKayit(int DoktorId, string DoktorAdi, string BolumAdi, string Ip, string Mesaj)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO DoktorMap (DoktorId, DoktorAdi, BolumAdi, IPAdres, Mesaj) VALUES (@Id, @Adi, @Bolum, @Ip, @Mesaj)";
            command.Parameters.AddWithValue("@Id", DoktorId);
            command.Parameters.AddWithValue("@Adi", DoktorAdi);
            command.Parameters.AddWithValue("@Bolum", BolumAdi);
            command.Parameters.AddWithValue("@Ip", Ip);
            command.Parameters.AddWithValue("@Mesaj", Mesaj);

            command.ExecuteNonQuery();
        }
    }
}

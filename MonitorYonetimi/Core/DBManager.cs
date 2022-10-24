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
            command.CommandText = "SELECT DoktorId, DoktorAdi, IPAdres FROM DoktorMap ORDER BY DoktorId ASC";

            List<Doktor> list = new List<Doktor>();

            using (var reader = command.ExecuteReader())
            {
                string _isValue = "";
                while (reader.Read())
                {
                    list.Add(
                        Doktor.Make(reader.GetInt32(0), reader.GetString(1), reader.GetString(2))
                        );
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

        public void DoktorKayit(int DoktorId, string DoktorAdi, string Ip)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO DoktorMap (DoktorId, DoktorAdi, IPAdres) VALUES (@Id, @Adi, @Ip)";
            command.Parameters.AddWithValue("@Id", DoktorId);
            command.Parameters.AddWithValue("@Adi", DoktorAdi);
            command.Parameters.AddWithValue("@Ip", Ip);

            command.ExecuteNonQuery();
        }
    }
}

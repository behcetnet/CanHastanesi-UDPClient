using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MonitorYonetimi.Core
{
    public static class SQLManager
    {
        public static List<Doktor> DoktorList()
        {
            var query = DBManager.Instance.GetPref("QUERY_DOKTOR");
            return DoktorListesiWithQuery(query);
        }

        public static List<Doktor> DoktorListesiWithQuery(string queryString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DBManager.Instance.GetPref("DB_HOST");
            builder.InitialCatalog = DBManager.Instance.GetPref("DB_NAME");
            builder.UserID = DBManager.Instance.GetPref("DB_USER");
            builder.Password = DBManager.Instance.GetPref("DB_PASS");

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Doktor> liste = new List<Doktor>();
                while (reader.Read())
                {
                    int i1 = reader.GetOrdinal("DoktorId");
                    int i2 = reader.GetOrdinal("DoktorAdi");
                    int i3 = reader.GetOrdinal("BolumAdi");


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

                    liste.Add(d);
                }
                reader.Close();

                return liste;
            }
        }

        public static List<Muayene> MuayeneList()
        {
            var query = DBManager.Instance.GetPref("QUERY_MUAYENE");
            return MuayeneListesiWithQuery(query);
        }

        public static List<Muayene> MuayeneListesiWithQuery(string queryString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DBManager.Instance.GetPref("DB_HOST");
            builder.InitialCatalog = DBManager.Instance.GetPref("DB_NAME");
            builder.UserID = DBManager.Instance.GetPref("DB_USER");
            builder.Password = DBManager.Instance.GetPref("DB_PASS");

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Muayene> liste = new List<Muayene>();
                while (reader.Read())
                {
                    int i1 = reader.GetOrdinal("DoktorId");
                    int i2 = reader.GetOrdinal("SiraNo");
                    int i3 = reader.GetOrdinal("DoktorAdi");
                    int i4 = reader.GetOrdinal("HastaAdi");
                    int i5 = reader.GetOrdinal("PolkAdi");
                    int i6 = reader.GetOrdinal("Mesaj");

                    Muayene item = new Muayene();
                    item.DoktorId = reader.GetInt32(i1);
                    item.SiraNo = reader.GetInt32(i2);

                    if (reader.IsDBNull(i3) == false)
                        item.DoktorAdi = reader.GetString(i3);

                    if (reader.IsDBNull(i4) == false)
                        item.HastaAdi = reader.GetString(i4);

                    if (reader.IsDBNull(i5) == false)
                        item.PolkAdi = reader.GetString(i5);

                    if (reader.IsDBNull(i6) == false)
                        item.Mesaj = reader.GetString(i6);

                    liste.Add(item);
                }
                reader.Close();

                return liste;
            }
        }


        public static DataTable DataTable(string queryString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DBManager.Instance.GetPref("DB_HOST");
            builder.InitialCatalog = DBManager.Instance.GetPref("DB_NAME");
            builder.UserID = DBManager.Instance.GetPref("DB_USER");
            builder.Password = DBManager.Instance.GetPref("DB_PASS");

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);

                reader.Close();

                return dt;
            }
        }
    }
}

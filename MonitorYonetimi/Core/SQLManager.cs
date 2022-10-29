﻿using System;
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

                    liste.Add(Doktor.Make(
                        reader.GetInt32(i1), reader.GetString(i2), reader.GetString(i3), ""
                        ));
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

                    Muayene item = new Muayene();
                    item.DoktorId = reader.GetInt32(i1);
                    item.SiraNo = reader.GetInt32(i2);
                    item.DoktorAdi = reader.GetString(i3);
                    item.HastaAdi = reader.GetString(i4);
                    item.PolkAdi = reader.GetString(i5);

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

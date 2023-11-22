using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
namespace CarlosCardonaWeb
{
    internal class UnadDB
    {
        private MySqlConnection connection;
        private string cadenaConexion;
        private string database = "unaddb";
        private string server = "localhost";
        private string user = "root";
        private string password = "root";

        public UnadDB()
        {
            cadenaConexion = "Database=" + database +
                ";DataSource=" + server +
                ";User Id=" + user +
                ";Password=" + password;

            connection = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine("Conection created");
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);

            }

            return connection;
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    System.Diagnostics.Debug.WriteLine("Conection closed");

                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);

            }
        }
    }
}
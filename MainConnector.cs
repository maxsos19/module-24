using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using AdoNet2._0.Confuguration;
using System.Data;

namespace AdoNet2._0
{
    public class MainConnector
    {
        SqlConnection connection = new SqlConnection(ConnectionString.MSSQLConnection);
        static void Main(string[] args)
        {
            var connector = new MainConnector();

            var result = connector.ConnectAsync();
            if (result.Result)
            {
                Console.WriteLine("Подключение успешно!");
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }
            Console.ReadKey();

        }
        public async Task<bool> ConnectAsync()
        {
          
            bool result;
            try
            {
                connection = new SqlConnection(ConnectionString.MSSQLConnection);
                await connection.OpenAsync();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public void DisconnectAsync()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                throw new Exception("Подключение уже закрыто!");
            }
        }
    





}
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARK_CHEMBER
{
    internal class SQLConnectionClass
    {
        public static string conReturn()
        {
            try
            {
				// Modify the connection string to connect to an online MySQL database
				string serverAddress = "sql6.freemysqlhosting.net";
				string databaseName = "sql6689043";
				string username = "sql6689043";
				string password = "J9EVLDSzPn";
				int port = 3306; // MySQL default port number
				return $"Server={serverAddress};Port={port};Database={databaseName};Uid={username};Pwd={password};";
			}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            


        }
        
    }
}

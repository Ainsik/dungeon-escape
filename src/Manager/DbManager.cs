using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Dungeon_Crawl.src.Manager
{
    public class DbManager
    {
        public string ConnectionString => ConfigurationManager.AppSettings["connectionString"];
        public bool TestConnection()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open(); return true;
                }
                catch (Exception e)
                { return false; }
            }
        }
    }
}

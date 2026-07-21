using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;   
namespace InventoryManagement
{
    internal class DbConnection
    {
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(
                "server=localhost;" +
                "Database=ims_db;" +
                "Uid=root;" +
                "Pwd=;" +
                "Port=3306;");
        }
    }
}

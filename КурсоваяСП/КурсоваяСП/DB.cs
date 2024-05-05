using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КурсоваяСП
{
    internal class DB
    {
        MySqlConnection conection = new MySqlConnection("server=localhost;port=3306;username=root;database=kursovaya");

        public void openConnection()
        {
            if (conection.State == System.Data.ConnectionState.Closed)
                conection.Open();
        }
        public void closeConnection()
        {
            if (conection.State == System.Data.ConnectionState.Open)
                conection.Close();
        }
        
        public MySqlConnection getConnection()
        {
            return conection;
        }
    }
}

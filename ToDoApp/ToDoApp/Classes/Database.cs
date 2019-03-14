using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Classes
{
    class Database
    {
        public MySqlConnection Con;
        public int Userid;
        public Database()
        {
            Connect();
            Disconnect();
        }

        public void Connect()
        {
            this.Con = new MySqlConnection("Server=81.207.39.183;Database=tododb;Uid=root;Pwd=Liebregts10_;");
            this.Con.Open();
        }

        public void Disconnect()
        {
            this.Con.Close();
        }

        public DataTable ExecuteStringQuery(String Query)
        {
            DataTable Result = new DataTable();

            this.Connect();

            if (this.Verify() == true)
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, Con);
                adapter.Fill(Result);
            }
            //MySqlCommand Command = new MySqlCommand(Query, Con);

            this.Disconnect();

            return Result;
        }

        public bool Verify()
        {
            Console.WriteLine(this.Con.State);
            if (this.Con.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

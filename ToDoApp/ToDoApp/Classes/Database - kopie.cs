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
            this.Con = new MySqlConnection("Server=81.207.39.183;Database=tododb;Uid=username;Pwd=wachtwoord;");
            this.Con.Open();
        }

        public void Disconnect()
        {
            this.Con.Close();
        }

        public DataTable ExecuteQuery(String Query)
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
        public string ExecuteStringQuery(String Query)
        {
            this.Connect();

            MySqlCommand Command = new MySqlCommand(Query, Con);

            string result = Command.ExecuteScalar().ToString();

            this.Disconnect();

            return result;
        }

        public int ExecuteNonQuery(String Query)
        {
            this.Connect();

            MySqlCommand Command = new MySqlCommand(Query, Con);

            int result = Command.ExecuteNonQuery();

            this.Disconnect();

            return result;
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

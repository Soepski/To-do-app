using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Classes
{
    class Login
    {
        Database db = new Database();

        public DataTable Inloggen(string username, string password)
        {
            db.Connect();

            DataTable dt = db.ExecuteStringQuery($"SELECT * FROM gebruiker WHERE gebruikersnaam = '{username}' AND wachtwoord = '{password}';");

            db.Disconnect();

            return dt;
        }
    }
}

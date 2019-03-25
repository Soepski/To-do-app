using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Classes
{
    class NotitieController
    {
        Database db = new Database();

        public DataTable laadData(int gebruikersID)
        {
            DataTable dt = db.ExecuteQuery($"SELECT * FROM `notitie` WHERE GebruikerID = '{gebruikersID}'");

            return dt;
        }

        public int taakOpslaan(string Omschrijving, string ID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"INSERT INTO `tododb`.`notitie` (`Omschrijving`, `GebruikerID`) VALUES ('{Omschrijving}', '{ID}');");

            return affectedRows;
        }

        public int taakVerwijderen(string taakID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"DELETE FROM `tododb`.`notitie` WHERE  `ID`={taakID};");

            return affectedRows;
        }
    }
}

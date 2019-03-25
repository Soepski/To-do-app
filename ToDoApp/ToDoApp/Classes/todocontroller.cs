using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ToDoApp.Classes
{
    class ToDoController
    {
        Database db = new Database();

        public DataTable laadData(int gebruikersID)
        {
            DataTable dt = db.ExecuteQuery($"SELECT * FROM `to-do taak` WHERE GebruikerID = '{gebruikersID}';");

            return dt;
        }

        public int taakOpslaan(string Omschrijving, string Datum, string ID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"INSERT INTO `tododb`.`to-do taak` (`Omschrijving`, `Datum`, `GebruikerID`, `Voltooid`) VALUES ('{Omschrijving}', '{Datum}', '{ID}', b'0');");

            return affectedRows;
        }

        public int taakVerwijderen(string taakID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"DELETE FROM `tododb`.`to-do taak` WHERE  `ID`={taakID};");

            return affectedRows;
        }
        public int taakVoltooien(string taakID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"UPDATE `tododb`.`to-do taak` SET `Voltooid`=b'1' WHERE  `ID`={taakID};");

            return affectedRows;
        }
    }
}

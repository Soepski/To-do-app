using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Classes
{
    class SchoolTakenController
    {
        Database db = new Database();

        public DataTable laadData(int gebruikersID)
        {
            DataTable dt = db.ExecuteQuery($"SELECT * FROM `school taak` WHERE GebruikersID = '{gebruikersID}';");

            return dt;
        }

        public int taakOpslaan(string Omschrijving, string Vak, string Datum, string ID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"INSERT INTO `tododb`.`school taak` (`Omschrijving`, `Vak`, `Deadline`, `GebruikersID`, `Voltooid`) VALUES ('{Omschrijving}', '{Vak}', '{Datum}', '{ID}', b'0');");

            return affectedRows;
        }

        public int taakVerwijderen(string taakID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"DELETE FROM `tododb`.`school taak` WHERE  `ID`={taakID};");

            return affectedRows;
        }
        public int taakVoltooien(string taakID)
        {
            int affectedRows;

            affectedRows = db.ExecuteNonQuery($"UPDATE `tododb`.`school taak` SET `Voltooid`=b'1' WHERE  `ID`={taakID};");

            return affectedRows;
        }
    }
}

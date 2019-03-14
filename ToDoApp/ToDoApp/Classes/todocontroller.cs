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
            DataTable dt = db.ExecuteStringQuery("SELECT * FROM gebruiker");

            return dt;
        }
    }
}

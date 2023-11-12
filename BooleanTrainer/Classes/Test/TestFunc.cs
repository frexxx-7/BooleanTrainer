using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.Classes.Test
{
    internal class TestFunc
    {
        public DataTable ReadItems(string idUser)
        {
            DB db = new DB();

            db.openConnection();
            string query = idUser!=null ?
                $"SELECT test.id, header, image, checkedTheory FROM passedTest " +
                $"left join test on test.id = passedTest.idTest " +
                $"where idUser = {idUser}"
                :
                $"SELECT id, header, image, checkedTheory FROM test";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
            try
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

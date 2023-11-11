using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.Classes.Theory
{
    internal class TheoryFunc
    {
        public bool AddItemsToTable(string header, string content, Image img, string idCategory)
        {
            DB db = new DB();

            string query = "INSERT into theory (header, content, image, idCategory) values(@header, @content, @image, @idCategory)";
            db.openConnection();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (header == null || content == null || idCategory == null)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@header", header);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.Parameters.AddWithValue("@idCategory", idCategory);
                        MemoryStream ms = new MemoryStream();
                        if (img != null)
                        {
                            img.Save(ms, img.RawFormat);
                        }
                        cmd.Parameters.AddWithValue("@image", ms.Length != 0 ? ms.ToArray() : null);
                        cmd.ExecuteNonQuery();
                        db.closeConnection();
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        public DataTable ReadItems()
        {
            DB db = new DB();

            db.openConnection();
            string query = $"SELECT * FROM theory";
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

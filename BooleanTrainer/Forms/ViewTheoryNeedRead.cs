using BooleanTrainer.Classes;
using BooleanTrainer.Classes.Theory;
using BooleanTrainer.UserControls;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace BooleanTrainer.Forms
{
    public partial class ViewTheoryNeedRead : Form
    {
        private string idUser;
        private string [] checkTheory;
        public ViewTheoryNeedRead(string idUser, string[] checkTheory)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.checkTheory = checkTheory;
        }
        private void GenerateTheory()
        {
            DB db = new DB();
            int panelNumber = 0;

            for (int i = 0; i < checkTheory.Length; i++)
            {

                db.openConnection();

                string queryInfo = $"select * from theory where id = {checkTheory[i]}";

                MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());


                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Guna2Panel panel = new Guna2Panel
                    {
                        Name = $"Theory+{panelNumber}",
                        Size = new Size(480, 190),
                    };
                    var theoryItem = new TheoryControl(idUser, reader["id"].ToString(), reader["header"].ToString(), reader["content"].ToString(), this, checkIsPassedTheory(reader["id"].ToString()));
                    theoryItem.Dock = DockStyle.Top;

                    if (reader["image"] != System.DBNull.Value)
                    {
                        MemoryStream ms = new MemoryStream((byte[])reader["image"]);
                        theoryItem.image = new Bitmap(ms);
                    }
                    panel.Controls.Add(theoryItem);
                    ContentPanel.Controls.Add(panel);
                    panelNumber++;
                }

                reader.Close();

            }
            db.closeConnection();
        }
        private bool checkIsPassedTheory(string idTheory)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM passedTheory WHERE idUser = {idUser} AND idTheory = {idTheory}", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ViewTheoryNeedRead_Load(object sender, EventArgs e)
        {
            GenerateTheory();
        }
    }
}

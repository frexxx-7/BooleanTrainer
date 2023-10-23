using BooleanTrainer.AddForms;
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

namespace BooleanTrainer.Forms
{
    public partial class Theory : Form
    {
        private string idUser;
        public Theory(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            new Menu(idUser).Show();
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddTheory().Show();
        }

        private void Theory_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void GenerateTheory()
        {
            TheoryBLL objbll = new TheoryBLL();

            DataTable dt = objbll.GetItems();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    TheoryControl[] listItems = new TheoryControl[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"Theory+{panelNumber}",
                                Size = new Size(480, 190),
                            };
                            listItems[i] = new TheoryControl(idUser, row["id"].ToString(), row["header"].ToString(), row["content"].ToString(), this, checkIsPassedTheory(row["id"].ToString()));
                            listItems[i].Dock = DockStyle.Top;

                            if (row["image"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["image"]);
                                listItems[i].image = new Bitmap(ms);
                            }
                            panel.Controls.Add(listItems[i]);
                            ContentPanel.Controls.Add(panel);
                            panelNumber++;
                        }

                    }
                }
            }
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
        private void Theory_Load(object sender, EventArgs e)
        {
            GenerateTheory();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

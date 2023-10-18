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
            this.Hide();
            new Menu(idUser).Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddTheory().Show();
        }

        private void Theory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                                Name = $"Product+{panelNumber}",
                                Size = new Size(440, 500),
                                Padding = new System.Windows.Forms.Padding(bottom: 3, left: 0, top: 0, right: 0),
                            };
                            listItems[i] = new TheoryControl(row["id"].ToString(), row["header"].ToString(), row["content"].ToString());


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
        private void Theory_Load(object sender, EventArgs e)
        {
            GenerateTheory();
        }
    }
}

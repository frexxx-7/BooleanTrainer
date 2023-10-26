using BooleanTrainer.AddForms;
using BooleanTrainer.Classes.Test;
using BooleanTrainer.Classes.Theory;
using BooleanTrainer.UserControls;
using Guna.UI2.WinForms;
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
    public partial class Tests : Form
    {
        private string idUser;
        public Tests(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            new Menu(idUser).Show();
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddTests().Show();
        }

        private void Tests_Load(object sender, EventArgs e)
        {
            GenerateTest();
        }
        private void GenerateTest()
        {
            TestBLL objbll = new TestBLL();

            DataTable dt = objbll.GetItems();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    TestControl[] listItems = new TestControl[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"Test+{panelNumber}",
                                Size = new Size(480, 190),
                            };
                            listItems[i] = new TestControl(idUser, row["id"].ToString(), row["header"].ToString(), this, row["checkedTheory"].ToString());
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
    }
}

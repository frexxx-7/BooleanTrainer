using BooleanTrainer.AddForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}

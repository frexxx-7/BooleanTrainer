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
    public partial class Menu : Form
    {
        public static string login;
        private string id;
        public Menu(string id)
        {
            InitializeComponent();
            this.id = id;
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TheoryButton_Click(object sender, EventArgs e)
        {
            new Theory(id).Show();
            this.Close();
        }

        private void TestsButton_Click(object sender, EventArgs e)
        {
            new Tests(id).Show();
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            new Profile(id).Show();
            this.Close();
        }
    }
}

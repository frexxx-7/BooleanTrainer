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
    }
}

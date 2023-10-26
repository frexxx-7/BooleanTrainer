using BooleanTrainer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.UserControls
{
    public partial class TestControl : UserControl
    {
        private string header, idUser, idTest;
        public Image image;
        private Form activeForm;

        private void TheoryControlPanel_Click(object sender, EventArgs e)
        {
            new PassingTheTest(idUser, idTest).Show();
            activeForm.Close();
        }

        private void TestControl_Load(object sender, EventArgs e)
        {
            HeaderLabel.Text = header;
            pictureBox.Image = image;
        }

        public TestControl(string idUser, string idTest, string header, Form activeForm)
        {
            InitializeComponent();
            this.header = header;
            this.idUser = idUser;
            this.idTest = idTest;
            this.activeForm = activeForm;
        }
    }
}

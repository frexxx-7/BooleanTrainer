using BooleanTrainer.Classes;
using BooleanTrainer.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BooleanTrainer.UserControls
{
    public partial class TheoryControl : UserControl
    {
        private string idUser, id, header, content;
        public Image image;
        private Form thisForm;
        private bool isPassed=false;

        private void pictureBox_Click(object sender, EventArgs e)
        {
            new ViewTheory(idUser, id, header, content, image, isPassed).Show();
            thisForm.Hide();
        }

        private void flowLayoutPanel2_Click(object sender, EventArgs e)
        {
            new ViewTheory(idUser, id, header, content, image, isPassed).Show();
            thisForm.Hide();
        }

        private void ContentLabel_Click(object sender, EventArgs e)
        {
            new ViewTheory(idUser, id, header, content, image, isPassed).Show();
            thisForm.Hide();
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            new ViewTheory(idUser, id, header, content, image, isPassed).Show();
            thisForm.Hide();
        }

        private void HeaderLabel_Click(object sender, EventArgs e)
        {
            new ViewTheory(idUser, id, header, content, image, isPassed).Show();
            thisForm.Hide();
        }

        private void TheoryControlPanel_Click(object sender, EventArgs e)
        {
            new ViewTheory(idUser, id, header, content, image, isPassed).Show();
            thisForm.Hide();
        }

        
        private void TheoryControl_Load(object sender, EventArgs e)
        {
            pictureBox.Image = image;
            HeaderLabel.Text = header;
            ContentLabel.Text = content;
            if (isPassed)
            {
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Check;
                iconPictureBox1.IconColor = Color.Green;
            }
            else
            {
                iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                iconPictureBox1.IconColor = Color.Red;
            }
        }

        public TheoryControl(string idUser, string id, string header, string content, Form thisForm, bool isPassed)
        {
            InitializeComponent();
            this.id = id;
            this.header = header;
            this.content = content;
            this.idUser = idUser;
            this.thisForm = thisForm;
            this.isPassed = isPassed;
        }
    }
}

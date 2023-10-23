using BooleanTrainer.Classes;
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

namespace BooleanTrainer.Forms
{
    public partial class ViewTheory : Form
    {
        private Image image;
        private string idUser, idTheory, header, content;
        private bool isPassed = false;

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ViewTheory_Load(object sender, EventArgs e)
        {
            HeaderLabel.Text = header;
            ContentLabel.Text = content;
            guna2PictureBox1.Image = image;

            if (!isPassed)
            {
                passedTheory();
            }
        }
        private void passedTheory()
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand($"insert into passedTheory (idUser, idTheory) values ({idUser}, {idTheory}) ", db.getConnection());


            db.openConnection();

            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Ошибка");
            }

            db.closeConnection();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            new Theory(idUser).Show();
            this.Close();
        }

        public ViewTheory(string idUSer, string idTheory, string header, string content, Image image, bool isPassed)
        {
            InitializeComponent();
            this.idUser = idUSer;
            this.idTheory = idTheory;
            this.header = header;
            this.content = content;
            this.image = image;
            this.isPassed = isPassed;
        }
    }
}

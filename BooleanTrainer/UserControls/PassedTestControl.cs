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

namespace BooleanTrainer.UserControls
{
    public partial class PassedTestControl : UserControl
    {
        private string header, idUser, idTest;
        public Image image;
        string result;

        private void getResultPassedTheTest()
        {
            DB db = new DB();
            string queryInfo = $"SELECT result from passedTest " +
                $"where idUser = {idUser} and idTest = {idTest}";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result = reader[0].ToString();
            }
            reader.Close();

            db.closeConnection();
        }

        private void TheoryControlPanel_Click(object sender, EventArgs e)
        {
            new PassedTestInfo(header, result).Show();
        }

        private void HeaderLabel_Click(object sender, EventArgs e)
        {
            new PassedTestInfo(header, result).Show();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            new PassedTestInfo(header, result).Show();
        }

        private void PassedTestControl_Load(object sender, EventArgs e)
        {
            HeaderLabel.Text = header;
            pictureBox.Image = image;
            getResultPassedTheTest();
        }

        public PassedTestControl(string idUser, string idTest, string header)
        {
            InitializeComponent();
            this.header = header;
            this.idUser = idUser;
            this.idTest = idTest;
        }
    }
}

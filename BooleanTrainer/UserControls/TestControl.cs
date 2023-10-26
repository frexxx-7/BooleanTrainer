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
    public partial class TestControl : UserControl
    {
        private string header, idUser, idTest, checkedTheory;
        public Image image;
        private Form activeForm;
        private string checkedUserTheory = "";

        private void TheoryControlPanel_Click(object sender, EventArgs e)
        {
            checkUserCheckedTheory();
            new PassingTheTest(idUser, idTest).Show();
            activeForm.Close();
        }

        private void TestControl_Load(object sender, EventArgs e)
        {
            HeaderLabel.Text = header;
            pictureBox.Image = image;
        }
        private void checkUserCheckedTheory()
        {
            checkUserTheory();
            string[] checkedTheoryArray = checkedTheory.Split(',');
            string[] checkedUserTheoryArray = checkedUserTheory.Split(',');


            bool isSubset = checkedTheoryArray.SequenceEqual(checkedUserTheoryArray.Take(checkedTheoryArray.Length));

            MessageBox.Show(isSubset.ToString());
        }
        private void checkUserTheory()
        {
            DB db = new DB();
            string queryInfo = $"SELECT GROUP_CONCAT(idTheory) from passedTheory " +
                $"where idUSer = {idUser}";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                checkedUserTheory = reader[0].ToString();
            }
            reader.Close();

            db.closeConnection();
        }

        public TestControl(string idUser, string idTest, string header, Form activeForm, string checkedTheory)
        {
            InitializeComponent();
            this.header = header;
            this.idUser = idUser;
            this.idTest = idTest;
            this.activeForm = activeForm;
            this.checkedTheory = checkedTheory;
        }
    }
}

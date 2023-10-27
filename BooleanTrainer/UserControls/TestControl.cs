using BooleanTrainer.Classes;
using BooleanTrainer.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
        private bool isPassed;

        private void TheoryControlPanel_Click(object sender, EventArgs e)
        {
            if (checkUserCheckedTheory())
            {
                new PassingTheTest(idUser, idTest).Show();
                activeForm.Close();
            }
            else
            {
                new ViewTheoryNeedRead(idUser, checkedTheory.Split(',')).Show();
            }
        }

        private void TestControl_Load(object sender, EventArgs e)
        {
            HeaderLabel.Text = header;
            pictureBox.Image = image;

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
        private bool checkUserCheckedTheory()
        {
            checkUserTheory();
            string[] checkedTheoryArray = checkedTheory.Split(',');
            string[] checkedUserTheoryArray = checkedUserTheory.Split(',');

            bool isSubset = checkedTheoryArray.Intersect(checkedUserTheoryArray).Count() == checkedTheoryArray.Length;
            if (checkedTheory != "")
            {
                return isSubset;
            }
            else
            {
                return true;
            }
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

        public TestControl(string idUser, string idTest, string header, Form activeForm, string checkedTheory, bool isPassed)
        {
            InitializeComponent();
            this.header = header;
            this.idUser = idUser;
            this.idTest = idTest;
            this.activeForm = activeForm;
            this.checkedTheory = checkedTheory;
            this.isPassed = isPassed;
        }
    }
}

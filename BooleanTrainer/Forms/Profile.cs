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
using System.Xml;

namespace BooleanTrainer.Forms
{
    public partial class Profile : Form
    {
        private string idUser;
        public Profile(string idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
        }

        private void loadInfoUser()
        {
            DB db = new DB();
            string queryInfo = $"SELECT users.login, additionalinfouser.age,  concat(additionalinfouser.name, ' ', additionalinfouser.patronymic, ' ', additionalinfouser.surname) as FIO , concat(address.house, ' ', address.street, ' ', address.city, ' ', address.country) as addressInfo FROM users " +
                $"left join additionalinfouser on users.idAdditionalInfoUser = additionalinfouser.id " +
                $"left join address on additionalinfouser.idAddress = address.id " +
                $"WHERE users.id = '{idUser}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LoginLabel.Text = reader["login"].ToString();
                FIOLabel.Text = reader["FIO"].ToString() != "" ? reader["FIO"].ToString() : "Не указано";
                AgeLabel.Text = reader["age"].ToString() != "" ? reader["age"].ToString() : "Не указано";
                AddressLabel.Text = reader["addressInfo"].ToString() != "" ? reader["addressInfo"].ToString() : "Не указано";
            }
            reader.Close();

            db.closeConnection();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            loadInfoUser();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new EditProfile(idUser).Show();
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            new Menu(idUser).Show();
        }
    }
}

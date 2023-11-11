using BooleanTrainer.AddForms;
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
    public partial class EditProfile : Form
    {
        private string idUser;
        private string idAdditionalInfoUser;
        public EditProfile(string idUser)
        {
            this.idUser= idUser;

            InitializeComponent();
            
            loadInfoAddress();
            loadUserInfo();
        }
        private void loadUserInfo()
        {
            DB db = new DB();
            string queryInfo = $"SELECT users.login, users.idAdditionalInfoUser , additionalinfouser.* FROM users " +
                $"left join additionalinfouser on users.idAdditionalInfoUser = additionalinfouser.id " +
                $"WHERE users.id = '{idUser}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LoginTextBox.Text = reader["login"].ToString();
                NameTextBox.Text = reader["name"].ToString();
                PatronymicTextBox.Text = reader["patronymic"].ToString();
                SurnameTextBox.Text = reader["surname"].ToString();
                AgeTextBox.Text = reader["age"].ToString();
                idAdditionalInfoUser = reader["idAdditionalInfoUser"].ToString() != "" ? reader["idAdditionalInfoUser"].ToString() : null;

                for (int i = 0; i < AddressComboBox.Items.Count; i++)
                {
                    if (reader["idAddress"].ToString() != "")
                    {
                        if (Convert.ToInt32((AddressComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["idAddress"]))
                        {
                            AddressComboBox.SelectedIndex = i;
                        }
                    }
                }
            }
            reader.Close();

            db.closeConnection();

        }

        private void loadInfoAddress()
        {
            DB db = new DB();
            string queryInfo = $"SELECT address.id, concat(address.house, ' ', address.street, ' ', address.city, ' ', address.country) FROM address";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                AddressComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Profile(idUser).Show();
            this.Close();
        }

        private void AddAddressButton_Click(object sender, EventArgs e)
        {
            new AddAddress().Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idAdditionalInfoUser == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into additionalinfouser (name, surname, patronymic, age, idAddress) values(@name, @surname, @patronymic, @age, @idAddress);" +
                $"Update users set idAdditionalInfoUser = (Select LAST_INSERT_ID()) " +
                $"where users.id = {idUser} ", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@age", AgeTextBox.Text);
                command.Parameters.AddWithValue("@idAddress", (AddressComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteScalar();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update additionalinfouser set name = @name, surname = @surname, patronymic = @patronymic, age= @age, idAddress = @idAddress " +
                $"where additionalinfouser.id = {idAdditionalInfoUser} ", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@age", AgeTextBox.Text);
                command.Parameters.AddWithValue("@idAddress", (AddressComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteScalar();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                db.closeConnection();
            }

            MySqlCommand commandUser = new MySqlCommand($"update users set login = @login where id = {idUser}", db.getConnection());
            commandUser.Parameters.AddWithValue("@login", LoginTextBox.Text);

            db.openConnection();

            try
            {
                commandUser.ExecuteNonQuery();
                MessageBox.Show("Информация обновлена");
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

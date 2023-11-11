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

namespace BooleanTrainer.AddForms
{
    public partial class AddAddress : Form
    {
        public AddAddress()
        {
            InitializeComponent();
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"INSERT into address (house, street, city, country) values(@house, @street, @city, @country)", db.getConnection());
            command.Parameters.AddWithValue("@house", HouseTextBox.Text);
            command.Parameters.AddWithValue("@street", StreetTextBox.Text);
            command.Parameters.AddWithValue("@city", CityTextBox.Text);
            command.Parameters.AddWithValue("@country", CountryTextBox.Text);
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Адрес добавлен");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.closeConnection();
        }
    }
}

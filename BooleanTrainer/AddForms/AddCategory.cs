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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"INSERT into category (name) values(@name)", db.getConnection());
            command.Parameters.AddWithValue("@name", NameTextBox.Text);
            db.openConnection();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Категория добавлена");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

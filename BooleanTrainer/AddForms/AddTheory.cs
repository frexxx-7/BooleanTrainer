using BooleanTrainer.Classes;
using BooleanTrainer.Classes.Theory;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.AddForms
{
    public partial class AddTheory : Form
    {
        Image image;
        public AddTheory()
        {
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            TheoryBLL objbll = new TheoryBLL();

            if (HeaderTextBox.Text.Length == 0 || ContentTextBox.Text.Length ==0)
            {
                MessageBox.Show("Некоторые данные введены некорректно");
            }
            else
            if (objbll.SaveItem(HeaderTextBox.Text, ContentTextBox.Text, image, (CategoryComboBox.SelectedItem as ComboBoxItem).Value.ToString()))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(opendlg.FileName);
                pictureBox1.Image = image;
            }
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            new AddCategory().Show();
        }
        private void loadInfoAboutCategory()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM category ";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                CategoryComboBox.Items.Add(item);
            }
            reader.Close();
        }

        private void AddTheory_Load(object sender, EventArgs e)
        {
            loadInfoAboutCategory();
        }
    }
}

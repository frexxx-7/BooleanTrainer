using FontAwesome.Sharp;
using Guna.UI2.WinForms;
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
    public partial class AddTests : Form
    {
        private int countPage = 1;
        private int countPanel = 0;
        private int countQuestions = 1;
        public AddTests()
        {
            InitializeComponent();
        }
        private void checkPage()
        {
            switch (countPage)
            {
                case 1:
                    CreateTestPanel.Controls.Add(Page1Panel);
                    Page1Panel.Dock = DockStyle.Fill;
                    break;
                case 2:
                    CreateTestPanel.Controls.Add(Page2Panel);
                    Page2Panel.Dock = DockStyle.Fill;
                    Page2Panel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (countPage != 2)
            {
                CreateTestPanel.Controls.Clear();
                countPage++;
                checkPage();
                if (countPage > 1)
                {
                    CancelButton.Text = "Назад";
                }
                if (countPage >= 2)
                {
                    NextButton.Text = "Сохранить";
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButton.Text == "Назад")
            {
                CreateTestPanel.Controls.Clear();
                countPage--;
                if (countPage <= 1)
                {
                    CancelButton.Text = "Отмена";
                }
                if(NextButton.Text == "Сохранить")
                {
                    NextButton.Text = "Далее";
                }
                checkPage();
            }
            else
            {
                this.Close();
            }
        }

        private void AddTests_Load(object sender, EventArgs e)
        {
            checkPage();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AOPanel.Visible = true;
            countPanel++;

            Guna2Panel panel = new Guna2Panel();
            panel.Name = $"panel{countPanel}";
            panel.Dock = DockStyle.Top;
            AOPanel.Controls.Add(panel);
            
            IconPictureBox ipb = new IconPictureBox();
            ipb.Name = $"iconPictureBox|{countPanel}";
            ipb.Dock = DockStyle.Top;
            ipb.IconChar = IconChar.Xmark;
            ipb.IconColor = Color.Red;
            ipb.Click += ipb_Click;
            panel.Controls.Add(ipb);

            Guna2CheckBox checkbox = new Guna2CheckBox();
            checkbox.Name = $"checkbox{countPanel}";
            checkbox.Dock = DockStyle.Top;
            checkbox.Text = "Правильный ответ";
            checkbox.ForeColor = Color.FromArgb(74, 74, 255);
            panel.Controls.Add(checkbox);

            Guna2TextBox textbox = new Guna2TextBox();
            textbox.Name = $"textbox{countPanel}";
            textbox.Dock = DockStyle.Top;
            textbox.BorderColor = Color.FromArgb(110, 110, 255);
            textbox.PlaceholderForeColor = Color.FromArgb(110, 110, 255);
            textbox.ForeColor = Color.FromArgb(74, 74, 255);
            textbox.BorderRadius = 6;
            textbox.PlaceholderText = "Текст";
            textbox.Size = new Size(935, 33);
            panel.Controls.Add(textbox);

        }

        private void ipb_Click(object sender, EventArgs e)
        {
            string index = ((IconPictureBox)sender).Name.Split('|')[1];
            var panel = AOPanel.Controls.Find($"panel{index}", true);
            AOPanel.Controls.Remove(panel[0]);
        }

        private void AddQuestionButton_Click(object sender, EventArgs e)
        {
            QuestionPanel.Visible = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "dataTest.txt";

            using (StreamWriter writer = new StreamWriter(pathFile, true))
            {
                writer.WriteLine($"question|{countQuestions}|{QuestionTextBox.Text}|{CheckBoxAO.Checked}| ");
                for (int i = 1; i <= countPanel; i++)
                {
                    writer.WriteLine($"ao|{this.Controls.Find($"textbox{i}", true)[0].Text}|{((CheckBox)this.Controls.Find($"checkbox{i}", true)[0]).Checked}");
                }
            }

            AOPanel.Visible = false;
            AOPanel.Controls.Clear();
            QuestionTextBox.Text = "";
            CheckBoxAO.Checked = false;
            countPanel = 0;
            countQuestions++;
            QuestionPanel.Visible = false;
        }
    }
}

using BooleanTrainer.Classes;
using BooleanTrainer.Classes.Theory;
using BooleanTrainer.UserControls;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
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
using System.Windows.Shapes;

namespace BooleanTrainer.AddForms
{
    public partial class AddTests : Form
    {
        private int countPage = 1;
        private int countPanel = 0;
        private int countQuestions = 1;
        private System.Drawing.Image image;
        string checkedTheory = "";

        public AddTests()
        {
            InitializeComponent();
        }
        private void GenerateTheory()
        {
            TheoryBLL objbll = new TheoryBLL();

            DataTable dt = objbll.GetItems();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    TheoryControlForTest[] listItems = new TheoryControlForTest[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"Theory+{panelNumber}",
                                Size = new Size(480, 190),
                            };
                            listItems[i] = new TheoryControlForTest(row["id"].ToString(), row["header"].ToString(), row["content"].ToString());
                            listItems[i].Dock = DockStyle.Top;

                            if (row["image"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["image"]);
                                listItems[i].image = new Bitmap(ms);
                            }
                            panel.Controls.Add(listItems[i]);
                            TheoryPanel.Controls.Add(panel);
                            panelNumber++;
                        }

                    }
                }
            }
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
                case 3:
                    CreateTestPanel.Controls.Add(Page3Panel);
                    Page3Panel.Dock = DockStyle.Fill;
                    Page3Panel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (countPage != 3)
            {
                if (countPage == 2)
                {
                    checkedTheory = "";
                    foreach (Control controlPanel in TheoryPanel.Controls)
                    {
                        foreach(Control theoryControl in controlPanel.Controls)
                        {
                            if((theoryControl as TheoryControlForTest).IsCheckBoxChecked)
                            {
                                checkedTheory += (theoryControl as TheoryControlForTest).id + ",";
                            }
                        }
                    }
                    checkedTheory = checkedTheory.Substring(0, checkedTheory.Length - 1);
                }
                CreateTestPanel.Controls.Clear();
                countPage++;
                checkPage();
                if (countPage > 1)
                {
                    CancelButton.Text = "Назад";
                }
                if (countPage >= 3)
                {
                    NextButton.Text = "Сохранить";
                }
            }
            else
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "dataTest.txt";
                string fileContent = File.ReadAllText(filePath);

                DB db = new DB();

                MySqlCommand command = new MySqlCommand($"INSERT into test (header, dataTest, image, checkedTheory) " +
                    $"values(@header, @dataTest, @image, @checkedTheory)", db.getConnection());

                MemoryStream ms = new MemoryStream();
                if (image != null)
                {
                    image.Save(ms, image.RawFormat);
                }
                command.Parameters.AddWithValue("@header", HeaderTextBox.Text);
                command.Parameters.AddWithValue("@dataTest", fileContent);
                command.Parameters.AddWithValue("@image", ms.Length != 0 ? ms.ToArray() : null);
                command.Parameters.AddWithValue("@checkedTheory", checkedTheory);


                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "dataTest.txt", string.Empty);
            GenerateTheory();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(opendlg.FileName);
                pictureBox1.Image = image;
            }
        }
    }
}

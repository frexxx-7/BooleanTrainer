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
using System.Xml.Linq;
using BooleanTrainer.Classes;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using static Guna.UI2.Native.WinApi;

namespace BooleanTrainer.Forms
{
    public partial class PassedTestInfo : Form
    {
        private string header, result, idTest;
        private string textTest;
        private string answers;
        public PassedTestInfo(string header, string result, string idTest, string answers)
        {
            InitializeComponent();

            this.result = result;
            this.header = header;
            this.idTest = idTest;

            HeaderLabel.Text = header;
            ResultLabel.Text = result;
            this.answers = answers;
        }

        private void loadTestInfo()
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "dataTest.txt";

            using (StreamWriter writer = new StreamWriter(pathFile, false))
            {
                writer.Write("");
            }
            DB db = new DB();

            string queryInfo = $"select * from test where test.id = {idTest}";

            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            using (StreamWriter writer = new StreamWriter(pathFile, true))
            {
                while (reader.Read())
                {
                    HeaderLabel.Text = reader["header"].ToString();

                    writer.WriteLine(reader.GetString(reader.GetOrdinal("dataTest")));
                }
            }
            reader.Close();

            db.closeConnection();
            string[] lines = File.ReadAllLines(pathFile);

            foreach (string line in lines)
            {
                if (line.Length != 0)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "question")
                    {
                        textTest += $"\n Вопрос {parts[1]} {parts[2]} \n";
                    }
                    else
                    {
                        if (bool.Parse(parts[2]))
                        {
                            textTest += $"{parts[1]} Правильный ответ \n";
                        }
                        if (bool.Parse(parts[2]) == false)
                        {
                            textTest += $"{parts[1]} \n";
                        }
                    }
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PassedTestInfo_Load(object sender, EventArgs e)
        {
            loadTestInfo();
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document sourceDoc = wordApp.Documents.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Шаблон.docx"));
            sourceDoc.Content.Copy();
            Document targetDoc = wordApp.Documents.Add();
            targetDoc.Content.Paste();

            Bookmark bookmark = targetDoc.Bookmarks["Название"];
            if (bookmark != null)
            {
                Range range = bookmark.Range;
                range.Text = header;

            }

            bookmark = targetDoc.Bookmarks["Результат"];
            if (bookmark != null)
            {
                Range range = bookmark.Range;
                range.Text = result;
            }

            bookmark = targetDoc.Bookmarks["Тест"];
            if (bookmark != null)
            {
                Range range = bookmark.Range;
                range.Text = textTest;
            }

            bookmark = targetDoc.Bookmarks["Ответы"];
            if (bookmark != null)
            {
                Range range = bookmark.Range;
                range.Text = answers;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog1.Title = "Сохранить скопированный документ в";
            saveFileDialog1.ShowDialog();

            string targetPath = saveFileDialog1.FileName;
            
            targetDoc.Close();
            wordApp.Quit();

            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            Document wordDocument = wordApplication.Documents.Open(targetPath);
            wordApplication.Visible = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

﻿using BooleanTrainer.Classes;
using Microsoft.Office.Interop.Word;
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

namespace BooleanTrainer.Forms
{
    public partial class PassingTheTest : Form
    {
        private string idTest = null;
        private string idUser = null;
        private int numberQuestion = 1;
        private int countQuestion = 0;
        private int countPanel = 0;
        private int result = 0;
        private string answers;
        private string textTest = null;
        public PassingTheTest(string idUser, string idTest)
        {
            InitializeComponent();
            this.idTest = idTest;
            this.idUser = idUser;
        }

        private void PassingTheTest_Load(object sender, EventArgs e)
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

            bool isGenerate = true;
            foreach (string line in lines)
            {
                if (line.Length != 0)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "question")
                    {
                        countQuestion++;
                        if (numberQuestion.ToString() == parts[1])
                        {
                            Label label = new Label();
                            label.Name = $"textboxQuest{numberQuestion}";
                            label.Text = parts[2];
                            label.Dock = DockStyle.Top;

                            answers += $"Вопрос {parts[1]} ";

                            QuestionNamePanel.Controls.Add(label);
                        }
                        else
                        {
                            isGenerate = false;
                            continue;
                        }
                    }
                    else
                    {
                        if (isGenerate)
                        {
                            if (bool.Parse(parts[2]))
                            {
                                countPanel++;
                                System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
                                checkbox.Name = $"checkboxTrue{countPanel}";
                                checkbox.Dock = DockStyle.Top;
                                checkbox.Text = parts[1];
                                AOPanel.Controls.Add(checkbox);
                            }
                            if (bool.Parse(parts[2]) == false)
                            {
                                countPanel++;
                                System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
                                checkbox.Name = $"checkboxFalse{countPanel}";
                                checkbox.Dock = DockStyle.Top;
                                checkbox.Text = parts[1];
                                AOPanel.Controls.Add(checkbox);
                            }
                        }
                    }
                }
            }
            if (numberQuestion == countQuestion)
            {
                NextButton.Text = "Завершить";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new Tests(idUser).Show();
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in AOPanel.Controls)
            {
                if (control is System.Windows.Forms.CheckBox checkBox && checkBox.Checked)
                {
                    answers += $"Ответ: {checkBox.Text} \n";
                }
            }
            if (NextButton.Text != "Завершить")
            {
                numberQuestion++;
                checkRes(countPanel);
                loadQuestion();
                if (numberQuestion >= countQuestion)
                {
                    NextButton.Text = "Завершить";
                }
            }
            else
            {
                OutputButton.Visible = true;
                label3.Visible = true;
                ResLbl.Text = checkRes(countPanel).ToString();
                NextButton.Visible = false;

                DB db = new DB();

                MySqlCommand command = new MySqlCommand($"insert into passedTest (idUser, idTest, result, answers) values ({idUser}, {idTest}, {result}, '{answers}')", db.getConnection());


                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Тест пройден");
                }
                else
                {
                    MessageBox.Show("Ошибка прохождения теста");
                }

                db.closeConnection();          
            }
        }
        private void loadQuestion()
        {
            QuestionNamePanel.Controls.Clear();
            AOPanel.Controls.Clear();

            countPanel = 0;

            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "dataTest.txt";
            string[] lines = File.ReadAllLines(pathFile);
            bool isGenerate = false;
            foreach (string line in lines)
            {
                if (line.Length != 0)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "question")
                    {
                        if (numberQuestion.ToString() == parts[1])
                        {
                            Label label = new Label();
                            label.Name = $"textboxQuest{numberQuestion}";
                            label.Text = parts[2];
                            label.Dock = DockStyle.Top;
                            QuestionNamePanel.Controls.Add(label);

                            answers += $"Вопрос {parts[1]} ";

                            isGenerate = true;
                        }
                        else
                        {
                            isGenerate = false;
                        }
                    }
                    else
                    {
                        if (isGenerate)
                        {
                            if (bool.Parse(parts[2]))
                            {
                                countPanel++;
                                System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
                                checkbox.Name = $"checkboxTrue{countPanel}";
                                checkbox.Dock = DockStyle.Top;
                                checkbox.Text = parts[1];
                                AOPanel.Controls.Add(checkbox);
                            }
                            if (bool.Parse(parts[2]) == false)
                            {
                                countPanel++;
                                System.Windows.Forms.CheckBox checkbox = new System.Windows.Forms.CheckBox();
                                checkbox.Name = $"checkboxFalse{countPanel}";
                                checkbox.Dock = DockStyle.Top;
                                checkbox.Text = parts[1];
                                AOPanel.Controls.Add(checkbox);
                            }
                        }
                    }
                }
            }
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
        private int checkRes(int countPane)
        {
            bool check;
            for (int i = 1; i <= countPane; i++)
            {
                if (this.Controls.Find($"checkboxTrue{i}", true).Length != 0)
                {
                    check = ((System.Windows.Forms.CheckBox)this.Controls.Find($"checkboxTrue{i}", true)[0]).Checked;
                    if (check)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
 
        private void CheckButton_Click(object sender, EventArgs e)
        {
           
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
                range.Text = HeaderLabel.Text;

            }

            bookmark = targetDoc.Bookmarks["Результат"];
            if (bookmark != null)
            {
                Range range = bookmark.Range;
                range.Text = result.ToString();
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

            targetDoc.Close();
            wordApp.Quit();
        }
    }
}

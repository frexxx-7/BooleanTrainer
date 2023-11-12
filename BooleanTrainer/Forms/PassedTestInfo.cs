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
using Microsoft.Office.Interop.Word;

namespace BooleanTrainer.Forms
{
    public partial class PassedTestInfo : Form
    {
        private string header, result;
        public PassedTestInfo(string header, string result)
        {
            InitializeComponent();

            this.result = result;
            this.header = header;

            HeaderLabel.Text = header;
            ResultLabel.Text = result;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

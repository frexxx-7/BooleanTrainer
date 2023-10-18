using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.Classes.Theory
{
    internal class TheoryBLL
    {
        public bool SaveItem(string header, string content, Image img)
        {
            try
            {
                TheoryFunc objdal = new TheoryFunc();
                return objdal.AddItemsToTable(header,content,img);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable GetItems()
        {
            try
            {
                TheoryFunc objdal = new TheoryFunc();
                return objdal.ReadItems();
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}

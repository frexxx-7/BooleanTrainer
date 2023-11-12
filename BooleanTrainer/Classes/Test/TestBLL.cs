using BooleanTrainer.Classes.Theory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.Classes.Test
{
    internal class TestBLL
    {
        public DataTable GetItems(string idUser)
        {
            try
            {
                TestFunc objdal = new TestFunc();
                return objdal.ReadItems(idUser);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}

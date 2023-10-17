using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.Forms
{
    public partial class Main : Form
    {
        public static string login;
        private string id;
        public Main(string id)
        {
            InitializeComponent();
            this.id = id;
        }
    }
}

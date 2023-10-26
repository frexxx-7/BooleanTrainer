using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanTrainer.UserControls
{
    public partial class TheoryControlForTest : UserControl
    {
        private string header, content;
        public string id;
        public bool IsCheckBoxChecked
        {
            get { return CheckBox1.Checked; }
        }


        private void TheoryControlForTest_Load(object sender, EventArgs e)
        {
            pictureBox.Image = image;
            HeaderLabel.Text = header;
            ContentLabel.Text = content;
        }

        public Image image;
        public TheoryControlForTest(string id, string header, string content)
        {
            InitializeComponent();
            this.id = id;
            this.header = header;
            this.content = content;
        }
    }
}

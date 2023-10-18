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
    public partial class TheoryControl : UserControl
    {
        private string id, header, content;

        private void TheoryControl_Load(object sender, EventArgs e)
        {
            pictureBox.Image = image;
            HeaderLabel.Text = header;
            ContentLabel.Text = content;
        }

        private void TheoryControlPanel_MouseHover(object sender, EventArgs e)
        {
            TheoryControlPanel.FillColor = (Color)ColorConverter.ConvertFromString("#FFDFD991");
        }

        public Image image;
        public TheoryControl(string id, string header, string content)
        {
            InitializeComponent();
            this.id = id;
            this.header = header;
            this.content = content;
            
        }
    }
}

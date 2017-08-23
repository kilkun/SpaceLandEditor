using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceLandEditor
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string output { get; set; }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            output = inputBox.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}

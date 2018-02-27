using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstApp
{
    public partial class Form2 : Form
    {
        Form1 previousForm;
        public Form2()
        {
            InitializeComponent();
        }

        public void PassForwardAndShow(Form1 f)
        {
            previousForm = f;
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Hide();
        }
    }
}

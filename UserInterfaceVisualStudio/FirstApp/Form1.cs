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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IT'S ALIVE!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The temptation is too strong! We have to do it!");
            Form2 f = new Form2();
            f.PassForwardAndShow(this);
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Come on dude, cut me some slack. Fine! you clicked on " + button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string test = String.Format("Time to see how this works:\n-{0}\n{1}\n{2}", button1.Text, button2.RightToLeft, Text);
            MessageBox.Show(test);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}

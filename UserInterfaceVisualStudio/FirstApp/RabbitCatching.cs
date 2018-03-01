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
    public partial class RabbitCatching : Form
    {
        Random r = new Random();
        int maxX, maxY;
        Form caller;

        public RabbitCatching()
        {
            InitializeComponent();
        }

        public RabbitCatching(Form caller)
        {
            this.caller = caller;
            InitializeComponent();
        }

        private void ReturnToCaller(object sender, FormClosingEventArgs e)
        {
            caller.Show();
        }

        private void Rabbit_Click(object sender, EventArgs e)
        {
            maxX = Size.Width - Rabbit.Size.Width;
            maxY = Size.Height - Rabbit.Size.Height;

            Rabbit.Location= new System.Drawing.Point(r.Next(maxX), r.Next(maxY));
        }
    }
}

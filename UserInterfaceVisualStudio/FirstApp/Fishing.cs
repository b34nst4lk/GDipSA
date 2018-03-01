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
    public partial class Fishing : Form
    {
        int maxX, maxY;
        Random r = new Random();
        Form caller;

        public Fishing()
        {
            InitializeComponent();
        }
        
        public Fishing(Form caller)
        {
            this.caller = caller;
            InitializeComponent();
        }

        private void ReturnToCaller(object sender, FormClosingEventArgs e)
        {
            caller.Show();
        }

        private void FishEscape(object sender, EventArgs e)
        {
            maxX = Size.Width - Fish.Size.Width;
            maxY = Size.Height - Fish.Size.Height;

            Fish.Location= new Point(r.Next(maxX), r.Next(maxY));
        }
    }
}

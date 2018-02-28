using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FirstApp
{
    public partial class RabbitSnatching : Form
    {
        int maxX, maxY;
        Random r = new Random();
        Form caller;

        public RabbitSnatching()
        {
            InitializeComponent();
        }

        public RabbitSnatching(Form caller)
        {
            this.caller = caller;
            InitializeComponent();
        }

        private void RabbitFleeing(object sender, MouseEventArgs e)
        {
            string folderPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            Rabbit.Image = Image.FromFile(folderPath + @"\resources\img\butt_rabbit.png");
        }

        private void ReturnToCaller(object sender, EventArgs e)
        {
            caller.Show();
        }

        private void RabbitReturning(object sender, MouseEventArgs e)
        {
            string folderPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            Rabbit.Image = Image.FromFile(folderPath + @"\resources\img\cool_rabbit.png");
            maxX = Size.Width - Rabbit.Size.Width;
            maxY = Size.Height - Rabbit.Size.Height;

            Rabbit.Location= new System.Drawing.Point(r.Next(maxX), r.Next(maxY));
        }
    }
}

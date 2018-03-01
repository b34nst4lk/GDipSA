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
    public partial class LampRubbing : Form
    {
        Form caller;
        int oHeight, oWidth;

        public LampRubbing()
        {
            InitializeComponent();
        }

        public LampRubbing(Form caller)
        {
            this.caller = caller;
            InitializeComponent();
            oHeight = Genie.Height;
            oWidth = Genie.Width;
        }

        private void Vanish(object sender, EventArgs e)
        {
            Genie.Visible = false;
            Genie.Height = oHeight;
            Genie.Width = oWidth;
        }

        private void SummonGenie(object sender, EventArgs e)
        {
            if (!Genie.Visible)
            {
                Genie.Visible = true;
            }
        }

        private void RubGenie(object sender, EventArgs e)
        {
            if (!Genie.Visible)
            {
                SummonGenie(sender, e);
            }
            else
            {
                Genie.Height *= 2;
                Genie.Width *= 2;
            }
        }

        private void ReturnToCaller(object sender, FormClosingEventArgs e)
        {
            caller.Show();
        }
    }
}

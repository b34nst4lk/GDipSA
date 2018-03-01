using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentalCustomerApp
{ 
    public partial class Menu : Form
    {
        protected Form caller;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(Form caller): this()
        {
            this.caller = caller;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            caller.Show();
            Hide();
        }
        
        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to exit? All unsaved items will be lost", "Exit", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (caller is null)
            {
                Back.Visible = false;
            }
        }
    }
}

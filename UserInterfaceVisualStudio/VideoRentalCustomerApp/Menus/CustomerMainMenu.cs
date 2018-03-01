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
    public partial class CustomerMainMenu : Menu
    {
        public CustomerMainMenu()
        {
            InitializeComponent();
        }

        public CustomerMainMenu(Form caller) : base(caller) { }


    }
}

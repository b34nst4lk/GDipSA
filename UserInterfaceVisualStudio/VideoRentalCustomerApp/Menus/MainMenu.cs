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
    public partial class MainMenu : Menu
    {
        Dictionary<String, Menu> namedMenus = new Dictionary<String, Menu>();
        public MainMenu() : base()
        {
            InitializeComponent();
            namedMenus.Add("RentVideoButton", null);
            namedMenus.Add("MaintainVideoRecordsButton", null);
            namedMenus.Add("MaintainCustomersButton", null);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (namedMenus["RentVideoButton"] is null)
            {
                namedMenus["RentVideoButton"] = new RentVideoMenu(this);
            }
            if (namedMenus["MaintainVideoRecordsButton"] is null)
            {
                namedMenus["MaintainVideoRecordsButton"] = new VideoDBMenu(this);
            }
            if (namedMenus["MaintainCustomersButton"] is null)
            {
                namedMenus["MaintainCustomersButton"] = new CustomerMainMenu(this);
            }
        }       

        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            if (sender is Button src)
            {
                if (namedMenus.ContainsKey(src.Name))
                {
                    namedMenus[src.Name].Show();
                    Hide();
                }
                else
                {
                    throw new NoSuchTarget(String.Format("There is no target for the button named '{0}'", src.Name));
                }
            }
            else
            {
                throw new UnexpectedType(String.Format("Button Type is expected. Received {0} instead", sender.GetType()));
            }
        }
    }
}

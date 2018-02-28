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
    public partial class MainMenu : Form
    {

        Dictionary<string, Form> fDict = new Dictionary<string, Form>();

        public MainMenu()
        {
            InitializeComponent();
            fDict.Add("Rabbit Catching", new RabbitCatching(this));
            fDict.Add("Rabbit Snatching", new RabbitSnatching(this));
            fDict.Add("Fishing", new Fishing(this));
            fDict.Add("Lamp Rubbing", new LampRubbing(this));
        }

        private void Caller(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            fDict[button.Text].Show();
            Hide();
        }
    }
}

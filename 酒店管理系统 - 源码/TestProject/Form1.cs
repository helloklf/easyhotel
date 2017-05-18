using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Inform.MessageWindow mw = new Inform.MessageWindow(); mw.Show();
            DllSettingPanel.Setting_Page sp = new DllSettingPanel.Setting_Page();
        }
    }
}

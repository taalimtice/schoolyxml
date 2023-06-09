using FoxLearn.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schooly
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }


        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblProductID.Text = ComputerInfo.GetComputerId();
            lblLicenseType.Text = Properties.Settings.Default.licType;
            lblProductKey.Text = Properties.Settings.Default.Key;
            lblProductName.Text = "School Moroccan's Organiser System SMOS (Schooly)";
            lblDaysleft.Text = Properties.Settings.Default.DaysLeft;

        }
    }
}

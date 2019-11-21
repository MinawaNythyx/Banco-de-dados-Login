using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        databaseUse dtb = new databaseUse();
        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            dtb.VerifyDB(usertxt.Text, passtxt.Text);
            //dtb.ReadDB();
        }

        private void createlogin_Click(object sender, EventArgs e)
        {
            dtb.InsertDB(usertxt.Text, passtxt.Text);
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

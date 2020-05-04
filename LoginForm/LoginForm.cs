using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        DatabaseConnection Obj_data = new DatabaseConnection();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            var RegForm_Obj = new RegForm();
            RegForm_Obj.Closed += (s, args) => this.Close();
            RegForm_Obj.Show();

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string message = Obj_data.Login(txt_UserName.Text, txt_Password.Text);
            if(message == "User Login Successfully")
            {
                MessageBox.Show(message);
                this.Hide();
                var DashboardForm_Obj = new DashboardForm();
                DashboardForm_Obj.Closed += (s, args) => this.Close();
                DashboardForm_Obj.Show();
            }
            else
            {
                MessageBox.Show(message);
            }

        }
    }
}

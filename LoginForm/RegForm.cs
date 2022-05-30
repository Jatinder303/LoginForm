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
    public partial class RegForm : Form
    {
        Registration_Class Obj_Reg = new Registration_Class();
        public RegForm()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            string message = Obj_Reg.Registration(txt_UserName.Text, txt_Email.Text, txt_Password.Text);
            MessageBox.Show(message);
            txt_UserName.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var LoginForm_Obj = new LoginForm();
            LoginForm_Obj.Closed += (s, args) => this.Close();
            LoginForm_Obj.Show();
        }
    }
}

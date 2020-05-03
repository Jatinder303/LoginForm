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
        DatabaseConnection Obj_data = new DatabaseConnection();
        public RegForm()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            string message = Obj_data.Registration(txt_UserName.Text, txt_Email.Text, txt_Password.Text);
            MessageBox.Show(message);
        }
    }
}

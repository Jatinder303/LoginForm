using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class Registration_Class
    {
        private SqlConnection Obj_Conn = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        private SqlDataReader Reader_Login;
        string QueryString;

        public Registration_Class()
        {
            string ConnString = @"Data Source=T2152\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True";
            Obj_Conn.ConnectionString = ConnString;
        }
        
        public string Registration(string UserName, string Email, string Password)
        {
            try
            {
                Cmd.Parameters.Clear();
                Cmd.Connection = Obj_Conn;

                QueryString = "Insert into UserDetails(UserName,Email, Password) Values(@UserName, @Email, @Password)";

                Cmd.Parameters.AddWithValue("@UserName",UserName);
                Cmd.Parameters.AddWithValue("@Email", Email);
                Cmd.Parameters.AddWithValue("@Password", Password);

                Cmd.CommandText = QueryString;

                //connection opened
                Obj_Conn.Open();

                // Executed query
                Cmd.ExecuteNonQuery();

                return "User registered Successfully";
            }
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (Obj_Conn != null)
                {
                    Obj_Conn.Close();
                }
            }
        }


         
    }
}

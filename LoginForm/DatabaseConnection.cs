﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class DatabaseConnection
    {
        private SqlConnection Obj_Conn = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        private SqlDataReader Reader_Login;
        string QueryString;

        public DatabaseConnection()
        {
            string ConnString = @"Data Source=LAPTOP-RAKIOMBV;Initial Catalog=Libaray;Integrated Security=True";
            Obj_Conn.ConnectionString = ConnString;
        }
        
        public string Login(string username, string password)
        {
            try
            {
                Cmd.Connection = Obj_Conn;
                QueryString = "Select UserName, Password from UserDetails where UserName =  @UserName  and Password =  @Password ";
                Cmd.Parameters.AddWithValue("@UserName", username);
                Cmd.Parameters.AddWithValue("@Password", password);

                Cmd.CommandText = QueryString;
                //connection opened
                Obj_Conn.Open();

                // get data stream
                Reader_Login = Cmd.ExecuteReader();
                if (Reader_Login.HasRows)
                {
                    return "User Login Successfully"; ;
                }
                else
                {
                    return "User details are not correct";
                }
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

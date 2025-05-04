using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurent_app
{
    public partial class Login : Form
    {
        public string connectionString = "Data Source=FURBA;Initial Catalog=RestaurentDB;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Choose a shift", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string checkEmailQuery = "SELECT * from UserDetails WHERE UserName=@UserName and Password=@Password";
                        SqlCommand cmd = new SqlCommand(checkEmailQuery, conn);
                        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        txtUserName.Clear();
                        txtPassword.Clear();
                        int count = (int)cmd.ExecuteScalar();
                        conn.Close();
                        if (count > 0)
                        {
                            MessageBox.Show("Login Successfull", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DashBoard dashBoard = new DashBoard();
                            dashBoard.Show();
                        }
                        else
                        {
                            MessageBox.Show("User not found", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    catch { }
                    finally { }
                }
            }

        }

        private void txtSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

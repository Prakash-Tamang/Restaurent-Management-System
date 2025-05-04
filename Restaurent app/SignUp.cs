using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurent_app
{
    public partial class SignUp : Form
    {
        public string connectionString = "Data Source=FURBA;Initial Catalog=RestaurentDB;Integrated Security=True";
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "User Name is required.");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password is required.");
            }
            if (txtPassword.Text != txtCPassword.Text)
            {
                errorProvider1.SetError(txtCPassword, "Please enter same password.");
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email is required");
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Enter your address.");
            }
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Enter your full name.");
            }
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                errorProvider1.SetError(txtPhoneNumber, "Enter Phone number.");
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO UserDetails VALUES(@UserName,@Password,@PhoneNumber,@Email,@Address,@FullName)";
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("Username", txtUserName.Text);
                    command.Parameters.AddWithValue("Password", txtPassword.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                    command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MessageBox.Show("Registration Successfull","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
        private void SignUp_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtCPassword.Focus();
            }
        }

        private void txtCPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
                {
                txtPhoneNumber.Focus();
            }
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmail.Focus();
            }
        }

    }
}

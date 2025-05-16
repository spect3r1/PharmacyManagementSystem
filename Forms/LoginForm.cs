using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly List<Staff> staff;

        public LoginForm()
        {
            InitializeComponent();
            // Hardcoded staff for demo (in practice, load from file or database)
            staff = new List<Staff>
            {
                new Staff(1, "Admin", "Admin", "admin", "password123")
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var user = staff.Find(s => s.Login(username, password));
            if (user != null)
            {
                // Open MainForm
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide(); // Hide login form
            }
            else
            {
                lblError.Text = "Invalid username or password.";
                lblError.Visible = true;
            }
        }
    }
}
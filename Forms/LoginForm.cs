using CoffeeManagementSystem.Models.Classes;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CoffeeManagementSystem.Models.Enum;

namespace CoffeeManagementSystem
{
    public partial class LoginForm : Form
    {
        private readonly CoffeeManagementSystemManager _manager = new CoffeeManagementSystemManager();

        public LoginForm()
        {
            InitializeComponent();
            CheckInitialSetup();
            btnLogin.Click += BtnLogin_Click;
            this.FormClosed += LoginForm_FormClosed;
        }

        private void CheckInitialSetup()
        {
            try
            {
                if (!_manager.HasAnyUsers())
                {
                    Employee adminEmp = new Employee(1, "Admin", Gender.Male, DateTime.Today.AddYears(-20), "000000000", "admin@coffee.com", "Manager", false);
                    _manager.AddEmployee(adminEmp);
                    _manager.CreateNewUser("Admin123@", adminEmp, "Admin");
                    
                    MessageBox.Show("Initial admin account created. Username: Admin (Name), Password: Admin123@", "Setup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Setup error: {ex.Message}. Check database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_manager.VerifyUser(email, password, out User user))
            {
                try
                {
                    MainForm mainForm = new MainForm(user);
                    mainForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load the Main Application: {ex.Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Clear();
                txtEmail.Focus();
            }
        }
    }
}

using CoffeeManagementSystem.Models.Classes;
using CoffeeManagementSystem.UserControls.AdminUserControls;
using CoffeeManagementSystem.UserControls.EmployeeUserControls;
using System;
using System.Windows.Forms;

namespace CoffeeManagementSystem
{
    public partial class MainForm : Form
    {
        private readonly CoffeeManagementSystemManager _manager = new CoffeeManagementSystemManager();
        public User CurrentUser { get; private set; }

        public MainForm(User user)
        {
            InitializeComponent();
            this.CurrentUser = user;
            this.Text = $"Coffee Management System - {user.employee.Name} ({user.Role})";
            this.FormClosed += MainForm_FormClosed;

            LoadNavigation();
            btnLogo.Click += (s, e) => {
                if (user.Role == "Admin" || user.Role == "Manager")
                    BtnReport_Click(s, e);
                else
                    BtnPOS_Click(s, e);
            };
        }

        private void LoadNavigation()
        {
            pnlNavigations.Controls.Clear();

            if (CurrentUser.Role == "Admin" || CurrentUser.Role == "Manager")
            {
                AdminNavControl adminNavControl = new AdminNavControl();
                adminNavControl.ReportButtonClicked += BtnReport_Click;
                adminNavControl.InventoryButtonClicked += BtnInventory_Click;
                adminNavControl.MenuButtonClicked += BtnMenu_Click;
                adminNavControl.UsersButtonClicked += BtnUsers_Click;
                adminNavControl.EmployeesButtonClicked += BtnEmployees_Click;
                adminNavControl.LogOutButtonClicked += BtnLogOut_Click;

                adminNavControl.Dock = DockStyle.Fill;
                pnlNavigations.Controls.Add(adminNavControl);
                
                BtnReport_Click(this, EventArgs.Empty);
            }
            else
            {
                EmployeeNavControl employeeNavControl = new EmployeeNavControl();
                employeeNavControl.ReportButtonClicked += BtnReport_Click;
                employeeNavControl.POSButtonClicked += BtnPOS_Click;
                employeeNavControl.InventoryButtonClicked += BtnInventory_Click;
                employeeNavControl.LogOutButtonClicked += BtnLogOut_Click;

                employeeNavControl.Dock = DockStyle.Fill;
                pnlNavigations.Controls.Add(employeeNavControl);
                
                BtnReport_Click(this, EventArgs.Empty);
            }
        }

        private void LoadUserControl(UserControl userControl)
        {
            pnlMain.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(userControl);
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "Report";

            pnlMain.Controls.Clear();

            ReportControl reportControl = new ReportControl(_manager);
            LoadUserControl(reportControl);
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "Inventory";

            pnlMain.Controls.Clear();

            InventoryControl inventoryControl = new InventoryControl(_manager);
            LoadUserControl(inventoryControl);
        }

        public void BtnMenu_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "Menu";

            pnlMain.Controls.Clear();

            MenuControl menuControl = new MenuControl(_manager);
            LoadUserControl(menuControl);
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "Users";

            pnlMain.Controls.Clear();

            UsersControl usersControl = new UsersControl(_manager);
            LoadUserControl(usersControl);
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "Employees";

            pnlMain.Controls.Clear();

            EmployeesControl employeesControl = new EmployeesControl(_manager);
            LoadUserControl(employeesControl);
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "Point of Sale";

            pnlMain.Controls.Clear();

            POSControl posControl = new POSControl(_manager, CurrentUser);
            LoadUserControl(posControl);
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                this.Hide();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }  
}

using System;
using System.Windows.Forms;

namespace CoffeeManagementSystem.UserControls.AdminUserControls
{
    public partial class AdminNavControl : UserControl
    {
        public event EventHandler ReportButtonClicked;
        public event EventHandler InventoryButtonClicked;
        public event EventHandler MenuButtonClicked;
        public event EventHandler UsersButtonClicked;
        public event EventHandler EmployeesButtonClicked;

        public event EventHandler LogOutButtonClicked;
        public AdminNavControl()
        {
            InitializeComponent();

            btnReport.Click += btnReport_Click;
            btnInventory.Click += btnInventory_Click;
            btnMenu.Click += btnMenu_Click;
            btnUsers.Click += btnUsers_Click;
            btnEmployees.Click += btnEmployees_Click;

            btnLogOut.Click += (s, e) => LogOutButtonClicked?.Invoke(s, e);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnReport.BackColor = System.Drawing.Color.Wheat;

            ReportButtonClicked?.Invoke(sender, e);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnInventory.BackColor = System.Drawing.Color.Wheat;

            InventoryButtonClicked?.Invoke(sender, e);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnMenu.BackColor = System.Drawing.Color.Wheat;

            MenuButtonClicked?.Invoke(sender, e);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnUsers.BackColor = System.Drawing.Color.Wheat;

            UsersButtonClicked?.Invoke(sender, e);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnEmployees.BackColor = System.Drawing.Color.Wheat;

            EmployeesButtonClicked?.Invoke(sender, e);
        }

        private void ClearNavBtnHighlight()
        {
            btnReport.BackColor = System.Drawing.SystemColors.Control;
            btnInventory.BackColor = System.Drawing.SystemColors.Control;
            btnMenu.BackColor = System.Drawing.SystemColors.Control;
            btnUsers.BackColor = System.Drawing.SystemColors.Control;
            btnEmployees.BackColor = System.Drawing.SystemColors.Control;
        }

    }
}

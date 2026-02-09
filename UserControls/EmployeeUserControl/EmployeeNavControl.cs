using System;
using System.Windows.Forms;

namespace CoffeeManagementSystem.UserControls.EmployeeUserControls
{
    public partial class EmployeeNavControl : UserControl
    {
        public event EventHandler ReportButtonClicked;
        public event EventHandler POSButtonClicked;
        public event EventHandler InventoryButtonClicked;

        public event EventHandler LogOutButtonClicked;
        public EmployeeNavControl()
        {
            InitializeComponent();

            btnReport.Click += btnReport_Click;
            btnPOS.Click += btnPOS_Click;
            btnInventory.Click += btnInventory_Click;

            btnLogOut.Click += (s, e) => LogOutButtonClicked?.Invoke(s, e);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnReport.BackColor = System.Drawing.Color.Wheat;

            ReportButtonClicked?.Invoke(sender, e);
        }
        private void btnPOS_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnPOS.BackColor = System.Drawing.Color.Wheat;

            POSButtonClicked?.Invoke(sender, e);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            ClearNavBtnHighlight();
            btnInventory.BackColor = System.Drawing.Color.Wheat;

            InventoryButtonClicked?.Invoke(sender, e);
        }

        private void ClearNavBtnHighlight()
        {
            btnReport.BackColor = System.Drawing.SystemColors.Control;
            btnPOS.BackColor = System.Drawing.SystemColors.Control;
            btnInventory.BackColor = System.Drawing.SystemColors.Control;
        }
    }
}

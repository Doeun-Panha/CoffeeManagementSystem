using CoffeeManagementSystem.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Menu = CoffeeManagementSystem.Models.Classes.Menu;

namespace CoffeeManagementSystem
{
    public partial class POSControl : UserControl
    {
        private readonly CoffeeManagementSystemManager _manager;
        private readonly User _currentUser;
        private List<ReportDetail> _orderItems = new List<ReportDetail>();
        private Timer _timer;

        public POSControl(CoffeeManagementSystemManager manager, User user)
        {
            InitializeComponent();
            _manager = manager;
            _currentUser = user;
            this.Text = "Sale Management";

            txtSearch.TextChanged += Filter_ValueChanged;

            btnClear.Click += BtnClear_Click;
            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnSubmit.Click += BtnSubmit_Click;

            InitializeTimer();
            LoadReports();
            UpdateHeader();
        }

        private void UpdateHeader()
        {
             lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt");
             int nextId = _manager.GetNextReportId();
             lbOrder.Text = $"Order #{nextId}";
        }

        private void InitializeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000; // 1 second
            _timer.Tick += (s, e) => lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt");
            _timer.Start();
        }

        private void LoadReports()
        {
            ApplyFilters();
        }
        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            List<Menu> allMenuItems = _manager.GetAllMenus();
            string searchTerm = txtSearch.Text.Trim().ToLower();

            var filtered = allMenuItems.Where(t =>
                t.ID.ToString().Contains(searchTerm) ||
                t.Name.ToLower().Contains(searchTerm) ||
                t.Type.ToLower().Contains(searchTerm)
            );

            dgvMenu.DataSource = null;
            dgvMenu.DataSource = filtered.ToList();
            dgvMenu.AutoResizeColumns();
        }

        private void ClearInputs()
        {
            _orderItems.Clear();
            RefreshPreOrderGrid();
        }

        private void RefreshPreOrderGrid()
        {
            dgvPreOrder.DataSource = null;
            dgvPreOrder.DataSource = _orderItems.Select(x => new
            {
                ID = x.menu.ID,
                Name = x.menu.Name,
                Price = x.menu.Price,
                Qty = x.Qty,
                SubTotal = x.SubTotal
            }).ToList();
            if (dgvPreOrder.Columns["Price"] != null)
                dgvPreOrder.Columns["Price"].DefaultCellStyle.Format = "C2";
            if (dgvPreOrder.Columns["SubTotal"] != null)
                dgvPreOrder.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
            dgvPreOrder.AutoResizeColumns();
            
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = _orderItems.Sum(x => x.SubTotal);
            lbTotal.Text = total.ToString("C2");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMenu.SelectedRows.Count == 0 && dgvMenu.CurrentRow == null)
                    return;

                Menu selectedMenu = (Menu)dgvMenu.CurrentRow.DataBoundItem;
                if (selectedMenu == null) return;

                var existingItem = _orderItems.FirstOrDefault(x => x.menu.ID == selectedMenu.ID);

                if (existingItem != null)
                {
                    existingItem.Qty++;
                    existingItem.SubTotal = (decimal)(existingItem.Qty * existingItem.menu.Price);
                }
                else
                {
                    ReportDetail newItem = new ReportDetail
                    {
                        menu = selectedMenu,
                        Qty = 1,
                        SubTotal = (decimal)selectedMenu.Price
                    };
                    _orderItems.Add(newItem);
                }

                RefreshPreOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPreOrder.SelectedRows.Count == 0 && dgvPreOrder.CurrentRow == null)
                    return;
                
                int menuId = 0;
                if (dgvPreOrder.CurrentRow.Cells["ID"].Value != null)
                {
                    menuId = (int)dgvPreOrder.CurrentRow.Cells["ID"].Value;
                }

                ReportDetail selectedDetail = _orderItems.FirstOrDefault(x => x.menu.ID == menuId);
                
                if (selectedDetail == null) return;

                if (selectedDetail.Qty > 1)
                {
                    selectedDetail.Qty--;
                    selectedDetail.SubTotal = (decimal)(selectedDetail.Qty * selectedDetail.menu.Price);
                }
                else
                {
                    _orderItems.Remove(selectedDetail);
                }

                RefreshPreOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderItems.Count == 0)
                {
                    MessageBox.Show("Please add items to the order first.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double total = (double)_orderItems.Sum(x => x.SubTotal);
                Report tempReport = new Report
                {
                    Date = DateTime.Now,
                    Emp = _currentUser.employee,
                    Total = total,
                    Received = 0, // To be filled in Confirmation
                    Change = 0    // To be calculated in Confirmation
                };

                // Link details to report (though ID is not yet generated)
                foreach(var item in _orderItems)
                {
                    item.report = tempReport; 
                }

                CoffeeManagementSystem.Forms.OrderConfirmationForm confirmationForm = new CoffeeManagementSystem.Forms.OrderConfirmationForm(tempReport, _orderItems, _manager);
                if (confirmationForm.ShowDialog() == DialogResult.OK)
                {
                   ClearInputs();
                   UpdateHeader(); // Refresh Order ID for next order
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

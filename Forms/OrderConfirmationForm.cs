using System;
using CoffeeManagementSystem.Models.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagementSystem.Forms
{
    public partial class OrderConfirmationForm : Form
    {
        public OrderConfirmationForm()
        {
            InitializeComponent();
        }

        private Report _report;
        private List<ReportDetail> _details;
        private CoffeeManagementSystemManager _manager;

        public OrderConfirmationForm(Report report, List<ReportDetail> details, CoffeeManagementSystemManager manager) : this()
        {
            _report = report;
            _details = details;
            _manager = manager;

            LoadData();
            InitializeEvents();
        }

        private void LoadData()
        {
            lbDate.Text = _report.Date.ToString("dd/MM/yyyy h:mm:ss tt");
            lbOrder.Text = _manager.GetNextReportId().ToString();
            lbTotalNumber.Text = _report.Total.ToString("C2");
            
            dgvOrders.DataSource = _details.Select(x => new
            {
                MenuID = x.menu.ID,
                MenuName = x.menu.Name,
                Price = x.menu.Price,
                Qty = x.Qty,
                SubTotal = x.SubTotal
            }).ToList();

            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.ClearSelection();
        }

        private void InitializeEvents()
        {
            tbCashReceived.TextChanged += TbCashReceived_TextChanged;
            btnSubmit.Click += BtnSubmit_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void TbCashReceived_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbCashReceived.Text, out double cashReceived))
            {
                _report.Received = cashReceived;
                double change = cashReceived - _report.Total;
                _report.Change = change;
                lbChangesNumber.Text = change.ToString("C2");
                
                if (change < 0)
                    lbChangesNumber.ForeColor = System.Drawing.Color.Red;
                else
                    lbChangesNumber.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lbChangesNumber.Text = "$0.00";
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_report.Received < _report.Total)
                {
                    MessageBox.Show("Insufficient cash received.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _manager.AddReport(_report, _details);
                MessageBox.Show("Order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

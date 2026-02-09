using CoffeeManagementSystem.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagementSystem
{
    public partial class ReportControl : UserControl
    {
        private readonly CoffeeManagementSystemManager _manager;
        public ReportControl(CoffeeManagementSystemManager manager)
        {
            InitializeComponent();
            _manager = manager;
            this.Text = "Report";

            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today;

            InitializeEmployeeComboBox();

            txtSearch.TextChanged += Filter_ValueChanged;
            dateTimePickerFrom.ValueChanged += Filter_ValueChanged;
            dateTimePickerTo.ValueChanged += Filter_ValueChanged;
            cbEmployee.SelectedIndexChanged += Filter_ValueChanged;

            btnExport.Click += BtnExport_Click;
            btnRefresh.Click += BtnRefresh_Click;

            dataGridReport.CellClick += DataGridReport_CellClick;

            LoadReports();
        }

        private void InitializeEmployeeComboBox()
        {
            cbEmployee.Items.Clear();
            cbEmployee.Items.Add("All");
            
            var employees = _manager.GetAllEmployees().Where(emp => emp.Pos.Equals("Staff", StringComparison.OrdinalIgnoreCase));
            foreach (var emp in employees)
            {
                cbEmployee.Items.Add(emp.Name);
            }
            
            cbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEmployee.SelectedIndex = 0;
        }

        private void LoadReports()
        {
            List<Report> allReports = _manager.GetAllReports();

            dataGridReport.DataSource = null;
            dataGridReport.DataSource = allReports;

            ConfigureSalesGrid();

            lbTotalRevenuesNumber.Text = allReports.Sum(r => r.Total).ToString("C2");
            lbTotalSalesNumber.Text = allReports.Count.ToString();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today;
            LoadReports();
        }

        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ConfigureSalesGrid()
        {
            dataGridReport.Columns.Clear();
            dataGridReport.AutoGenerateColumns = false;

            dataGridReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ID", HeaderText = "Report ID" });
            dataGridReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Date", HeaderText = "Date" });
            dataGridReport.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Employee", HeaderText = "Employee" });
            dataGridReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Total", HeaderText = "Total", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dataGridReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Received", HeaderText = "Received", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dataGridReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Change", HeaderText = "Change", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });

            dataGridReport.CellFormatting -= DataGridReport_CellFormatting;
            dataGridReport.CellFormatting += DataGridReport_CellFormatting;

            dataGridReport.AutoResizeColumns();
        }

        private void DataGridReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridReport.Rows[e.RowIndex].DataBoundItem is Report report)
            {
                if (dataGridReport.Columns[e.ColumnIndex].Name == "Employee")
                {
                    e.Value = report.Emp?.Name ?? "N/A";
                    e.FormattingApplied = true;
                }
            }
        }

        private void DataGridReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridReport.Rows[e.RowIndex].DataBoundItem is Report selected)
            {
                dataGridReportDetail.DataSource = null;
                var details = _manager.GetReportDetails(selected.ID);
                
                dataGridReportDetail.DataSource = details.Select(d => new 
                {
                    d.menu.Name,
                    d.menu.Type,
                    d.menu.Price,
                    d.Qty,
                    d.SubTotal
                }).ToList();

                dataGridReportDetail.AutoResizeColumns();
            }
        }
        private void ApplyFilters()
        {
            List<Report> allReports = _manager.GetAllReports();

            string searchTerm = txtSearch.Text.Trim().ToLower();
            DateTime startDate = dateTimePickerFrom.Value.Date;
            DateTime endDate = dateTimePickerTo.Value.Date.AddDays(1).AddSeconds(-1);

            var filtered = allReports.Where(r => r.Date >= startDate && r.Date <= endDate);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filtered = filtered.Where(r =>
                    r.ID.ToString().Contains(searchTerm) ||
                    (r.Emp != null && r.Emp.Name.ToLower().Contains(searchTerm))
                );
            }

            // LOGIC IMPROVEMENT: Filter by Employee
            if (cbEmployee.SelectedItem != null && cbEmployee.SelectedItem.ToString() != "All")
            {
                string selectedEmpName = cbEmployee.SelectedItem.ToString();
                filtered = filtered.Where(r => r.Emp != null && r.Emp.Name == selectedEmpName);
            }

            var resultList = filtered.ToList();

            dataGridReport.DataSource = null;
            dataGridReport.DataSource = resultList;

            ConfigureSalesGrid();

            lbTotalRevenuesNumber.Text = resultList.Sum(r => r.Total).ToString("C2");
            lbTotalSalesNumber.Text = resultList.Count.ToString();
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName = "Sales_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                IEnumerable<string> header = dataGridReport.Columns.Cast<DataGridViewColumn>()
                                                    .Select(column => $"\"{column.HeaderText}\"");
                sb.AppendLine(string.Join(",", header));

                foreach (DataGridViewRow row in dataGridReport.Rows)
                {
                    if (!row.IsNewRow && row.DataBoundItem is Report report)
                    {
                        IEnumerable<string> cells = dataGridReport.Columns.Cast<DataGridViewColumn>()
                            .Select(column =>
                            {
                                string value;
                                if (column.Name == "Employee")
                                {
                                    value = report.Emp?.Name;
                                }
                                else
                                {
                                    value = row.Cells[column.Index].Value?.ToString();
                                }

                                return $"\"{value?.Replace("\"", "\"\"")}\"";
                            });

                        sb.AppendLine(string.Join(",", cells));
                    }
                }

                try
                {
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"Data exported successfully to: {sfd.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during export: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

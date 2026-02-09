using CoffeeManagementSystem.Models.Classes;
using CoffeeManagementSystem.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeManagementSystem
{
    public partial class EmployeesControl : UserControl
    {
        private readonly CoffeeManagementSystemManager _manager;
        public EmployeesControl(CoffeeManagementSystemManager manager)
        {
            InitializeComponent();
            _manager = manager;
            this.Text = "Employee Management";

            txtSearch.TextChanged += Filter_ValueChanged;

            btnClear.Click += BtnClear_Click;
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;

            this.dataGridEmployee.CellClick += DataGridEmployee_CellClick;

            InitializeGenderComboBox();
            ConfigureGrid();
            LoadEmployees();
        }

        private void InitializeGenderComboBox()
        {
            cbGender.Items.Clear();
            foreach (var gender in Enum.GetValues(typeof(Gender)))
            {
                cbGender.Items.Add(gender);
            }
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.SelectedIndex = 0; 
        }

        private void LoadEmployees()
        {
            ApplyFilters();
        }

        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            List<Employee> allEmployees = _manager.GetAllEmployees();

            string searchTerm = txtSearch.Text.Trim().ToLower();

            var filteredEmployees = allEmployees.Where(e =>
                e.ID.ToString().Contains(searchTerm) ||
                e.Name.ToLower().Contains(searchTerm) ||
                (e.Email != null && e.Email.ToLower().Contains(searchTerm)) ||
                (e.Phone != null && e.Phone.ToLower().Contains(searchTerm)) ||
                (e.Pos != null && e.Pos.ToLower().Contains(searchTerm))
            );

            dataGridEmployee.DataSource = null;
            dataGridEmployee.DataSource = filteredEmployees.ToList();
        }

        private void ConfigureGrid()
        {
            dataGridEmployee.AutoGenerateColumns = false;
            dataGridEmployee.Columns.Clear();

            dataGridEmployee.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ID", HeaderText = "ID" });
            dataGridEmployee.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Name", HeaderText = "Name" });
            dataGridEmployee.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Gender", HeaderText = "Gender" });
            dataGridEmployee.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "DoB", HeaderText = "Date of Birth" });
            dataGridEmployee.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Phone", HeaderText = "Phone" });
            dataGridEmployee.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Email", HeaderText = "Email" });
            dataGridEmployee.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Pos", HeaderText = "Position" });
            dataGridEmployee.Columns.Add(new DataGridViewCheckBoxColumn() { DataPropertyName = "StopWork", HeaderText = "Stop Work" });

            dataGridEmployee.AutoResizeColumns();
        }
        private void ClearInputs()
        {
            txtName.Clear();
            cbGender.SelectedIndex = 0;
            dateTimePickerDoB.Value = DateTime.Now;
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtPosition.Clear();
            chbStopWork.Checked = false;
            txtName.Focus();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    cbGender.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    MessageBox.Show("Name, Gender, and Phone Number are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime dob = dateTimePickerDoB.Value;
                Gender gender = cbGender.SelectedItem is Gender g ? g : Gender.NotSpecified;

                Employee newEmployee = new Employee
                {
                    Name = txtName.Text.Trim(),
                    Gender = gender,
                    DoB = dob,
                    Phone = txtPhoneNumber.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Pos = txtPosition.Text.Trim(),
                    StopWork = chbStopWork.Checked
                };

                _manager.AddEmployee(newEmployee);

                MessageBox.Show("Employee recorded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridEmployee.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Employee selected = (Employee)dataGridEmployee.CurrentRow.DataBoundItem;
                
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    cbGender.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    MessageBox.Show("Name, Gender, and Phone Number are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime dob = dateTimePickerDoB.Value;

                Gender gender = cbGender.SelectedItem is Gender g ? g : Gender.NotSpecified;

                selected.Name = txtName.Text.Trim();
                selected.Gender = gender;
                selected.DoB = dob;
                selected.Phone = txtPhoneNumber.Text.Trim();
                selected.Email = txtEmail.Text.Trim();
                selected.Pos = txtPosition.Text.Trim();
                selected.StopWork = chbStopWork.Checked;

                _manager.UpdateEmployee(selected);

                MessageBox.Show($"Employee ID {selected.ID} updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridEmployee.CurrentRow == null)
            {
                MessageBox.Show("Please select an employee to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Employee selected = (Employee)dataGridEmployee.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete employee ID {selected.ID}?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _manager.DeleteEmployee(selected.ID);

                    MessageBox.Show($"Employee ID {selected.ID} deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridEmployee.Rows[e.RowIndex].DataBoundItem is Employee selectedEmployee)
            {
                txtName.Text = selectedEmployee.Name;
                cbGender.SelectedItem = selectedEmployee.Gender;
                dateTimePickerDoB.Value = selectedEmployee.DoB;
                txtPhoneNumber.Text = selectedEmployee.Phone;
                txtEmail.Text = selectedEmployee.Email;
                txtPosition.Text = selectedEmployee.Pos;
                chbStopWork.Checked = selectedEmployee.StopWork;
            }
        }

    }
}

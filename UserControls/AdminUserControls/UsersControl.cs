using CoffeeManagementSystem.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeManagementSystem
{
    public partial class UsersControl : UserControl
    {
        private readonly CoffeeManagementSystemManager _manager;
        public UsersControl(CoffeeManagementSystemManager manager)
        {
            InitializeComponent();
            _manager = manager;
            this.Text = "User Management";
            
            InitializeEmployeeComboBox();
            InitializeRoleComboBox();
            LoadUsers();

            cbEmployee.SelectedIndexChanged += CbEmployee_SelectedIndexChanged;

            txtSearch.TextChanged += Filter_ValueChanged;
            dataGridUsers.CellClick += DataGridUsers_CellClick;

            btnClear.Click += BtnClear_Click;
            btnCreate.Click += BtnCreate_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void InitializeEmployeeComboBox()
        {
            cbEmployee.DataSource = _manager.GetAllEmployees();
            cbEmployee.DisplayMember = "Name";
            cbEmployee.ValueMember = "ID";
            cbEmployee.SelectedIndex = -1;
        }

        private void InitializeRoleComboBox()
        {
            cbRole.Items.Clear();
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Manager");
            cbRole.Items.Add("Staff");
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.SelectedIndex = -1;
        }

        private void CbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmployee.SelectedItem is Employee emp)
            {
                txtEmail.Text = emp.Email;
                var existingUser = _manager.GetAllUsers().FirstOrDefault(u => u.employee != null && u.employee.ID == emp.ID);
                if (existingUser != null)
                {
                    cbRole.SelectedItem = existingUser.Role;
                }
                else
                {
                    cbRole.SelectedIndex = -1;
                    txtPassword.Clear();
                }
            }
            else
            {
                txtEmail.Clear();
                cbRole.SelectedIndex = -1;
            }
        }

        private void LoadUsers()
        {
            ApplyFilters();
        }

        private void ClearInputs()
        {
            cbEmployee.SelectedIndex = -1;
            txtPassword.Clear();
            cbRole.SelectedIndex = -1;
            txtEmail.Clear();
            cbEmployee.Focus();
        }

        private void DataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridUsers.Rows[e.RowIndex].DataBoundItem is User selectedUser)
            {
                cbEmployee.SelectedValue = selectedUser.employee?.ID ?? -1;
                cbRole.SelectedItem = selectedUser.Role;
                txtEmail.Text = selectedUser.employee?.Email ?? "";
            }
        }

        private void ConfigureUsersGrid()
        {
            dataGridUsers.Columns.Clear();
            dataGridUsers.AutoGenerateColumns = false;

            dataGridUsers.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ID", HeaderText = "User ID", Visible = true });
            dataGridUsers.Columns.Add(new DataGridViewTextBoxColumn() { Name = "EmployeeName", HeaderText = "Employee Name" });
            dataGridUsers.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Role", HeaderText = "Role" });

            dataGridUsers.CellFormatting -= DataGridUsers_CellFormatting;
            dataGridUsers.CellFormatting += DataGridUsers_CellFormatting;

            dataGridUsers.AutoResizeColumns();
        }

        private void DataGridUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridUsers.Rows[e.RowIndex].DataBoundItem is User user)
            {
                if (dataGridUsers.Columns[e.ColumnIndex].Name == "EmployeeName")
                {
                    e.Value = user.employee?.Name ?? "N/A";
                    e.FormattingApplied = true;
                }
            }
        }

        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            List<User> allUsers = _manager.GetAllUsers();
            string searchTerm = txtSearch.Text.Trim().ToLower();

            string selectedRole = cbRole.SelectedItem?.ToString();
            
            var filtered = allUsers.Where(t =>
                ((t.employee != null && t.employee.Name.ToLower().Contains(searchTerm)) ||
                 (t.Role != null && t.Role.ToLower().Contains(searchTerm)) ||
                 t.ID.ToString().Contains(searchTerm) || 
                 t.Role == selectedRole)
            );

            dataGridUsers.DataSource = null;
            dataGridUsers.DataSource = filtered.ToList();
            
            ConfigureUsersGrid();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (cbEmployee.SelectedItem == null || string.IsNullOrWhiteSpace(txtPassword.Text) || cbRole.SelectedItem == null)
            {
                MessageBox.Show("Employee, Password, and Role are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Employee emp = (Employee)cbEmployee.SelectedItem;

                if (emp.StopWork)
                {
                    MessageBox.Show($"Cannot create a user account for '{emp.Name}' because they are marked as 'Stopped Work'.", "Action Prohibited", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool alreadyHasUser = _manager.GetAllUsers().Any(u => u.employee != null && u.employee.ID == emp.ID);
                if (alreadyHasUser)
                {
                    MessageBox.Show($"'{emp.Name}' already has a user account. Please update the existing account instead.", "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string password = txtPassword.Text;
                string role = cbRole.SelectedItem.ToString();

                User newUser = new User
                {
                    employee = emp,
                    Password = password,
                    Role = role
                };

                _manager.AddUser(newUser);

                MessageBox.Show($"User record for '{emp.Name}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User selectedUser = (User)dataGridUsers.CurrentRow.DataBoundItem;

                if (selectedUser.employee != null && selectedUser.employee.StopWork)
                {
                    MessageBox.Show($"Cannot update user account for '{selectedUser.employee.Name}' because they are marked as 'Stopped Work'.", "Action Prohibited", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbRole.SelectedItem == null)
                {
                    MessageBox.Show("Role is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string newRole = cbRole.SelectedItem.ToString();
                string newPassword = txtPassword.Text;
                bool passwordChanged = !string.IsNullOrWhiteSpace(newPassword);

                selectedUser.Role = newRole;
                if (passwordChanged)
                {
                    selectedUser.Password = newPassword;
                }

                _manager.UpdateUser(selectedUser, passwordChanged);

                MessageBox.Show($"User record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User selectedUser = (User)dataGridUsers.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show(
                $"WARNING: Are you sure you want to permanently delete user account for '{selectedUser.employee?.Name}'?",
                "Confirm User Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _manager.DeleteUser(selectedUser.ID);
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

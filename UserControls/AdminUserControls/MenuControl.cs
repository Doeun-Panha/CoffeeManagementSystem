using CoffeeManagementSystem.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = CoffeeManagementSystem.Models.Classes.Menu;

namespace CoffeeManagementSystem
{
    public partial class MenuControl : UserControl
    {
        private readonly CoffeeManagementSystemManager _manager;
        public MenuControl(CoffeeManagementSystemManager manager)
        {
            InitializeComponent();
            _manager = manager;
            this.Text = "Menu Management";
            LoadMenu();

            txtSearch.TextChanged += Filter_ValueChanged;

            btnClear.Click +=BtnClear_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;

            dataGridProducts.CellClick += DataGridProducts_CellClick;
        }

        private void LoadMenu()
        {
            dataGridProducts.DataSource = null;
            dataGridProducts.DataSource = _manager.GetAllMenus();
            dataGridProducts.AutoResizeColumns();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtType.Clear();
            txtDescription.Clear();
            txtPrice.Clear();

            txtName.Focus();
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

            dataGridProducts.DataSource = null;
            dataGridProducts.DataSource = filtered.ToList();
            dataGridProducts.AutoResizeColumns();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtType.Text))
                {
                    MessageBox.Show("Name and Type are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtPrice.Text, out double price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price greater than zero.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool alreadyExists = _manager.GetAllMenus().Any(m => m.Name.Equals(txtName.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (alreadyExists)
                {
                    MessageBox.Show($"A menu item with the name '{txtName.Text.Trim()}' already exists.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Menu newItem = new Menu
                {
                    Name = txtName.Text.Trim(),
                    Type = txtType.Text.Trim(),
                    Desc = txtDescription.Text.Trim(),
                    Price = price
                };

                _manager.AddMenu(newItem);

                MessageBox.Show("Menu item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenu();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding menu item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a menu item to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Menu selected = (Menu)dataGridProducts.CurrentRow.DataBoundItem;

                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtType.Text))
                {
                    MessageBox.Show("Name and Type are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtPrice.Text, out double price) || price <= 0)
                {
                    MessageBox.Show("Please enter a valid price greater than zero.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool alreadyExists = _manager.GetAllMenus().Any(m => m.ID != selected.ID && m.Name.Equals(txtName.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (alreadyExists)
                {
                    MessageBox.Show($"A menu item with the name '{txtName.Text.Trim()}' already exists.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selected.Name = txtName.Text.Trim();
                selected.Type = txtType.Text.Trim();
                selected.Desc = txtDescription.Text.Trim();
                selected.Price = price;

                _manager.UpdateMenu(selected);

                MessageBox.Show("Menu item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating menu item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a menu item to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Menu selected = (Menu)dataGridProducts.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete menu item: {selected.Name} (ID: {selected.ID})?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _manager.DeleteMenu(selected.ID);
                    MessageBox.Show("Menu item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenu();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting menu item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridProducts.Rows[e.RowIndex].DataBoundItem is Menu selected)
            {
                txtName.Text = selected.Name;
                txtType.Text = selected.Type;
                txtDescription.Text = selected.Desc;
                txtPrice.Text = selected.Price.ToString();
            }
        }
    }
}

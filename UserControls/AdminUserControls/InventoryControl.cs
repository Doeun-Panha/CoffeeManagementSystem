using CoffeeManagementSystem.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CoffeeManagementSystem
{
    public partial class InventoryControl : UserControl
    {
        private readonly CoffeeManagementSystemManager _manager;
        public InventoryControl(CoffeeManagementSystemManager manager)
        {
            InitializeComponent();
            _manager = manager;
            this.Text = "Inventory Management";
            LoadProduct();

            txtSearch.TextChanged += Filter_ValueChanged;

            btnClear.Click +=BtnClear_Click;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnLowStock.Click += BtnLowStock_Click;
            button1.Click += BtnRefresh_Click;

            dataGridProducts.CellClick += DataGridProducts_CellClick;
        }

        private void LoadProduct()
        {
            dataGridProducts.DataSource = null;
            dataGridProducts.DataSource = _manager.GetAllInventory();
            dataGridProducts.AutoResizeColumns();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtLowStockAlert.Clear();
            txtStockQty.Clear();
            txtQtyIncrease.Clear();
            txtQtyDecrease.Clear();
            txtName.Focus();
        }

        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            List<Inventory> allItems = _manager.GetAllInventory();
            string searchTerm = txtSearch.Text.Trim().ToLower();

            var filtered = allItems.Where(t =>
                t.ID.ToString().Contains(searchTerm) ||
                t.Name.ToLower().Contains(searchTerm)
            );

            dataGridProducts.DataSource = null;
            dataGridProducts.DataSource = filtered.ToList();
            dataGridProducts.AutoResizeColumns();
        }

        private void BtnLowStock_Click(object sender, EventArgs e)
        {
            List<Inventory> allItems = _manager.GetAllInventory();
            var lowStockItems = allItems.Where(i => i.StockQty <= i.AlertQty).ToList();

            dataGridProducts.DataSource = null;
            dataGridProducts.DataSource = lowStockItems;
            dataGridProducts.AutoResizeColumns();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadProduct();
            txtSearch.Clear();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Product Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtPrice.Text, out double price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtStockQty.Text, out int stockQty) || stockQty < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtLowStockAlert.Text, out int alertQty) || alertQty < 0)
                {
                    alertQty = 10; 
                }

                bool alreadyExists = _manager.GetAllInventory().Any(i => i.Name.Equals(txtName.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (alreadyExists)
                {
                    MessageBox.Show($"An inventory item with the name '{txtName.Text.Trim()}' already exists.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Inventory newItem = new Inventory
                {
                    Name = txtName.Text.Trim(),
                    Price = price,
                    StockQty = stockQty,
                    AlertQty = alertQty
                };

                _manager.AddProduct(newItem);

                MessageBox.Show("Inventory item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProduct();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Inventory selected = (Inventory)dataGridProducts.CurrentRow.DataBoundItem;

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Product Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(txtPrice.Text, out double price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtStockQty.Text, out int stockQty) || stockQty < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtLowStockAlert.Text, out int alertQty) || alertQty < 0)
                {
                    alertQty = 10;
                }

                if (!string.IsNullOrWhiteSpace(txtQtyIncrease.Text))
                {
                    if (int.TryParse(txtQtyIncrease.Text, out int changesinc) && changesinc > 0)
                    {
                        stockQty += changesinc;
                    }
                    else
                    {
                        MessageBox.Show("Increase Quantity must be a valid positive integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtQtyDecrease.Text))
                {
                    if (int.TryParse(txtQtyDecrease.Text, out int changesdec) && changesdec > 0)
                    {
                        if (stockQty >= changesdec)
                        {
                            stockQty -= changesdec;
                        }
                        else
                        {
                            MessageBox.Show($"Cannot decrease stock by {changesdec}. Insufficient stock.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Decrease Quantity must be a valid positive integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                bool alreadyExists = _manager.GetAllInventory().Any(i => i.ID != selected.ID && i.Name.Equals(txtName.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (alreadyExists)
                {
                    MessageBox.Show($"An inventory item with the name '{txtName.Text.Trim()}' already exists.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selected.Name = txtName.Text.Trim();
                selected.Price = price;
                selected.StockQty = stockQty;
                selected.AlertQty = alertQty;

                _manager.UpdateProduct(selected);

                MessageBox.Show("Inventory item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProduct();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Inventory selected = (Inventory)dataGridProducts.CurrentRow.DataBoundItem;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete Product: {selected.Name} (ID: {selected.ID})?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _manager.DeleteProduct(selected.ID);
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProduct();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridProducts.Rows[e.RowIndex].DataBoundItem is Inventory selected)
            {
                txtName.Text = selected.Name;
                txtPrice.Text = selected.Price.ToString();
                txtLowStockAlert.Text = selected.AlertQty.ToString();
                txtStockQty.Text = selected.StockQty.ToString();
                txtQtyIncrease.Clear();
                txtQtyDecrease.Clear();
            }
        }
    }
}

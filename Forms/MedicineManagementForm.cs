using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Forms
{
    public partial class MedicineManagementForm : Form
    {
        private readonly Inventory inventory;
        private readonly DataManager dataManager;

        public MedicineManagementForm()
        {
            InitializeComponent();
            dataManager = new DataManager();
            inventory = new Inventory();
            inventory.GetAllMedicines().AddRange(dataManager.LoadMedicines());
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvMedicines.DataSource = null;
            dgvMedicines.DataSource = inventory.GetAllMedicines();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Medicine medicine = new Medicine(
                    int.Parse(txtID.Text),
                    txtName.Text,
                    decimal.Parse(txtPrice.Text),
                    int.Parse(txtQuantity.Text),
                    dtpExpiryDate.Value,
                    txtCategory.Text
                );
                inventory.AddMedicine(medicine);
                dataManager.SaveMedicines(inventory.GetAllMedicines());
                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Medicine updatedMedicine = new Medicine(
                    int.Parse(txtID.Text),
                    txtName.Text,
                    decimal.Parse(txtPrice.Text),
                    int.Parse(txtQuantity.Text),
                    dtpExpiryDate.Value,
                    txtCategory.Text
                );
                if (inventory.UpdateMedicine(updatedMedicine.MedicineID, updatedMedicine))
                {
                    dataManager.SaveMedicines(inventory.GetAllMedicines());
                    RefreshGrid();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Medicine not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                if (inventory.RemoveMedicine(id))
                {
                    dataManager.SaveMedicines(inventory.GetAllMedicines());
                    RefreshGrid();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Medicine not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var medicine = inventory.SearchMedicine(txtSearch.Text);
            if (medicine != null)
            {
                dgvMedicines.DataSource = new List<Medicine> { medicine };
            }
            else
            {
                MessageBox.Show("Medicine not found.");
            }
        }

        private void btnLowStock_Click(object sender, EventArgs e)
        {
            var lowStock = inventory.CheckLowStock(10);
            dgvMedicines.DataSource = lowStock;
        }

        private void ClearInputs()
        {
            txtID.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtCategory.Clear();
            dtpExpiryDate.Value = DateTime.Now;
        }

        private void dgvMedicines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMedicines.SelectedRows.Count > 0)
            {
                var medicine = (Medicine)dgvMedicines.SelectedRows[0].DataBoundItem;
                txtID.Text = medicine.MedicineID.ToString();
                txtName.Text = medicine.Name;
                txtPrice.Text = medicine.Price.ToString();
                txtQuantity.Text = medicine.Quantity.ToString();
                dtpExpiryDate.Value = medicine.ExpiryDate;
                txtCategory.Text = medicine.Category;
            }
        }
    }
}
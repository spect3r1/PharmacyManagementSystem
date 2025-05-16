using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Forms
{
    public partial class SalesForm : Form
    {
        private readonly Inventory inventory;
        private readonly List<Customer> customers;
        private readonly List<Order> orders;
        private readonly DataManager dataManager;
        private Order currentOrder;

        public SalesForm()
        {
            InitializeComponent();
            dataManager = new DataManager();
            inventory = new Inventory();
            inventory.GetAllMedicines().AddRange(dataManager.LoadMedicines());
            customers = dataManager.LoadCustomers();
            orders = dataManager.LoadOrders();
            LoadCustomers();
            RefreshAvailableMedicines();
        }

        private void LoadCustomers()
        {
            cmbCustomers.DataSource = customers;
            cmbCustomers.DisplayMember = "Name";
            cmbCustomers.ValueMember = "CustomerID";
        }

        private void RefreshAvailableMedicines()
        {
            dgvAvailableMedicines.DataSource = null;
            dgvAvailableMedicines.DataSource = inventory.GetAllMedicines();
        }

        private void RefreshOrderMedicines()
        {
            dgvOrderMedicines.DataSource = null;
            dgvOrderMedicines.DataSource = currentOrder?.Medicines;
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAvailableMedicines.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a medicine.");
                    return;
                }
                if (cmbCustomers.SelectedItem == null)
                {
                    MessageBox.Show("Please select a customer.");
                    return;
                }
                var selectedMedicine = (Medicine)dgvAvailableMedicines.SelectedRows[0].DataBoundItem;
                int quantity = int.Parse(txtQuantity.Text);

                if (inventory.UpdateStock(selectedMedicine.MedicineID, quantity))
                {
                    if (currentOrder == null)
                    {
                        currentOrder = new Order(orders.Count + 1, (Customer)cmbCustomers.SelectedItem);
                    }
                    var orderMedicine = new Medicine(
                        selectedMedicine.MedicineID,
                        selectedMedicine.Name,
                        selectedMedicine.Price,
                        quantity,
                        selectedMedicine.ExpiryDate,
                        selectedMedicine.Category
                    );
                    currentOrder.AddMedicine(orderMedicine);
                    RefreshAvailableMedicines();
                    RefreshOrderMedicines();
                    txtInvoice.Text = currentOrder.GenerateInvoice();
                }
                else
                {
                    MessageBox.Show("Insufficient stock.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder != null)
            {
                orders.Add(currentOrder);
                dataManager.SaveOrders(orders);
                dataManager.SaveMedicines(inventory.GetAllMedicines());
                MessageBox.Show("Order completed successfully!");
                currentOrder = null;
                RefreshOrderMedicines();
                RefreshAvailableMedicines();
                txtInvoice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("No medicines in order.");
            }
        }
    }
}
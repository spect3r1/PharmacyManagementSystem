using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Forms
{
    public partial class CustomerManagementForm : Form
    {
        private readonly List<Customer> customers;
        private readonly DataManager dataManager;

        public CustomerManagementForm()
        {
            InitializeComponent();
            dataManager = new DataManager();
            customers = dataManager.LoadCustomers();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = customers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer(
                    int.Parse(txtCustomerID.Text),
                    txtName.Text,
                    txtContact.Text,
                    txtEmail.Text
                );
                customers.Add(customer);
                dataManager.SaveCustomers(customers);
                RefreshGrid();
                ClearInputs();
                MessageBox.Show("Customer added successfully.");
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
                int id = int.Parse(txtCustomerID.Text);
                var customer = customers.Find(c => c.CustomerID == id);
                if (customer != null)
                {
                    customer.Name = txtName.Text;
                    customer.Contact = txtContact.Text;
                    customer.Email = txtEmail.Text;
                    dataManager.SaveCustomers(customers);
                    RefreshGrid();
                    ClearInputs();
                    MessageBox.Show("Customer updated successfully.");
                }
                else
                {
                    MessageBox.Show("Customer not found.");
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
                int id = int.Parse(txtCustomerID.Text);
                var customer = customers.Find(c => c.CustomerID == id);
                if (customer != null)
                {
                    customers.Remove(customer);
                    dataManager.SaveCustomers(customers);
                    RefreshGrid();
                    ClearInputs();
                    MessageBox.Show("Customer deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearInputs()
        {
            txtCustomerID.Clear();
            txtName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var customer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                txtCustomerID.Text = customer.CustomerID.ToString();
                txtName.Text = customer.Name;
                txtContact.Text = customer.Contact;
                txtEmail.Text = customer.Email;
            }
        }
    }
}
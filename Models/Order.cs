using System;
using System.Collections.Generic;

namespace PharmacyManagementSystem.Models
{
    public class Order
    {
        private int orderID;
        private Customer customer;
        private List<Medicine> medicines;
        private decimal totalAmount;
        private DateTime orderDate;

        public Order(int orderID, Customer customer)
        {
            this.orderID = orderID;
            this.customer = customer;
            this.medicines = new List<Medicine>();
            this.orderDate = DateTime.Now;
            this.totalAmount = 0;
        }

        // Properties (Getters and Setters)
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public List<Medicine> Medicines
        {
            get { return medicines; }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public void AddMedicine(Medicine medicine)
        {
            medicines.Add(medicine);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            totalAmount = 0;
            foreach (var medicine in medicines)
            {
                totalAmount += medicine.Price * medicine.Quantity;
            }
        }

        public string GenerateInvoice()
        {
            string invoice = $"Invoice for Order ID: {orderID}\nCustomer: {customer.Name}\nDate: {orderDate:MM/dd/yyyy}\n\nMedicines:\n";
            foreach (var medicine in medicines)
            {
                invoice += $"{medicine.Name} - Qty: {medicine.Quantity}, Price: {medicine.Price:C}, Total: {(medicine.Price * medicine.Quantity):C}\n";
            }
            invoice += $"\nTotal Amount: {totalAmount:C}";
            return invoice;
        }
    }
}
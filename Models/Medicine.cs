using System;

namespace PharmacyManagementSystem.Models
{
    public class Medicine
    {
        private int medicineID;
        private string name;
        private decimal price;
        private int quantity;
        private DateTime expiryDate;
        private string category;

        public Medicine(int medicineID, string name, decimal price, int quantity, DateTime expiryDate, string category)
        {
            this.medicineID = medicineID;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.expiryDate = expiryDate;
            this.category = category;
        }

        // Properties (Getters and Setters)
        public int MedicineID
        {
            get { return medicineID; }
            set { medicineID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public override string ToString()
        {
            return $"ID: {medicineID}, Name: {name}, Price: {price:C}, Quantity: {quantity}, Expiry: {expiryDate:MM/yyyy}, Category: {category}";
        }
    }
}
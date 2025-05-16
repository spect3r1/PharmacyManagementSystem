using System;
using System.Collections.Generic;
using System.Linq;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services
{
    public class Inventory
    {
        private List<Medicine> medicines;

        public Inventory()
        {
            medicines = new List<Medicine>();
        }

        public void AddMedicine(Medicine medicine)
        {
            medicines.Add(medicine);
        }

        public bool UpdateMedicine(int medicineID, Medicine updatedMedicine)
        {
            var medicine = medicines.FirstOrDefault(m => m.MedicineID == medicineID);
            if (medicine != null)
            {
                medicine.Name = updatedMedicine.Name;
                medicine.Price = updatedMedicine.Price;
                medicine.Quantity = updatedMedicine.Quantity;
                medicine.ExpiryDate = updatedMedicine.ExpiryDate;
                medicine.Category = updatedMedicine.Category;
                return true;
            }
            return false;
        }

        public bool RemoveMedicine(int medicineID)
        {
            var medicine = medicines.FirstOrDefault(m => m.MedicineID == medicineID);
            if (medicine != null)
            {
                medicines.Remove(medicine);
                return true;
            }
            return false;
        }

        public Medicine SearchMedicine(string name)
        {
            return medicines.FirstOrDefault(m => m.Name.ToLower().Contains(name.ToLower()));
        }

        public List<Medicine> CheckLowStock(int threshold)
        {
            return medicines.Where(m => m.Quantity <= threshold).ToList();
        }

        public bool UpdateStock(int medicineID, int quantitySold)
        {
            var medicine = medicines.FirstOrDefault(m => m.MedicineID == medicineID);
            if (medicine != null && medicine.Quantity >= quantitySold)
            {
                medicine.Quantity -= quantitySold;
                return true;
            }
            return false;
        }

        public List<Medicine> GetAllMedicines()
        {
            return medicines;
        }
    }
}
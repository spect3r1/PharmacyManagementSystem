using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services
{
    public class DataManager
    {
        private readonly string medicinesFile = "medicines.json";
        private readonly string customersFile = "customers.json";
        private readonly string ordersFile = "orders.json";

        public void SaveMedicines(List<Medicine> medicines)
        {
            try
            {
                string json = JsonConvert.SerializeObject(medicines, Formatting.Indented);
                File.WriteAllText(medicinesFile, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving medicines: {ex.Message}");
            }
        }

        public List<Medicine> LoadMedicines()
        {
            try
            {
                if (File.Exists(medicinesFile))
                {
                    string json = File.ReadAllText(medicinesFile);
                    return JsonConvert.DeserializeObject<List<Medicine>>(json) ?? new List<Medicine>();
                }
                return new List<Medicine>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading medicines: {ex.Message}");
            }
        }

        public void SaveCustomers(List<Customer> customers)
        {
            try
            {
                string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
                File.WriteAllText(customersFile, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving customers: {ex.Message}");
            }
        }

        public List<Customer> LoadCustomers()
        {
            try
            {
                if (File.Exists(customersFile))
                {
                    string json = File.ReadAllText(customersFile);
                    return JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
                }
                return new List<Customer>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading customers: {ex.Message}");
            }
        }

        public void SaveOrders(List<Order> orders)
        {
            try
            {
                string json = JsonConvert.SerializeObject(orders, Formatting.Indented);
                File.WriteAllText(ordersFile, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving orders: {ex.Message}");
            }
        }

        public List<Order> LoadOrders()
        {
            try
            {
                if (File.Exists(ordersFile))
                {
                    string json = File.ReadAllText(ordersFile);
                    return JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
                }
                return new List<Order>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading orders: {ex.Message}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Services
{
    public class ReportGenerator
    {
        public string GenerateSalesReport(List<Order> orders, DateTime start, DateTime end)
        {
            var filteredOrders = orders.Where(o => o.OrderDate >= start && o.OrderDate <= end).ToList();
            decimal totalSales = filteredOrders.Sum(o => o.TotalAmount);
            string report = $"Sales Report ({start:MM/dd/yyyy} to {end:MM/dd/yyyy})\n";
            report += $"Total Orders: {filteredOrders.Count}\nTotal Sales: {totalSales:C}\n\nDetails:\n";
            foreach (var order in filteredOrders)
            {
                report += $"Order ID: {order.OrderID}, Customer: {order.Customer.Name}, Amount: {order.TotalAmount:C}, Date: {order.OrderDate:MM/dd/yyyy}\n";
            }
            return report;
        }

        public string GenerateStockReport(List<Medicine> medicines)
        {
            string report = "Stock Report\n";
            foreach (var medicine in medicines)
            {
                report += $"{medicine.ToString()}\n";
            }
            return report;
        }
    }
}
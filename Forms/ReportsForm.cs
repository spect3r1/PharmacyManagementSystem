using System;
using System.Windows.Forms;
using PharmacyManagementSystem.Services;

namespace PharmacyManagementSystem.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly DataManager dataManager;
        private readonly ReportGenerator reportGenerator;

        public ReportsForm()
        {
            InitializeComponent();
            dataManager = new DataManager();
            reportGenerator = new ReportGenerator();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                var orders = dataManager.LoadOrders();
                txtReport.Text = reportGenerator.GenerateSalesReport(orders, dtpStartDate.Value, dtpEndDate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            try
            {
                var medicines = dataManager.LoadMedicines();
                txtReport.Text = reportGenerator.GenerateStockReport(medicines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
namespace PharmacyManagementSystem.Models
{
    public class Staff
    {
        private int staffID;
        private string name;
        private string role;
        private string username;
        private string password; // Note: In production, hash passwords!

        public Staff(int staffID, string name, string role, string username, string password)
        {
            this.staffID = staffID;
            this.name = name;
            this.role = role;
            this.username = username;
            this.password = password;
        }

        // Properties (Getters and Setters)
        public int StaffID { get { return staffID; } set { staffID = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Role { get { return role; } set { role = value; } }
        public string Username { get { return username; } set { username = value; } }

        // Login method to verify credentials
        public bool Login(string username, string password)
        {
            return this.username == username && this.password == password;
        }
    }
}
namespace InventoryApp.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; } // INTEGER type from SQLite
        public string CompanyName { get; set; } //  nvarchar(40) 
        public string ContactName { get; set; } //  nvarchar(30) 
        public string ContactTitle { get; set; } //  nvarchar(30) 
        public string Address { get; set; } //  nvarchar(60) 
        public string City { get; set; } //  nvarchar(15) 
        public string Region { get; set; } //  nvarchar(15) can be nullable
        public string PostalCode { get; set; } // nvarchar(10) 
        public string Country { get; set; } //  nvarchar(15) 
        public string Phone { get; set; } //  nvarchar(24) 
        
        
    }
}

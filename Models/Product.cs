namespace InventoryApp.Models
{
    public class Product
    {
        public int ProductId { get; set; } // This corresponds to INTEGER in SQLite
        public string ProductName { get; set; } // This corresponds to nvarchar(40)
        public int SupplierId { get; set; } // This corresponds to int
        public int CategoryId { get; set; } // This corresponds to int
        public string QuantityPerUnit { get; set; } // Corresponds to nvarchar(20)
        public decimal UnitPrice { get; set; } // Corresponds to "money" in SQLite, using decimal in C#
        public short UnitsInStock { get; set; } // Corresponds to "smallint"
        public short UnitsOnOrder { get; set; } // Corresponds to "smallint"
        public short ReorderLevel { get; set; } // Corresponds to "smallint"
        public bool Discontinued { get; set; } // Corresponds to "bit", using bool in C#
    }
}

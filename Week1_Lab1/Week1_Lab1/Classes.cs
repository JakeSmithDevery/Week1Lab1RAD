using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Lab1
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public float UnitPrice { get; set; }
        public int CategoryID { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddressLine1 { get; set; }
        public string SupplierAddressLine2 { get; set; }
    }

    public class SupplierProduct
    {
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public DateTime DateFirstSupplied { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //products
            Product Product1 = new Product();
            Product Product2 = new Product();
            Product Product3 = new Product();
            Product Product4 = new Product();

            List<Product> products = new List<Product>();
            products.Add(Product1);
            products.Add(Product2);
            products.Add(Product3);
            products.Add(Product4);

            //Suppliers
            Supplier Supplier1 = new Supplier();
            Supplier Supplier2 = new Supplier();

            List<Supplier> suppliers = new List<Supplier>();

            suppliers.Add(Supplier1);
            suppliers.Add(Supplier2);

            //categories
            Category category1 = new Category();
            Category category2 = new Category();

            List<Category> categories = new List<Category>();
            categories.Add(category1);
            categories.Add(category2);

            //Supplier products
            SupplierProduct product1 = new SupplierProduct();
            SupplierProduct product2 = new SupplierProduct();
            SupplierProduct product3 = new SupplierProduct();
            SupplierProduct product4 = new SupplierProduct();

            List<SupplierProduct> supplierProducts = new List<SupplierProduct>();
            supplierProducts.Add(product1);
            supplierProducts.Add(product2);
            supplierProducts.Add(product3);
            supplierProducts.Add(product4);


            //Product1 vars
            Product1.ProductID = 1;
            Product1.Description = "9 Inch Nails";
            Product1.QuantityInStock = 200;
            Product1.CategoryID = 1;
            Product1.UnitPrice = 0.1f;

            //Product2 vars
            Product2.ProductID = 2;
            Product2.Description = "9 Inch Bolts";
            Product2.QuantityInStock = 120;
            Product2.CategoryID = 1;
            Product2.UnitPrice = 0.2f;

            //Product3 vars
            Product3.ProductID = 3;
            Product3.Description = "Chimney Hoover";
            Product3.QuantityInStock = 10;
            Product3.CategoryID = 2;
            Product3.UnitPrice = 100.30f;

            //Product4 vars
            Product4.ProductID = 4;
            Product4.Description = "Washing Machine";
            Product4.QuantityInStock = 7;
            Product4.CategoryID = 2;
            Product4.UnitPrice = 399.50f;

            //supplier1
            Supplier1.SupplierID = 1;
            Supplier1.SupplierName = "ACME";
            Supplier1.SupplierAddressLine1 = "Collooney";
            Supplier1.SupplierAddressLine2 = "Sligo";

            //supplier2
            Supplier2.SupplierID = 2;
            Supplier2.SupplierName = "Swift Electric";
            Supplier2.SupplierAddressLine1 = "Finglas";
            Supplier2.SupplierAddressLine2 = "Dublin";

            //SupplierProduct1
            product1.SupplierID = Supplier1.SupplierID;
            product1.ProductID = Product1.ProductID;
            product1.DateFirstSupplied = new DateTime (2012,12,12);

            //SupplierProduct2
            product2.SupplierID = Supplier1.SupplierID;
            product2.ProductID = Product2.ProductID;
            product2.DateFirstSupplied = new DateTime(2017, 08, 13);

            //SupplierProduct3
            product2.SupplierID = Supplier2.SupplierID;
            product2.ProductID = Product3.ProductID;
            product2.DateFirstSupplied = new DateTime(2022, 09, 09);

            //SupplierProduct3
            product2.SupplierID = Supplier2.SupplierID;
            product2.ProductID = Product4.ProductID;
            product2.DateFirstSupplied = new DateTime(2024, 04, 011);

            //category1
            category1.Id = 1;
            category1.Description = "Hardware";

            //category2
            category2.Id = 2;
            category2.Description = "Electrical Appliances";

            foreach (var i in categories)

                Console.WriteLine("Catergory ID: {0} Category Description: {1}", i.Id.ToString(), i.Description);
            Console.WriteLine("");
            foreach (var i in products)

                Console.WriteLine("Product ID: {0} Product Description: {1} Quantity: {2} Price: {3} Category ID: {4}",
                    i.ProductID.ToString(),i.Description,i.QuantityInStock.ToString(),i.UnitPrice.ToString(),i.CategoryID.ToString());
            Console.WriteLine("");
            var prods100 = products.Where(p => p.QuantityInStock <= 100);
            foreach (var i in prods100)
                Console.WriteLine("Product ID: {0} Product Description: {1} Quantity: {2} Price: {3} Category ID: {4}",
                    i.ProductID.ToString(), i.Description, i.QuantityInStock.ToString(), i.UnitPrice.ToString(), i.CategoryID.ToString());
            Console.WriteLine("");
            var prods120 = products.Where(p => p.QuantityInStock >= 120);
            foreach (var i in prods120)
                Console.WriteLine("Product ID: {0} Product Description: {1} Quantity: {2} Price: {3} Category ID: {4}",
                    i.ProductID.ToString(), i.Description, i.QuantityInStock.ToString(), i.UnitPrice.ToString(), i.CategoryID.ToString());
            Console.WriteLine("");


            var Value = products.Select(p => new { TotalValue = p.UnitPrice * p.QuantityInStock, 
            ProductID = p.ProductID, Description = p.Description, QuantityInStock = p.QuantityInStock, UnitPrice = p.UnitPrice, CategoryID = p.CategoryID});

            foreach (var i in Value)

                Console.WriteLine("Product ID: {0} Product Description: {1} Quantity: {2} Price: {3} Category ID: {4} Total Value: {5}",
                    i.ProductID.ToString(), i.Description, i.QuantityInStock.ToString(), i.UnitPrice.ToString(), i.CategoryID.ToString(),i.TotalValue.ToString());
            Console.WriteLine("");


            var HardWare = from p in products
                           where p.CategoryID == 1
                           select p;
            foreach (var i in HardWare)
                Console.WriteLine("Product ID: {0} Product Description: {1} Quantity: {2} Price: {3} Category ID: {4}",
                    i.ProductID.ToString(), i.Description, i.QuantityInStock.ToString(), i.UnitPrice.ToString(), i.CategoryID.ToString());
            Console.WriteLine("");

            var Parts = (from s in suppliers
                         join sp in supplierProducts on s.SupplierID equals sp.SupplierID
                         join p in products on sp.ProductID equals p.ProductID
                         select new
                         {
                             SupplierName = s.SupplierName,
                             ProductDescription = p.Description

                         }).OrderByDescending(x => x.SupplierName);

            foreach (var i in Parts) 
                Console.WriteLine( "{0} ordered {1}", i.SupplierName, i.ProductDescription);





            Console.ReadKey(true);
        }
    }
}

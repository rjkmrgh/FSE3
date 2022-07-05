using eauction.Models;
using eauction.Models.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eauction.DataSource
{
    public static class TestData
    {
        private static Products ProductDetails { get; set; }
       // private static Products ProductDetails { get; set; }

        static TestData()
        {
            ProductDetails = new Products();
        }

        public static void LoadProducuts()
        {
            if (ProductDetails.ProductDetails.Count > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "DataSource\\Products.json");
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    ProductDetails = JsonConvert.DeserializeObject<Products>(json);
                }
            }
        }

        public static List<Product> GetProducuts()
        {
            return ProductDetails.ProductDetails;
        }
        public static void AddProducut(Product p)
        {
            ProductDetails.ProductDetails.Add(p);
        }

        public static void DelProducut(int id)
        {
            var pd = ProductDetails.ProductDetails.Where(x => x.ProductId == id.ToString()).FirstOrDefault();
            if(pd != null)
            {
                ProductDetails.ProductDetails.Remove(pd);
            }
            
        }
    }
}

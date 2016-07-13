using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartItem> itemCollection = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            CartItem item = itemCollection
                             .Where(p => p.Product.ProductID == product.ProductID)
                             .FirstOrDefault();

            if (item == null)
            {
                itemCollection.Add(new CartItem { 
                    Product = product, Quantity = quantity 
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            itemCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return itemCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        public void Clear()
        {
            itemCollection.Clear();
        }

        public IEnumerable<CartItem> Items
        {
            get { return itemCollection; }
        }
    }
}

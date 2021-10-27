using System;
using System.Collections.Generic;
using SolidDAL.Entities;

namespace SolidBLL
{
    public class Cart
    {
        public Dictionary<Guid, int> ProductsCount { get; }
        public int this[Guid productId]
        {
            get => ProductsCount[productId];
            set => ProductsCount[productId] = value;
        }

        public Cart()
        {
            ProductsCount = new Dictionary<Guid, int>();
        }
        public void Add(Guid productId)
        {
            if (ProductsCount.ContainsKey(productId))
            {
                ++ProductsCount[productId];
            }
            else
            {
                ProductsCount[productId] = 1;
            }
        }

        public void Clear() => ProductsCount.Clear();
    }
}
﻿using System.Collections.Generic;
using SolidTask.Domain.Entities;

namespace SolidTask.App
{
    public class Session
    {
        public User CurrentUser { get; set; }
        public Dictionary<Product, int> Cart { get; }
        public Session()
        {
            Cart = new Dictionary<Product, int>();
        }
        public void AddToCart(Product product)
        {
            if (Cart.ContainsKey(product))
            {
                ++Cart[product];
            }
            else
            {
                Cart[product] = 1;
            }
        }
    }
}
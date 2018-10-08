using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Arbuz.KZ
{
    public class ShoppingCart
    {
        private List<Products> shoppingCart = new List<Products>();
        private int allSum = 0;

        public void Show()
        {
            List<string> categorys = new List<string>();

            for (int i = 0; i < shoppingCart.Count; i++)
            {
                if (categorys.Contains(shoppingCart[i].Catalog) == false)
                {
                    categorys.Add(shoppingCart[i].Catalog);
                }
            }


            for (int i = 0; i < categorys.Count; i++)
            {
                Console.WriteLine(categorys[i]);
                for (int k = 0; k < shoppingCart.Count; k++)
                {
                    if (categorys[i] == shoppingCart[i].Catalog)
                    {
                        Console.WriteLine($"\t Товар:{shoppingCart[k].Name}  Стоймость:{shoppingCart[k].Price}");
                        allSum += shoppingCart[i].Price;
                    }
                }
            }

            Console.WriteLine("Общая стоймость товаров = " + allSum);

        }

        public int AllSum()
        {
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                allSum = shoppingCart[i].Price;
            }

            return allSum;
        }

        public void Add(Products good)
        {
            shoppingCart.Add(good);
        }


        public void Clear()
        {
            shoppingCart.Clear();
        }
    }
}
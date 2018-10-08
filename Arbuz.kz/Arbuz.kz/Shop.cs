using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Arbuz.KZ
{
    class Shop
    {
        List<CheckIn> account = new List<CheckIn>();
        ShoppingCart shoppingCart = new ShoppingCart();
        List<Products> goods = new List<Products>();

        CheckIn acc = new CheckIn();

        public bool AddToShoppingCart(int number)
        {
            if (number > 0 && number < goods.Count)
            {
                Products products1 = new Products("Сахар", "Продукты", 300);
                Products products2 = new Products("Помидор", "Продукты", 250);
                Products products3 = new Products("Чипсы", "Продукты", 400);
                Products products4 = new Products("Хлеб", "Продукты", 80);
                Products chemicalGood1 = new Products("Зубная паста", "Химические товары", 500);
                Products chemicalGood2 = new Products("Парошок", "Химические товары", 700);
                Products chemicalGood3 = new Products("Мила", "Химические товары", 200);
                Products chemicalGood4 = new Products("Фейри", "Химические товары", 650);
                Products BabyThing1 = new Products("Мила для детей", "Детские вещи",300);
                Products BabyThing2 = new Products("Папперс", "Детские вещи", 370);
                Products BabyThing3 = new Products("Крем для детей", "Детские вещи", 900);
                return true;
            }

            return false;
        }


        public bool Pay()
        {

            if (account[0].Cash > shoppingCart.AllSum())
            {

                return true;
            }

            return false;
        }

        public void ShowProducts()
        {
            shoppingCart.Show();
        }

        public void ClearProducts()
        {
            shoppingCart.Clear();
        }

        public string ShowIndex(int index)
        {
            return goods[index].Name;
        }


        public void AddGood(Products good)
        {
            goods.Add(good);
        }

        public bool Autorizes(string name, string pass)
        {
            for (int i = 0; i < account.Count; i++)
            {
                if (account[i].LastName == name && account[i].Password == pass)
                {
                    return true;
                }
            }

            return false;
        }


        public bool AddAccount(string lastName, string surName, string phone, string card, int cvKod, int cash, string password)
        {
            bool check = true;

            for (int i = 0; i < account.Count; i++)
            {
                if (account[i].PhoneNumber == phone)
                {
                    check = false;
                }
            }

            if (check)
            {
                if (acc.Registration(phone))
                {
                    account.Add(new CheckIn { LastName = lastName, SurName = surName, PhoneNumber = phone, CardNomer = card, CVKod = cvKod, Cash = cash, Password = password });
                    return true;
                }
            }

            return false;
        }

        public void Show()
        {
            List<string> catalog = new List<string>();

            for (int i = 0; i < goods.Count; i++)
            {
                if (catalog.Contains(goods[i].Catalog) == false)
                {
                    catalog.Add(goods[i].Catalog);
                }
            }


            for (int i = 0; i < catalog.Count; i++)
            {
                Console.WriteLine(catalog[i]);
                for (int k = 0; k < goods.Count; k++)
                {
                    if (catalog[i] == goods[i].Catalog)
                    {
                        Console.WriteLine($"\t Товар:{goods[k].Name}  Стоймость:{goods[k].Price}");
                    }
                }
            }

        }



    }
}
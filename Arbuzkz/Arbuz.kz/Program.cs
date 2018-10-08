using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbuz.KZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            CheckIn client = new CheckIn { LastName = "Olzhas", PhoneNumber = "+77471287018", CardNomer = "5847 4824 6591 3205", CVKod = 147, Cash = 4500,Password = "123" };
            int key = 0;
            while (true)
            {
                string Menu1;
                Menu1 = "\n\n1-Регистрация\n2-Вход\n3-Просмотр товаров\n4-Выход\n";
                Console.WriteLine(Menu1);
                bool check = int.TryParse(Console.ReadLine(), out key);

                switch (key)
                {

                    case 1:
                        Console.Clear();
                        if (shop.AddAccount(client.LastName, client.SurName, client.PhoneNumber, client.CardNomer, client.CVKod, client.Cash, client.Password))
                        {
                            Console.WriteLine("Вы успешно регистрировали");
                        }
                        else
                        {
                            Console.WriteLine("Вы регистрацию не прошли");
                        }
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ввeдите имя:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите пароль:");
                        string pass = Console.ReadLine();

                        Console.Clear();
                        if (shop.Autorizes(name, pass))
                        {
                            Console.WriteLine("enter 1 to see all goods \n" +
                                              "enter 2 to see all basket \n" +
                                              "enter 3 to clear basket \n" +
                                              "press other to exit");
                            check = int.TryParse(Console.ReadLine(), out key);

                            switch (key)
                            {
                                case 1:
                                    shop.Show();
                                    string Menu2;
                                    Menu2 = "1-Продукты\n2-Химические товары\n3-Детские вещи\n4-Выход из католог товаров";
                                    Console.WriteLine(Menu2);
                                    check = int.TryParse(Console.ReadLine(), out key);

                                    if (shop.AddToShoppingCart(key))
                                    {
                                        Console.WriteLine($"Добавит в корзинку {shop.ShowIndex(key)}");
                                    }

                                    break;

                                case 2:
                                    shop.ShowProducts();
                                    break;

                                case 3:
                                    shop.ClearProducts();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Простите имя или пароль не правильно, повторите попытку");
                        }

                        break;

                    default:
                        break;
                }
            }
            Console.ReadLine();

        }
    }
}

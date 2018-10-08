using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Arbuz.KZ
{
    public class CheckIn
    {
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string CardNomer { get; set; }
        public int CVKod { get; set; }
        public int Cash { get; set; }
        const string accountSid = "ACfcb52d005d020f2e7fa79813308f89a6";
        const string authToken = "f0972aa7f5654cade2652df16ba55b03";

        public void CreateAccount(string number, string name,string surName,string phoneNumber,string cardNomer,int cvKod, int cash, string password)
        {
            if (Registration(number))
            {
                LastName = name;
                SurName = surName;
                PhoneNumber = phoneNumber;
                CardNomer = cardNomer;
                CVKod = cvKod;
                Password = password;
            }
        }
        public bool Registration(string number)
        {
            Random rand = new Random();
            int sms;
            sms = rand.Next(9999);
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                  body: $"{sms}",
                from: new Twilio.Types.PhoneNumber("+1 850 367 1255"),
                to: new Twilio.Types.PhoneNumber("+77471287018")
            );
            string lastName, surName, phoneNomer, parol, cardNomer;
            int cvKod ,cash;
            Console.WriteLine("Введите ваше имя: ");
            lastName = Console.ReadLine();
            lastName = LastName;
            Console.WriteLine("Введите ваше фамилия: ");
            surName = Console.ReadLine();
            surName = SurName;
            Console.WriteLine("Введите ваше телефон номер: ");
            phoneNomer = Console.ReadLine();
            phoneNomer = PhoneNumber;
            Console.WriteLine("Введите ваше парол для входа: ");
            parol = Console.ReadLine();
            parol = Password;
            Console.WriteLine("Введите ваше 16-цифрны номер карты: ");
            cardNomer = Console.ReadLine();
            cardNomer = CardNomer;
            Console.WriteLine("Введите ваше CV-код карты: ");
            cvKod = Int32.Parse(Console.ReadLine());
            CVKod = cvKod;
            Console.WriteLine("Введите сумма карты: ");
            cash = Int32.Parse(Console.ReadLine());
            Cash = cash;
            Console.WriteLine("Введите код сообщения, который пришел для подверждения номер телефона: ");
            int answer;
            bool check = int.TryParse(Console.ReadLine(), out answer);
            if (check)
            {
                if (answer == sms)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
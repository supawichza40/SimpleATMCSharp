using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleATMProject
{
    static class NumberGenerator
    {
        public static string GenerateNumberNTimes(int numberOfTime)
        {
            StringBuilder str = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < numberOfTime; i++)
            {
                str.Append(rnd.Next(0, 10));
            }
            return str.ToString();
        }
    }
    class Card
    {
        #region private field
        private string _cardNumber;
        private string _pin;
        private string _accountNumber;
        private string _sortcode;
        private string _securityNumber;
        public int numberPinTried = 0;
        private string _firstName;
        private string _lastName;
        const int pinDigit = 4;
        const int accountNumberDigit = 8;
        const int cardNumberDigit = 16;
        const int sortCodeDigit = 6;
        const int securityNumberDigit = 3;

        #endregion
        #region Property
        public string CardNumber { 
            get
            {
                return _cardNumber;
            }

        }
        

        public string AccountNumber { get => _accountNumber;}
        public string Sortcode { get => _sortcode;}
        public string SecurityNumber { get => _securityNumber; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        #endregion
        #region Constructor
        public Card()
        {

            _cardNumber = NumberGenerator.GenerateNumberNTimes(cardNumberDigit);
            _pin = NumberGenerator.GenerateNumberNTimes(pinDigit);
            _accountNumber = NumberGenerator.GenerateNumberNTimes(accountNumberDigit);
            _sortcode = NumberGenerator.GenerateNumberNTimes(sortCodeDigit);
            _securityNumber = NumberGenerator.GenerateNumberNTimes(securityNumberDigit);
            showCardDetail();
            Console.WriteLine($"Secret: Please remember your pin: {_pin}");
        }
        #endregion

        #region Method and Function
        public bool isValidPin(out bool returnCard)
        {
            returnCard = false;
            if (numberPinTried < 3)
            {
                Console.WriteLine("Please Input your Pin? 0 to return card");
                string userInputPin = Console.ReadLine();
                
                if (userInputPin == "0")
                {
                    returnCard = true;
                }
                if (userInputPin== _pin)
                {
                    Console.WriteLine("Access Granted");
                    return true;
                }
                Console.WriteLine("Access Denied");
                numberPinTried += 1;
                return false;
            }
            else
            {
                Console.WriteLine("Maximum pin limit reached! Please contact your bank");
                return true;
            }
            

        }
        public void showCardDetail()
        {
            Console.WriteLine($"Card Number:{CardNumber}");
            Console.WriteLine($"Sort Code:{Sortcode[0]}{Sortcode[1]}-{Sortcode[2]}{Sortcode[3]}-{Sortcode[4]}{Sortcode[5]}");
            Console.WriteLine($"Account Number:{AccountNumber}");
            Console.WriteLine($"Security Number:{SecurityNumber}");
        }
        
        #endregion
    }
}

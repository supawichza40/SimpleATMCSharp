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
    static class Reader
    {
        public static string GetUserPin(string question)
        {
            Console.WriteLine("Please Input your Pin? 0 to return card");
            string userInputPin = Console.ReadLine();
            return userInputPin;
        }
        public static void DisplayBalance(int balance)
        {
            Console.WriteLine($"Your Balance:£ {balance}");
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
        private int _balance = 0;
        internal Stack<string> transactions = new Stack<string>();
        
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
        public int Balance { get => _balance;}

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
        public bool IsCardExceedPinLimit(out bool returnCard)
        {
            returnCard = false;
            if (numberPinTried < 3)
            {
                return false;


            }
            else
            {
                Console.WriteLine("Maximum pin limit reached! Please contact your bank");
                return true;
            }
            

        }
        public bool VerifyPin(string userPin)
        {
            if (userPin == _pin)
            {
                Console.WriteLine("Access Granted");
                return true;
            }
            else
            {
                Console.WriteLine("Access Denied");
                numberPinTried += 1;
                return false;
            }
        }
        public bool UserAuthentication(out bool returnCard)
        {
            
            if(!IsCardExceedPinLimit(out returnCard))
            {
                string userPin = Reader.GetUserPin("Pin! 0 to return card");
                if (userPin == "0")
                {
                    returnCard = true;
                }
                return VerifyPin(userPin);
            }
            return false;
        }
        public void showCardDetail()
        {
            Console.WriteLine($"Card Number:{CardNumber}");
            Console.WriteLine($"Sort Code:{Sortcode[0]}{Sortcode[1]}-{Sortcode[2]}{Sortcode[3]}-{Sortcode[4]}{Sortcode[5]}");
            Console.WriteLine($"Account Number:{AccountNumber}");
            Console.WriteLine($"Security Number:{SecurityNumber}");
        }
        public bool isWithdrawAllow(int amount)
        {
            if (amount > _balance)
            {
                Console.WriteLine("Withdraw Limit exceed, please try other amount");
                return false;
            }
            return true;

        }
        public void Withdraw(int amount)
        {
            transactions.Push($"{nameof(Withdraw)}:-{amount}");
            _balance -= amount;
        }
        public void Deposit(int amount)
        {
            _balance += amount;
            transactions.Push($"{nameof(Deposit)}:{amount}");

        }

        #endregion
    }
}

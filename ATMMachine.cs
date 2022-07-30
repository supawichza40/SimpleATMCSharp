using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATMProject
{
    class ATMMachine
    {
        Card userCard;
        public ATMMachine()
        {
            
        }
        public void InsertCard(Card c)
        {
            userCard = c;
            bool returnCard = false;
            while (!returnCard)
            {
                c.UserAuthentication(out returnCard);
                MainATMSystemAfterVerification();
            }
            RemoveCard();

            


        }
        public void RemoveCard()
        {
            Console.WriteLine("Card Returned");
            userCard.RemoveCard();
        }
        private int GetBalance()
        {
            return userCard.Balance;
        }
        
        
        private void MainATMSystemAfterVerification()
        {
            while (userCard.IsAuthenticated) 
            {
                Console.WriteLine("Main System");
                Console.WriteLine("What would you like to do? 0.Remove card 1.balance 2.deposit 3.view statement 4.Withdraw 5.change pin");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("Remove your card");
                        RemoveCard();
                        break;
                    case "1":
                        Console.WriteLine("Getting your balance...");
                        Reader.DisplayBalance(GetBalance());
                        break;
                    case "2":
                        Console.Write("Deposit your cash:£");
                        string depositAmount = Console.ReadLine();
                        userCard.Deposit(Int32.Parse(depositAmount));
                        break;
                    case "3":
                        Console.WriteLine("View Statement");
                        foreach (var item in userCard.transactions)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("End of statement");
                        break;
                    case "4":
                        Console.Write("Withdraw:£");
                        string withdrawAmount = Console.ReadLine();
                        userCard.Withdraw(Int32.Parse(withdrawAmount));
                        break;
                    case "5":
                        Console.WriteLine("Change Pin");
                        
                        string newPin = Reader.GetInputFromUserWithAnyQuestion("What is your new Pin?");
                        while (!Verifier.IsNumber(newPin) && !Verifier.digitVerifier(newPin, Card.pinDigit))
                        {
                            Console.WriteLine("Invalid Pin try again!");
                            newPin = Reader.GetInputFromUserWithAnyQuestion("What is your new Pin?");
                        }

                        break;

                }
                
            }
            userCard = null;
        }
    }
}

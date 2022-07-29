using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATMProject
{
    class ATMMachine
    {
        private bool _accessGranted;
        public ATMMachine()
        {

        }
        public void InsertCard(Card c)
        {
            bool returnCard = false;
            while ( !_accessGranted&&!returnCard) {
                
                _accessGranted = c.isValidPin(out returnCard);
            }
            MainATMSystemAfterVerification();
            if (returnCard)
            {
                RemoveCard();
            }


        }
        public void RemoveCard()
        {
            Console.WriteLine("Card Returned");
            _accessGranted = false;
        }
        public void MainATMSystemAfterVerification()
        {
            while (_accessGranted) 
            {
                Console.WriteLine("Main System");
                RemoveCard();
            } 
        }
    }
}

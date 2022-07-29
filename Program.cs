using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATMProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Card dearCard = new Card();
            ATMMachine atm = new ATMMachine();
            atm.InsertCard(dearCard);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Calculator : ICheckPrimeNumberGateway
    {

        private readonly ICheckPrimeNumberGateway _checkPrimeNumber;

        public Calculator() { }

        public Calculator(ICheckPrimeNumberGateway checkPrimeNumber)
        {
            _checkPrimeNumber = checkPrimeNumber;
        }

        public int Add(int numberA, int numberB)
        {
            return numberA + numberB;
        }

        public int Subtract(int numberA, int numberB)
        {
            return numberA - numberB;
        }

        public bool IsPrimeNumber(int number)
        {
            //si es mayor que 21 verifico si es primo (regla de negocio inventada)
            if (number > 21)
            {
                bool isPrimeNumber = _checkPrimeNumber.IsPrimeNumber(number);
                return isPrimeNumber;
            }
            else
            {
                return false;
            }
        }



    }
}

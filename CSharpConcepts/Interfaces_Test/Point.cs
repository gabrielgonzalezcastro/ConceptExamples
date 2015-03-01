using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Point : IPoint
    {
        // Fields: 
        private int _x;
        private int _y;
       

        // Constructor: 
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // Constructor: 
        public Point()
        {
            
        }

        // Property implementation: 
        public int x
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public int Suma(int a , int b)
        {
            return a + b;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    //existing class does not need to be changed
    public class Consultant
    {
        private string name;

        public Consultant(string name)
        {
            this.name = name;
        }

        protected void ShowSmile()
        {
            Console.WriteLine("Consultant " + this.name + " showed smile");
        }
    }
}

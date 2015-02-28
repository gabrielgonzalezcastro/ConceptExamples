using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class EmployeeAdapter : Consultant, IEmployee
    {
        public EmployeeAdapter(string name)
            : base(name)
        {
        }

        void IEmployee.ShowHappiness()
        {
            base.ShowSmile();  //call the parent Consultant class
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_InProperty
{
    public interface IService
    {
        IEnumerable<string> GetNames();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //void: es void porque el metodo que al que va a apuntar el delegate sera un void (metodo OnNameChanged)
    //parametros: seran los parametros del metodo que va a apuntar el delegate (metodo OnNameChanged)
    public delegate void NameChangedDelegate(string oldValue, string newValue);
}

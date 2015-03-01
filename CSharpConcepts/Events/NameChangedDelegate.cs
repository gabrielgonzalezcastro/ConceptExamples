using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events;

namespace Delegates
{
    //void: es void porque el metodo que al que va a apuntar el delegate sera un void (metodo OnNameChanged)
    //parametros: por standart cuando se usa eventos los parametros son SENDER que va a ser la clase que dispara el
    //evento y the ARGS que son de tipo NameChangedEventArgs que son la clase que declaramos para meter los valores 
    //que queremos que pase el evento a los suscriptores en este caso oldvalue y newvalue
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs arg);
}

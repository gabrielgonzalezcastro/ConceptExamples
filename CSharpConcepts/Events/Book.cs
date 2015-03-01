using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events;

namespace Delegates
{
    //Cuando la propiedad Name de esta clase Book cambie quiero lanzar un evento y llamar a un metodo
    //esto lo hacemos implemetando un Evento y usando Deleados
    public class Book
    {

        //declaracion del evento que es del tipo delegate, para poderlo usar en la propiedad Name cuando cambie
        public event NameChangedDelegate NameChanged;

        public Book(string name)
        {
            _name = name;
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                //Si cambia el valor de Name
                if (_name != value)
                {
                    var oldValue = _name;
                    _name = value;
                    
                    //Chequero Si el evento  no tiene ningun metodo al que apuntar (suscribers) cuando cambia
                    //la propiedad en cuyo caso el evento es null
                    if (NameChanged != null)
                    {
                        var args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = _name;
                        NameChanged(this, args);
                    }
                }
                
            }
        }
    }
}

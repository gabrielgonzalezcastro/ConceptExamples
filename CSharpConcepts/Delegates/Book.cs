using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //Cuando la propiedad Name de esta clase Book cambie quiero llamar a un metodo
    //esto lo hacemos implemetando un delegado
    public class Book
    {

        //declaracion del delegate, para poderlo usar en la propiedad Name cuando cambie
        public NameChangedDelegate NameChanged;

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
                    
                    //Chequero Si el delegado no tiene ningun metodo al que apuntar (suscribers) cuando cambia
                    //la propiedad en cuyo caso el delegate es null
                    if (NameChanged != null)
                    {
                        NameChanged(oldValue, _name);
                    }
                }
                
            }
        }
    }
}

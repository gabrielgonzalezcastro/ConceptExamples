using System;
//Suponga que desea etiquetar tipos con el nombre del programador que los escribió. 
//Podría definir una clase de atributos personalizados Author:
namespace Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
    public class Author : Attribute
    {
        private string _name;
        public double Version;

        public Author(string name)
        {
            this._name = name;
            Version = 1.0;
        }

        public string GetName()
        {
            return _name;
        }
    }
}

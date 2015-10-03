using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Core.Exception
{
    public abstract class Validator
    {
        private readonly List<string> _errors = new List<string>();
        protected string Identifier = "";

        public bool IsValid
        {
            get { return this._errors.Count == 0; }
        }

        protected void AddError(string error)
        {
            if (!this._errors.Any() && this.Identifier != "")
                this._errors.Add(string.Format("{0} : <hr>",(object) this.Identifier));
            
            this._errors.Add(error);
        }

        public abstract void Validate();

        public override string ToString()
        {
            if (!this._errors.Any())
                return string.Format("{0} passed", this.GetType().Name);

            return string.Format("{0} failed for {1}{2}{3}", this.GetType().Name, Environment.NewLine,
                string.Join(Environment.NewLine, this._errors), "\r\n");
        }

        public IEnumerable<string> ErrorMessages()
        {
            return this._errors;
        } 
    }
}

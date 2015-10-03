using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Core.Exception
{
    public class ValidationResult
    {
        public List<string> Errors { get; set; }
        public string Title { get; set; }

        public bool IsValid
        {
            get { return this.Errors.Count == 0; }
        }

        public ValidationResult()
        {
            this.Errors = new List<string>();
        }

        public override string ToString()
        {
            if (!this.Errors.Any())
                return string.Format("{0} passed", this.GetType().Name);

            var list = this.Errors.Select(str => string.Format("<div>{0}</div>", str)).ToList();

            return string.Format("<h4>{0}</h4> {1}{2}{3}", this.Title, Environment.NewLine,
                string.Join(Environment.NewLine, list), "<br>");

        }
    }
}

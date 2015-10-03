using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Base.Core.Exception
{
    public class CommandException : System.Exception
    {
        #region Constructors

        public CommandException(IEnumerable<Validator> failedValidators)
            : base(CommandException.BuildMessage(failedValidators))
        {
        }

        public CommandException(IEnumerable<string> failedValidators)
            : base(CommandException.BuildMessage(failedValidators))
        {
        }

        public CommandException(IEnumerable<ValidationResult> validators):base(CommandException.BuildMessage(validators))
        {
        }

        public CommandException(ValidationResult validator):base(CommandException.BuildMessage(validator))
        {
        }

        #endregion
       

        #region Private Methods

        private static string BuildMessage(IEnumerable<Validator> failMessages)
        {
            return string.Join(Environment.NewLine, failMessages.Select(x => x.ToString()));
        }

        private static string BuildMessage(IEnumerable<string> failMessages)
        {
            return string.Join(Environment.NewLine, failMessages.Select(x => x.ToString(CultureInfo.InvariantCulture)));
        }

        private static string BuildMessage(IEnumerable<ValidationResult> validators)
        {
            return string.Join(Environment.NewLine, validators.Select(x => x.ToString()));
        }

        private static string BuildMessage(ValidationResult validator)
        {
            return string.Join(Environment.NewLine, new string[1]
            {
                validator.ToString()
            });
        }

        #endregion

     
            
    }
}

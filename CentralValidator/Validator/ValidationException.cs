
namespace CentralValidator.Validator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ValidationException : Exception
    {
        public IEnumerable<string> validationErrors { get; set; }

        public ValidationException(IEnumerable<string> validationErrors)
        {
            this.validationErrors = validationErrors;
        }

        public override string Message
        {
            get
            {
                var errors = new StringBuilder();
                errors.Append("The following validation violations happend: ");
                var counter = 0;

                foreach (var error in validationErrors)
                {
                    counter++;
                    errors.Append(string.Format(" [{0}] - {1}", counter, error));
                }

                return errors.ToString();
            }
        }
    }
}

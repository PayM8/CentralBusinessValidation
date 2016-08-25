
namespace CentralValidator.Validator
{
    using System;
    using System.Collections.Generic;

    public static class ValidationCommon
    {
        public const string MandatoryFieldNotPopulated = @"Mandatory field not supplied";
        public const string InvalidFutureDate = @"Invalid date provided, first acceptable date is: {0}";

        public static IEnumerable<string> FutureValidation(this DateTime value, int offset = 0, bool isMandatory = false)
        {
            if (isMandatory)
            {
                return ValidateMandatory(value);
            }

            var errors = new List<string>();
            var firstAcceptableDate = DateTime.Now.AddDays(offset);

            if (value > firstAcceptableDate)
            {
                errors.Add(string.Format(InvalidFutureDate, firstAcceptableDate.ToShortDateString()));
            }

            return errors;
        }
        
        public static IEnumerable<string> MandatoryValidation(this string value)
        {
             return ValidateMandatory(value);
        }

        public static IEnumerable<string> MandatoryValidation(this Guid value)
        {
            return ValidateMandatory(value);
        }

        public static IEnumerable<string> ValidateMandatory<T>(T value)
        {
            var errors = new List<string>();
            var isProvided = !(EqualityComparer<T>.Default.Equals(value, default(T)));

            if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(value as string))
                {
                     isProvided = false;
                }
            }

            if (!isProvided)
            {
                errors.Add(MandatoryFieldNotPopulated);
            }

            return errors;
        }
    }
}

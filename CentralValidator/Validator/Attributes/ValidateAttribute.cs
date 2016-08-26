
namespace CentralValidator.Validator.Attributes
{
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Parameter)]
    public class ValidateAttribute : Attribute  //InterceptAttribute
    {

        public void ValidateObjectByType(object value, Type objType)
        {
            var validator = new ValidationGroups();
            var errors = validator.Validate(value, objType);

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
    }
}

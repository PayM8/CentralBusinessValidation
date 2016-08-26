
namespace CentralValidator.Validator
{
    using System.Collections.Generic;
    using Model;
    using System;
    using System.IO;
    
    public partial class ValidationGroups
    {
        public delegate IEnumerable<string> Validation(object obj);
        public List<string> Errors;
        public Dictionary<Type, Validation> TypeValidations { get; private set; }
        public delegate IEnumerable<string> CustomValidation(object obj);

        public void ApplyValidation(IEnumerable<string> errors)
        {
            this.Errors.AddRange(errors);
        }

        public ValidationGroups()
        {
            this.Errors = new List<string>();
            var addEmployeeRequestGroup = CreateAddEmployeeRequestGroup<AddEmployeeRequest>();
            var updateEmployeeRequestGroup = CreateUpdateEmployeeRequestGroup<UpdateEmployeeRequest>();

            this.TypeValidations = new Dictionary<Type, Validation>
            {
                {typeof(AddEmployeeRequest), addEmployeeRequestGroup},
                {typeof(UpdateEmployeeRequest), updateEmployeeRequestGroup}
            };
        }

        public IEnumerable<string> Validate(object obj, Type objType, CustomValidation customValidation = null)
        {
            if (customValidation != null)
            {
                return customValidation.Invoke(obj);
            }

            if (objType == null)
            {
                throw new InvalidDataException("There was no valid object passed to be validated");
            }

            Validation validation;
            TypeValidations.TryGetValue(objType, out validation);

            if (validation == null)
            {
                throw new InvalidDataException(string.Format("There is no validation logic defined for type [{0}]", objType));
            }

            return validation(obj);
        }
    }
}

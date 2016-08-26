
namespace CentralValidator.Validator
{
    using System;
    using Model;

    public partial class ValidationGroups
    {
        public Validation CreateAddEmployeeRequestGroup<T>()
            where T : AddEmployeeRequest
        {
            return delegate(object obj)
            {
                var value = obj as T;
                if (value == null) throw new NullReferenceException();

                ApplyValidation(value.Birthday.FutureValidation());
                ApplyValidation(value.Name.MandatoryValidation());

                return Errors;
            };
        }

        public Validation CreateUpdateEmployeeRequestGroup<T>()
            where T : UpdateEmployeeRequest
        {
            return delegate(object obj)
            {
                var value = obj as T;
                if (value == null) throw new NullReferenceException();

                ApplyValidation(value.Id.MandatoryValidation());
                ApplyValidation(value.Birthday.FutureValidation());
                ApplyValidation(value.Name.MandatoryValidation());

                return Errors;
            };
        }
    }
}

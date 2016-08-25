
namespace CentralValidator
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using Validator;
    using System;

    public class Orchestration
    {
        public static bool AddEmployee(AddEmployeeRequest request)
        {
             var validator = new ValidationGroups();
             var errors = validator.Validate(request);
            
            return !errors.Any();
        }

        public static bool UpdateEmployee(UpdateEmployeeRequest request)
        {
            var validator = new ValidationGroups();
            var errors = validator.Validate(request, obj => (obj != null) ? null : new List<string>() { "Custom Validation: There was an error nothing passed" });

            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }

            return !errors.Any();
        }

        public static bool UpdateWithNoValidation(AddModelWithoutDefaultValidation request)
        {
            var validator = new ValidationGroups();
            var errors = validator.Validate(request);

            return !errors.Any();
        }
    }
}

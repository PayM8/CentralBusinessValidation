
namespace CentralValidator
{
    using Model;
    using Validator.Attributes;

    public class Orchestration 
    {
        public virtual bool AddEmployee([Validate] AddEmployeeRequest request)
        {
            //TODO: Impliment Logic

            return true;
        }

        public virtual bool UpdateEmployee([Validate] UpdateEmployeeRequest request)
        {
            //TODO: Impliment Logic

            return true;
        }

        public virtual bool UpdateWithNoValidation([Validate] AddModelWithoutDefaultValidation request)
        {
            //TODO: Impliment Logic

            return true;
        }
    }
}

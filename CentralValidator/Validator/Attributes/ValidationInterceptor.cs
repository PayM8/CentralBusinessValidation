
using System;

namespace CentralValidator.Validator.Attributes
{
    using Ninject.Extensions.Interception;

    public class ValidationInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var parameters = invocation.Request.Method.GetParameters();
            for (var index = 0; index < parameters.Length; index++)
            {
                var paramInfo = parameters[index];
                var attributes = paramInfo.GetCustomAttributes(typeof(ValidateAttribute), false);

                if (attributes.Length == 0)
                    continue;

                foreach (ValidateAttribute attr in attributes)
                {
                    var argument = invocation.Request.Arguments[index];
                    var objType = argument!= null ? argument.GetType() : null;
                    attr.ValidateObjectByType(argument, objType);
                }
            }

            invocation.Proceed();
        }        
    }
}

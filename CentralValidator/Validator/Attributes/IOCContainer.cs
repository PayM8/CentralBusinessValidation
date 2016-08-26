

namespace CentralValidator.Validator.Attributes
{
    using Ninject;
    using Ninject.Extensions.Interception.Infrastructure.Language;
    
    public static class IOCContainer
    {
        private static readonly IKernel Kernel;
        static IOCContainer()
        {
            // YOU DONT NEED TO DO KERNAL BINDING IF YOU USE : InterceptAttribute
            Kernel = new StandardKernel();
        }

        public static void Configure()
        {
            Kernel.Bind(typeof(Orchestration)).To(typeof(Orchestration)).Intercept().With<ValidationInterceptor>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}

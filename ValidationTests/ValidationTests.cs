
using ValidationTests.Bulders;

namespace ValidationTests
{
    using System.IO;
    using System.Linq;
    using CentralValidator;
    using CentralValidator.Validator;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CentralValidator.Validator.Attributes;

    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void TestMandatoryFields()
        {
            var validator = new ValidationGroups();
            var sampleRq = new EmployeeBuilder().JohnDoe().NoName().BuildAddRequest();

            var errors = validator.Validate(sampleRq, sampleRq.GetType());
            Assert.IsTrue(errors.Count() == 1);
        }

        [TestMethod]
        public void TestFutureFields()
        {
            var validator = new ValidationGroups();
            var sampleRq = new EmployeeBuilder().JohnDoe().DateInFuture().BuildAddRequest();

            var errors = validator.Validate(sampleRq, sampleRq.GetType());
            Assert.IsTrue(errors.Count() == 1);
        }

        [TestMethod]
        public void TestSuccess()
        {
            var validator = new ValidationGroups();
            var sampleRq = new EmployeeBuilder().JohnDoe().BuildAddRequest();

            var errors = validator.Validate(sampleRq, sampleRq.GetType());
            Assert.IsTrue(!errors.Any());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void TestDefaultOrchastrationFail()
        {
           var sampleRq = new EmployeeBuilder().JohnDoe().DateInFuture().BuildAddRequest();

           // Need to move to :InterceptAttribute
           IOCContainer.Configure();
           var provider = IOCContainer.Get<Orchestration>();

           provider.AddEmployee(sampleRq);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestNoDefaultValidationAvailable()
        {
            // Need to move to :InterceptAttribute
            IOCContainer.Configure();
            var provider = IOCContainer.Get<Orchestration>();

            provider.UpdateEmployee(null);
        }

        [TestMethod]
        public void TestValidationSuccessfull()
        {
            var sampleRq = new EmployeeBuilder().JohnDoe().BuildAddRequest();

            // Need to move to :InterceptAttribute
            IOCContainer.Configure();
            var provider = IOCContainer.Get<Orchestration>();

            var outcome = provider.AddEmployee(sampleRq);
            Assert.IsTrue(outcome);
        }
    }
}

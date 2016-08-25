using System;
using System.IO;
using System.Linq;
using CentralValidator;
using CentralValidator.Model;
using CentralValidator.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidationTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void TestMandatoryFields()
        {
            var validator = new ValidationGroups();
            var sampleRq = new EmployeeBuilder().JohnDoe().NoName().BuildAddRequest();

            var errors = validator.Validate(sampleRq);
            Assert.IsTrue(errors.Count() == 1);
        }

        [TestMethod]
        public void TestFutureFields()
        {
            var validator = new ValidationGroups();
            var sampleRq = new EmployeeBuilder().JohnDoe().DateInFuture().BuildAddRequest();

            var errors = validator.Validate(sampleRq);
            Assert.IsTrue(errors.Count() == 1);
        }

        [TestMethod]
        public void TestSuccess()
        {
            var validator = new ValidationGroups();
            var sampleRq = new EmployeeBuilder().JohnDoe().BuildAddRequest();

            var errors = validator.Validate(sampleRq);
            Assert.IsTrue(!errors.Any());
        }

        [TestMethod]
        public void TestCustomOrchastrationFail()
        {
            var ourcome = Orchestration.UpdateEmployee(null);
            Assert.IsFalse(ourcome);
        }

        [TestMethod]
        public void TestDefaultOrchastrationFail()
        {
            var sampleRq = new EmployeeBuilder().JohnDoe().DateInFuture().BuildAddRequest();

            var ourcome = Orchestration.AddEmployee(sampleRq);
            Assert.IsFalse(ourcome);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestNoDefaultValidationAvailable()
        {
            Orchestration.UpdateWithNoValidation(null);
        }


    }
}

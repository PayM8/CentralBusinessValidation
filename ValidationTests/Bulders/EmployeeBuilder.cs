
namespace ValidationTests.Bulders
{
    using System;
    using CentralValidator.Model;

    public class EmployeeBuilder
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }


        public EmployeeBuilder JohnDoe()
        {
            this.Id = Guid.Empty;
            this.Name = "John Doe";
            this.Birthday = DateTime.Now.AddYears(-29);

            return this;
        }

        public EmployeeBuilder DateInFuture()
        {
            this.Birthday = DateTime.Now.AddDays(2);

            return this;
        }

        public EmployeeBuilder NoName()
        {
            this.Name = string.Empty;

            return this;
        }

        public AddEmployeeRequest BuildAddRequest()
        {
            return new AddEmployeeRequest
            {
                Name = this.Name,
                Birthday = this.Birthday
            };
        }
    }
}

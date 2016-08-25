
namespace CentralValidator.Model
{
    using System;

    public class UpdateEmployeeRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}

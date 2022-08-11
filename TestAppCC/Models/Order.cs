using System;
namespace TestAppCC.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderId = Guid.NewGuid();
        }

        public Guid OrderId { get; set; }

        public string OrderType { get; set; }

        public string OrderStatus { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public string IpAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Order
    {
        public int Id { get; set; }
       
        public string Username { get; set; }
        public int ProductId { get; set; }
        public DateTime DateTime { get; set; }

        public Product Product  { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}

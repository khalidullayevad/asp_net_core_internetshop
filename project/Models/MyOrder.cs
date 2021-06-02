using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class MyOrder
    {
        public int Id { get; set; }
      
        
        public Microsoft.AspNetCore.Identity.IdentityUser User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime DateTime { get; set; }

       
        public int Count { get; set; }
        public int Total { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class IndexViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public SelectList Category { get; set; }
        public string Name { get; set; }
        public PageViewModel PageViewModel
        {
            get; set;
        }
    }
}

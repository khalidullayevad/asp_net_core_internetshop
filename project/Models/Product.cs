using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescriprion { get; set; }
        public double Price { get; set; }

        public string PictureUrl { get; set; }
        public Boolean IsPreferred { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public int CategoryId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Category Category { get; set; }
       



    }
}

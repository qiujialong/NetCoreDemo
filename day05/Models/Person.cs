using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace day05.Models
{
    public class Person
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

    }
}

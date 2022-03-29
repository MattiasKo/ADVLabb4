//Mattias Kokkonen SUT21
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADVLabb4.Models
{
    public class Personer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
   

    }
}

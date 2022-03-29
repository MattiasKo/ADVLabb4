using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ADVLabb4.Models
{
    public class Links
    {
        [Key]
        public int ID { get; set; }
        public string strLink { get; set; }
        public int PersID { get; set; }
        public int InterestID { get; set; }

    }
}

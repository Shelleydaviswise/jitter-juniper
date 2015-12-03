using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class Jot : IComparable
    {
        public JitterUser Author { get; set; }
        [Required] // Data Annotation
        public string Content { get; set; }
        public DateTime Date { get; set; }
        [Key]
        public int JotId { get; set; }
        public string Picture { get; set; }

        public int CompareTo(object obj)
    {   
        Jot other_jot = object as Jot;
            //Multiply times -1 b/c DateTimes' Compare to sorts ascending by default.
            // we want to sort Jots descending
        return -1*( this.Date.CompareTo(other_jot.Date));
        
    }
}

   
}
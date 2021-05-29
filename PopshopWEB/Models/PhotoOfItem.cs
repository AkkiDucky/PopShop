using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopshopWEB.Models
{
    public class PhotoOfItem
    {
        public Item Item { get; set; }
        public IEnumerable<Photos> Photos { get; set; }
        public bool first;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopshopWEB.Models
{
    public class IPC
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Photos> Photos { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int CurrentPage { get; set; }
        public int MaxPage { get; set; }
        public string Search{ get; set; }



    }
}
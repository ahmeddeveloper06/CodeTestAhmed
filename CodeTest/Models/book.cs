using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class book
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
       
        public string Author { get; set; }
        
        public int published { get; set; }
        public string Description { get; set; }
    }
}

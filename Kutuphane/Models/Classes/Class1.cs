using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kutuphane.Models.Classes
{
    public class Class1
    {
        public IEnumerable<Books> TableBook { get; set; }
        public IEnumerable<About> TableAbout { get; set; }
    }
}
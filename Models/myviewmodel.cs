using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class myviewmodel
    {
       public List<showdata> getdata { get; set; }
    }
    public class showdata
    {
        public string Regtype { get; set; }
        public int Totalcount { get; set; }
    }
}
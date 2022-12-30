using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileExemple.Models
{
    public class FileModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}
using clincApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clincApp.ViewModles
{
    public class BshinUpdate
    {

        [MaxLength(100)]
        public string Name { get; set; }
        //public DateTime HireDate { get; set; } = DateTime.Now;

        //[Range(0, 100_000)]
        //public double Salary { get; set; }
        public string Mrn { get; set; }

        public string Enum { get; set; }

        public void ToBshin(Bshin b)
        {
            b.Name = Name;
            b.Mrn = Mrn;
            b.Enum = Enum;
            

        }
    }
}


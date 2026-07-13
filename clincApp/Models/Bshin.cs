using clincApp.ViewModles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace clincApp.Models
{
    public class Bshin
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public string Mrn { get; set; }

        public string Enum { get; set; }

        public List<Appintment> Appintments { get; set; } = new();

    
    public BshinUpdate BshinUpdate()
        {
            return new BshinUpdate
            {
                Name = Name,
                Mrn = Mrn,
                Enum = Enum,
            };
        }
    }
}


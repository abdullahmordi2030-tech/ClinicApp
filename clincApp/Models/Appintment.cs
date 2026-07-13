using System;
using System.Collections.Generic;
using System.Text;

namespace clincApp.Models
{
    public class Appintment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = new();


        public int BshinId { get; set; } 
        public Bshin Bshin { get; set; } = new();



        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<VisitNote> VisitNotes { get; set; } = new();





    }
}

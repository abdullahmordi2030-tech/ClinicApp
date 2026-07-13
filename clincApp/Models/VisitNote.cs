using System;
using System.Collections.Generic;
using System.Text;

namespace clincApp.Models
{
    public class VisitNote
    {
        public int Id { get; set; }

        public int Appintmentid { get; set; }
        public Appintment Appintment { get; set; } = new();

        public string Notes { get; set; }

        public DateTime Created { get; set; }


















            

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore.User
{
    public class Bshin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Appintment> Appintments { get; set; } = new();

    }
}

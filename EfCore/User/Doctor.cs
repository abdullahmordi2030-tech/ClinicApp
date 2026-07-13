using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore.User
{
    public class Doctor

    {
        public int Id { get; set; }

        public int UserId { get; set; } = new();

        public string Specialty { get; set; }

    }
}

using EfCore.Common;
using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace EfCore.User
{
    public class BshinContexte : DbContext 
    {

        public BshinContexte()
        {
        }
        public BshinContexte(DbContextOptions<BshinContexte> options)
        : base(options)
        {
        }
        public DbSet <Bshin> Bshins { get; set; }

        public DbSet<Appintment> Appintments { get; set; }


        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(StaticCommons.ConnectionString);
        }


    }
}

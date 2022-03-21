using ADVLabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntresseKlubbenAPI.Model
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

        public DbSet <Personer> Personers { get; set; }
        public DbSet <Interest> Interests { get; set; }
        public DbSet <Links> Linkss { get; set; }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed personer
            modelBuilder.Entity<Personer>().
                HasData(new Personer
                {Id = 1,Name = "Anas",
                    Phone=07055555,
                    Email="Anas@qlok.com" 
                });
            modelBuilder.Entity<Personer>().
                HasData(new Personer
                {
                    Id = 2,
                    Name = "Tobias",
                    Phone = 07066666,
                    Email = "Tobias@qlok.com"
                });
            modelBuilder.Entity<Personer>().
                HasData(new Personer
                {
                    Id = 3,
                    Name = "Riedar",
                    Phone = 07077777,
                    Email = "Riedar@qlok.com"
                });
            //seed interest
            modelBuilder.Entity<Interest>().
                HasData(new Interest
            {
                ID=1,
                Title = "Sportfiske",
                Description="Fiska fiskar i havet.",

            });
            modelBuilder.Entity<Interest>().
                HasData(new Interest
            {
                ID = 2,
                Title = "Fotboll",
                Description = "Sparka bollar i mål.",

            });
            modelBuilder.Entity<Interest>().
                HasData(new Interest
            {
                ID = 3,
                Title = "Styrketräning",
                Description = "Lyfta skrot i gymmet.",

            });
            modelBuilder.Entity<Interest>().
                HasData(new Interest
            {
                ID = 4,
                Title = "Youtube",
                Description = "Kolla på katter på youtube",

            });
            //seed Links
            modelBuilder.Entity<Links>().HasData(new Links 
            { 
                ID=1,
                strLink="www.nånting.com",
                PersID=1
            });
            modelBuilder.Entity<Links>().HasData(new Links
            {
                ID = 2,
                strLink = "www.nånting2.com",
                PersID = 1
            });
            modelBuilder.Entity<Links>().HasData(new Links
            {
                ID = 3,
                strLink = "www.nånting3.com",
                PersID = 2
            });
            modelBuilder.Entity<Links>().HasData(new Links
            {
                ID = 4,
                strLink = "www.nånting4.com",
                PersID = 3
            });
        }
    }
}

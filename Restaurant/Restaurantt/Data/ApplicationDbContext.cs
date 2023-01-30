using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurantt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurantt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
       public DbSet<Kategori> Kategoris { get; set; }
       public DbSet<Menu> Menus { get; set; }
       public DbSet<Rezervasyon> Rezervasyons { get; set; }
       public DbSet<Galeri> Galeris{ get; set; }
       public DbSet<Hakkımızda> Hakkımızdas { get; set; }
       public DbSet<Blog> Blogs { get; set; }
       public DbSet<İletisim>İletisims { get; set; }
       public DbSet<İletisimim> İletisimims { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;
using AppData.Configurations;

namespace AppData.DbContexxt
{
    public class Lab_DbContext : DbContext
    {
        public DbSet<NhanVien> NhanViens { get; set; }

        public Lab_DbContext()
        {
        }
        public Lab_DbContext(DbContextOptions<Lab_DbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-K48S9DA;Initial Catalog=anhpt_ph27168;Integrated Security=True");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
        }

    }
}
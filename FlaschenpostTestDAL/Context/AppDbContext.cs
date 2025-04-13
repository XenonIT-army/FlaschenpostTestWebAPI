using FlaschenpostTestDAL.Data;
using FlaschenpostTestDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostTestDAL.Context
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<TodoItemDB> TodoItem { get; set; }

        public virtual DbSet<CategoryDB> Category { get; set; }

        public virtual DbSet<ProjectDB> Project { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("TestDb");
        }

    }

}

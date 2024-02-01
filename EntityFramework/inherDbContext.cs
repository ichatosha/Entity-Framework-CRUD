using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class inherDbContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connect.sqlConStr);
        }
        
        
        // [Tables]
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<StudentBook> StudentBooks { get; set;}
        
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet <Invoice> Invoices { get; set; }

        // Make prop. description is required (When it's nullable in Department Model)
        // fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department>().Property(x => x.description).IsRequired();

            // relation between department >< student 
            //modelBuilder.Entity<Department>()
            //    .HasMany(p => p.Students)
            //    .WithOne(c => c.department)
            //    .OnDelete(DeleteBehavior.Restrict);
            // relation between student >< grade
            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.Grade)
            //    .WithOne(g => g.student)
            //    .OnDelete(DeleteBehavior.SetNull);

            // find all foreign keys and make these all restrict
            //foreach ( var relation in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relation.DeleteBehavior = DeleteBehavior.Restrict;
            //}


            //// ignore attendance table in database
            //modelBuilder.Ignore<Attendance>();

            //// set if it's not in DbContext as DbSet:
            //modelBuilder.Entity<Attendance>();

            //// exclude from migrations
            //modelBuilder.Entity<Attendance>().ToTable("atts", a => a.ExcludeFromMigrations());


            // *** Fluent API ***
            // Changing name of attendance table and schema : 
            modelBuilder.Entity<Attendance>().ToTable("atts" , "schem");

            // Changing the property in Attendance table:
            modelBuilder.Entity<Attendance>().Property(z => z.DayName)
                .HasColumnName("NameOfDay")
                .HasColumnType("varchar(50)");

            // Ignoring field (AttenDate) in table : 
            modelBuilder.Entity<Attendance>().Ignore(x => x.AttenDate);

            // default value of Qty = 1 
            modelBuilder.Entity<Invoice>().Property(c => c.Qty)
                .HasDefaultValue(1);
                

            // default value of created date = date.now
            modelBuilder.Entity<Invoice>().Property(x => x.CreatedDate)
               .HasDefaultValue(DateTime.Now);

            // [CustomerTitle] + [CustomerName] ==> [DescriptionName]
            modelBuilder.Entity<Invoice>().Property(y => y.DescriptionName)
                .HasComputedColumnSql("[CustomerTitle] + ' ' + [CustomerName]");

            // [Qty] + [price] ==> [total]
            modelBuilder.Entity<Invoice>().Property(z => z.total)
                .HasComputedColumnSql("[Qty] * [Price]");

            modelBuilder.HasSequence<int>("deliveryOreder")
                .StartsAt(0)
                .IncrementsBy(1);

            // Seed Data:
            modelBuilder.Entity<Gender>().HasData(

                new Gender() { Id = 1, GenderName = " Male" },
                new Gender() { Id = 2, GenderName = "Female" }
                ) ; 

        }

    }
}

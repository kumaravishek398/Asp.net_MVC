using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentAPI
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=Constr")  //it specifies the connection string 
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }  
        public virtual DbSet<EmployeeAddress> EmployeesAddresses { get; set; }    
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        //Learning Entity Configuration in Fluent API
        //for that i need to override OnModelCreating class to get the object of DbModelBuilder class
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //ToTable method --> to set table name different from the class name
            modelBuilder.Entity<Department>().ToTable("Dept");  //using TOTable method
            //HasKey --> to set any column as PK
            modelBuilder.Entity<Department>().HasKey(d=>d.DeptId);

            //Learning Property Configuration for "EMPLOYEE" class
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeId).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); //to avoid auto increment

            modelBuilder.Entity<Employee>().Property(e => e.EmpName).HasColumnName("Ename")//to set different column name
                                                                    .IsRequired()              //to make column as null
                                                                    .HasMaxLength(50)          //to set max length for the column
                                                                    .HasColumnType("varchar"); //to set datatype of the column in the db

            modelBuilder.Entity<Employee>().Property(e => e.PrimaryContact).IsRequired()
                                                                           .HasMaxLength(50);

            //One to one Relationship between Employee and Employee Address
            //first we need to mark PK in EmployeeDdress entity
            modelBuilder.Entity<EmployeeAddress>().HasKey(ea => ea.EmployeeId);

            modelBuilder.Entity<Employee>().HasOptional(e => e.EmployeeAddress)
                                           .WithRequired(a => a.Employee);

            //One to many Relation ship between Employee and Department
            modelBuilder.Entity<Department>().HasMany(d => d.Employees)    
                                             .WithRequired(e=>e.Department)
                                             .HasForeignKey(e => e.DeptId);

            //One to many Relation ship between Team and Employee [Nullable Foreign Key]
            modelBuilder.Entity<Team>().HasMany(t => t.Employees)
                                       .WithOptional(e => e.Team)
                                       .HasForeignKey(e => e.TeamId);

            //Many to many relation between Employee and Project
            modelBuilder.Entity<Employee>().HasMany(e => e.Projects)
                                           .WithMany(p => p.Employees)
                                           .Map(ep =>
                                           {
                                               ep.MapLeftKey("EmployeeId");
                                               ep.MapRightKey("ProjectId");
                                               ep.ToTable("ProjectsOfEmployees");
                                           });

        }




    }
}

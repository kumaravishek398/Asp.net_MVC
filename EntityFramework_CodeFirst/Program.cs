using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyDbContext db = new MyDbContext();
                Department d = new Department();
                d.DeptId = 1;
                d.DeptName = "Core Development";
                db.Departments.Add(d);
                db.SaveChanges();
                Console.WriteLine("Database has been Created Successfully...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error !! "+ex.ToString());
            }
           
        }
    }
}

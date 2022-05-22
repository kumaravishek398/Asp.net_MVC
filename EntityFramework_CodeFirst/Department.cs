using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Department
    {
        //Scalar property
        public int DeptId { get; set; } //PK, has relation of one to many with Employee
        public string DeptName { get; set; }

        //Navigation property
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

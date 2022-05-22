using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Team
    {
        //Scalar property
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Size { get; set; }

        //Navigation property
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Project
    {
        //Scalar property
        public int ProjectId { get; set; }
        public string ProjName { get; set; }
        public string ProgLanguage { get; set; }
        public string Database { get; set; }

        //Navigation property
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

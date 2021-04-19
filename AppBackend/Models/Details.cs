using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBackend.Models
{
    public class Details
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int base_experience { get; set; }
        public Object types { get; set; }
        public Object sprites { get; set; }

    }
}

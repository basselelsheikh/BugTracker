using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Bug domain model class
    /// </summary>
    public class Bug
    {
        public int ID { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }

    }
}

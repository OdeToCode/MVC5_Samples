using System.Collections;
using System.Collections.Generic;

namespace ModelBinding.Models
{
    public class Department
    {
        public string Name { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
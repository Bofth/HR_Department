using System.Collections.Generic;

namespace HR_department.Models
{
    public class EmployeeContainer
    {
        public List<Employee> Employees { get; set; }
        public Employee SingleEmployee { get; set; }
    }
}

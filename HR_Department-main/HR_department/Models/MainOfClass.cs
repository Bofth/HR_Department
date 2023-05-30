using HR_department.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR_department.Models
{
    public static class MainOfClass
    {
        public static void GenTestData()
        {
            List<Employee> Employers = new List<Employee>();
            for (int i = 0; i < 35; i++)
            {
                Employee employee = new Employee
                {
                    Name = "Alex" + i.ToString(),
                    Surname = i.ToString() + "Bonly",
                    PassNum = 234233454 + i,
                    Age = i + 13,
                    Education = 0,
                    Specialization = "Mechanic",
                    Salary = 323423 + i,
                    Position = "Manager",
                    EntryIntoCompany = DateTime.Parse("2023-05-23"),
                    LastAppointment = DateTime.Parse("2023-05-12"),
                };
                Employers.Add(employee);
            }
            Serialization.SerializeObjects(Employers);

        }
        public static List<Employee> SearchEmploye(string line, List<Employee> Employers)
        {
            List<Employee> result = new List<Employee>();
            string t = line.ToLower();
            foreach (Employee employe in Employers)
            {
                if (employe.ToString().ToLower().IndexOf(t) > -1)
                {
                    result.Add(employe);
                }
            }
            return result;
        }
        public static Employee GetEmployeeByNum(string InfOfEmployee, List<Employee> employees)
        {
            string stringPass = "";
            foreach (char symbol in InfOfEmployee)
            {
                if (symbol == ',')
                {
                    break;
                }
                stringPass += symbol;
            }
            int numPass = int.Parse(stringPass);
            return employees.FirstOrDefault(i => i.PassNum == numPass);
        }
    }
}

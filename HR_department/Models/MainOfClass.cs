using HR_department.Data;
using HR_department.Enums;
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
            Employee employee1 = new Employee
            {
                Name = "Іван",
                Surname = "Петров",
                Age = 30,
                PassNum = 12345,
                Education = Education.Середня,
                Specialization = "Розробка програмного забезпечення",
                Salary = 5000,
                Position = "Розробник програмного забезпечення",
                EntryIntoCompany = new DateTime(2015, 5, 1),
                LastAppointment = new DateTime(2022, 1, 15)
            };

            Employee employee2 = new Employee
            {
                Name = "Жанна",
                Surname = "Сміт",
                Age = 28,
                PassNum = 67890,
                Education = Education.Середня,
                Specialization = "Маркетинг",
                Salary = 4000,
                Position = "Маркетинговий спеціаліст",
                EntryIntoCompany = new DateTime(2016, 8, 10),
                LastAppointment = new DateTime(2021, 12, 3)
            };

            Employee employee3 = new Employee
            {
                Name = "Давид",
                Surname = "Джонсон",
                Age = 35,
                PassNum = 54321,
                Education = Education.Середня,
                Specialization = "Біохімія",
                Salary = 6000,
                Position = "Науковець",
                EntryIntoCompany = new DateTime(2014, 3, 15),
                LastAppointment = new DateTime(2023, 5, 20)
            };

            Employee employee4 = new Employee
            {
                Name = "Емілія",
                Surname = "Браун",
                Age = 32,
                PassNum = 98765,
                Education = Education.Середня,
                Specialization = "Графічний дизайн",
                Salary = 4500,
                Position = "Графічний дизайнер",
                EntryIntoCompany = new DateTime(2017, 10, 5),
                LastAppointment = new DateTime(2022, 9, 8)
            };

            Employee employee5 = new Employee
            {
                Name = "Михайло",
                Surname = "Вільсон",
                Age = 40,
                PassNum = 13579,
                Education = Education.Бакалаврат,
                Specialization = "Фінанси",
                Salary = 5500,
                Position = "Фінансовий аналітик",
                EntryIntoCompany = new DateTime(2010, 12, 1),
                LastAppointment = new DateTime(2021, 7, 25)
            };

            Employee employee6 = new Employee
            {
                Name = "Олівія",
                Surname = "Тейлор",
                Age = 27,
                PassNum = 24680,
                Education = Education.Бакалаврат,
                Specialization = "Управління персоналом",
                Salary = 3800,
                Position = "Асистент з управління персоналом",
                EntryIntoCompany = new DateTime(2019, 4, 12),
                LastAppointment = new DateTime(2023, 2, 18)
            };

            Employee employee7 = new Employee
            {
                Name = "Вільям",
                Surname = "Кларк",
                Age = 33,
                PassNum = 86420,
                Education = Education.Професор,
                Specialization = "Продажі",
                Salary = 4200,
                Position = "Представник з продажу",
                EntryIntoCompany = new DateTime(2013, 7, 20),
                LastAppointment = new DateTime(2022, 11, 10)
            };

            Employee employee8 = new Employee
            {
                Name = "Софія",
                Surname = "Андерсон",
                Age = 29,
                PassNum = 11111,
                Education = Education.Магістратура,
                Specialization = "Аналіз даних",
                Salary = 4800,
                Position = "Аналітик даних",
                EntryIntoCompany = new DateTime(2016, 2, 8),
                LastAppointment = new DateTime(2023, 3, 27)
            };

            Employee employee9 = new Employee
            {
                Name = "Яків",
                Surname = "Томас",
                Age = 31,
                PassNum = 99999,
                Education = Education.Середня,
                Specialization = "Управління операціями",
                Salary = 5200,
                Position = "Менеджер з операціями",
                EntryIntoCompany = new DateTime(2014, 9, 18),
                LastAppointment = new DateTime(2022, 8, 5)
            };

            Employee employee10 = new Employee
            {
                Name = "Ава",
                Surname = "Робертс",
                Age = 26,
                PassNum = 77777,
                Education = Education.Магістратура,
                Specialization = "Публічні відносини",
                Salary = 4000,
                Position = "Спеціаліст з публічних відносин",
                EntryIntoCompany = new DateTime(2020, 1, 10),
                LastAppointment = new DateTime(2023, 4, 30)
            };
            Employers.Add(employee1);
            Employers.Add(employee2);
            Employers.Add(employee3);
            Employers.Add(employee4);
            Employers.Add(employee5);
            Employers.Add(employee6);
            Employers.Add(employee7);
            Employers.Add(employee8);
            Employers.Add(employee9);
            Employers.Add(employee10);
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

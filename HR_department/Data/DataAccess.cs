using HR_department.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HR_department.Data
{
    public static class Serialization
    {
        private const string DATA_PATH = "C:\\Users\\Denis\\Desktop\\Bla\\rep\\HR_department\\Data\\DataOfEmployee.xml";

        public static void SerializeObjects(List<Employee> employees)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));

            using (FileStream fileStream = new FileStream(DATA_PATH, FileMode.Create))
            {
                serializer.Serialize(fileStream, employees);
            }
        }

        public static void SerializeObject(Employee employee)
        {
            List<Employee> existingEmployees = DeserializeObjects();
            if (existingEmployees != null)
            {
                Employee existingEmployee = existingEmployees.FirstOrDefault(e => e.PassNum == employee.PassNum);
                if (existingEmployee != null)
                {
                    _ = existingEmployees.Remove(existingEmployee);
                }
            }
            else
            {
                existingEmployees = new List<Employee>();
            }

            existingEmployees.Add(employee);
            SerializeObjects(existingEmployees);
        }

        public static List<Employee> DeserializeObjects()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));

            if (File.Exists(DATA_PATH))
            {
                using (FileStream fileStream = new FileStream(DATA_PATH, FileMode.Open))
                {
                    return (List<Employee>)serializer.Deserialize(fileStream);
                }
            }
            return null;
        }
    }

}


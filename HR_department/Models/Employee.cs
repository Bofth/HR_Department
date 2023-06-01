using HR_department.Enums;
using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace HR_department.Models
{
    public class Employee
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Surname")]
        public string Surname { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("PassNum")]
        public int PassNum { get; set; }

        [XmlElement("Education")]
        public Education Education { get; set; }

        [XmlElement("Specialization")]
        public Spezialisation Specialization { get; set; }

        [XmlElement("Salary")]
        public int Salary { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("EntryIntoCompany")]
        public DateTime EntryIntoCompany { get; set; }

        [XmlElement("LastAppointment")]
        public DateTime LastAppointment { get; set; }

        public override string ToString()
        {
            return $"{PassNum},     {Name},     {Surname},     {Age},   {EntryIntoCompany.ToString("yyyy-MM-dd")},  {LastAppointment.ToString("yyyy-MM-dd")}";
        }
    }

}

using HR_department.Enums;
using Newtonsoft.Json;
using System;

namespace HR_department.Models
{
    public class Employee
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("PassNum")]
        public int PassNum { get; set; }

        [JsonProperty("Education")]
        public Education Education { get; set; }

        [JsonProperty("Specialization")]
        public string Specialization { get; set; }

        [JsonProperty("Salary")]
        public int Salary { get; set; }

        [JsonProperty("Position")]
        public string Position { get; set; }

        [JsonProperty("EntryIntoCompany")]
        public DateTime EntryIntoCompany { get; set; }

        [JsonProperty("LastAppointment")]
        public DateTime LastAppointment { get; set; }

        public override string ToString()
        {
            return $"{PassNum}, {Name}, {Surname}, {Age}, {Education}, {Specialization}, {Position}, {Salary}, {EntryIntoCompany.ToShortDateString()}, {LastAppointment.ToShortDateString()}";
        }
    }
}

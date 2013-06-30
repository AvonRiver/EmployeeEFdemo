using System.ComponentModel.DataAnnotations;

namespace Stephen.Webb.HR.DataAccess
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int EmployeeCode { get; set; }
        public System.DateTime StartDate { get; set; }
    }
}

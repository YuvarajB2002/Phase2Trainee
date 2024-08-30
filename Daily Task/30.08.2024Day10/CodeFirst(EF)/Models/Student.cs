using System.ComponentModel.DataAnnotations;

namespace EFCORE.Models
{
    public class Student
    {
        [Key]
        public int StudentId {  get; set; }
        public string?StudentName { get; set; }
        public int ? StudentAge { get; set; }
        public string? StudentEmail { get; set; }
        public string? Address {  get; set; }
        public string? City { get; set; }
      
       public List<Department>? Departments { get; set; }

    }
}

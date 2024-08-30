using System.ComponentModel.DataAnnotations.Schema;

namespace EFCORE.Models
{
    public class Department
    {
        public int DepartmentId {  get; set; }
        public string? DepartmentName {  get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICodeFirst.Model
{
    public class Employee
    {
        [Key]
        public int empId {  get; set; }

        public string empName { get; set; }
        public decimal empSal {  get; set; }
        public DateTime JoiningDate { get; set; }

        public int companyId { get; set; }
        [ForeignKey("companyId")]
        public Company? company { get; set; }
    }
}

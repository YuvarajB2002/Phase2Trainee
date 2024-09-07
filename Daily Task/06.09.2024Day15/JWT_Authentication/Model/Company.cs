using System.ComponentModel.DataAnnotations;

namespace APICodeFirst.Model
{
    public class Company
    {
        [Key]
        public int companyId {  get; set; } 
        public string companyName { get; set; }

        public ICollection<Employee>? employees { get; set; }
    }
}

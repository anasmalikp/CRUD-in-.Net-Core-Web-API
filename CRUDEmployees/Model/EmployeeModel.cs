using System.ComponentModel.DataAnnotations;

namespace CRUDEmployees.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

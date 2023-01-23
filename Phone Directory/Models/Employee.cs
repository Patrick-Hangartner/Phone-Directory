using System.ComponentModel.DataAnnotations;

namespace Phone_Directory.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(15)]
        public string FirstName { get; set; }
        [Required, MinLength(2), MaxLength(20)]
        public string LastName { get; set; }
        [Required, MinLength(2), MaxLength(40)]
        public string Department { get; set; }
        [Required, MinLength(2), MaxLength(20)]
        public string Title { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string Email { get; set; }
        [Required, MinLength(10), MaxLength(10)]
        public int MobilePhone { get; set; }
        [Required, MinLength(10), MaxLength(10)]
        public int OfficePhone { get; set; }
        [Required, MinLength(2), MaxLength(5)]
        public int Ext { get; set; }

        public string Notes { get; set; }

    }
}

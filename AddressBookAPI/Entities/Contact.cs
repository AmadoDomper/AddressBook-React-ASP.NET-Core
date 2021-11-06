using System.ComponentModel.DataAnnotations;

namespace AddressBookAPI.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}

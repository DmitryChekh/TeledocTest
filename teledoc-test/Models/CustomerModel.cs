using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models
{
    public class CustomerModel
    {
        [Key]

        public int CustomerId { get; set; }
        [Required(ErrorMessage = "ITN is required")]
        [StringLength(12, MinimumLength = 12)]
        public string ITN { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Имя не может содержать цифры и любые знаки.")]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public int TypeId { get; set; }
        public List<CustomerFounderModel> CustomerFounder { get; set; }
    }
}

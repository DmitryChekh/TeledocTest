using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models
{
    public class FounderModel
    { 
        [Key]
        public int FounderId { get; set; }
        [Required(ErrorMessage = "ITN is required")]
        [StringLength(12, MinimumLength = 12)]
        public string ITN { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Имя не может содержать цифры и любые знаки.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Имя не может содержать цифры и любые знаки.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Middlename is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Имя не может содержать цифры и любые знаки.")]
        public string MiddleName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<CustomerFounderModel> CustomerFounder { get; set; }

    }
}

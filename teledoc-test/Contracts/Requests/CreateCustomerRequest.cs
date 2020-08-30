using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Requests
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = "ITN is required")]
        [StringLength(12, MinimumLength = 12)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "ИНН должен состоять только из цифр")]
        public string ITN { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Имя не может содержать цифры и любые знаки.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Client must have founder")]
        public int[] foundersId { get; set; }
    }
}

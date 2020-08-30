using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Requests
{
    public class UpdateFounderRequest
    {
        [Required(ErrorMessage = "ID is required")]
        public int FounderId { get; set; }
        [Required(ErrorMessage = "ITN is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "ИНН должен состоять из 12 цифр")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "ИНН должен состоять только из цифр")]
        public string ITN { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Имя не может содержать цифры и любые знаки.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Фамилия не может содержать цифры и любые знаки.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Middlename is required")]
        [RegularExpression("^[A-Za-z+А-Яа-я]+$", ErrorMessage = "Отчество не может содержать цифры и любые знаки.")]
        public string MiddleName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.ViewModels
{
    public class LoginVm
    {
        [Required]
        [MaxLength(255, ErrorMessage = "UserName Cannot be more than 255 char")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}

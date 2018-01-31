using System;
using System.ComponentModel.DataAnnotations;

namespace Review4_.NET.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

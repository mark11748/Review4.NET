using System;
using System.ComponentModel.DataAnnotations;
using Review4_.NET.Models;

namespace Review4_.NET.ViewModels
{
    public class EditPostViewModel
    {
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Message Body")]
        public string Body { get; set; }
    }
}

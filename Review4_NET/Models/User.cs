using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review4_.NET.Models
{
    [Table("Users")]
    public class User: IdentityUser
    {
        
        public string ImgString { get; set; }      
    }
}

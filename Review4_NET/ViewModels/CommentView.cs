using System;
using System.ComponentModel.DataAnnotations;
using Review4_.NET.Models;

namespace Review4_.NET.ViewModels
{
    public class CommentViewModel
    {
        public User User { get; set; }
        public string Body { get; set; }
        public Post post { get; set; }
    }
}

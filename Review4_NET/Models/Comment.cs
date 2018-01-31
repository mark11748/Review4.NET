using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review4_.NET.Models
{
    [Table("Comments")]
    public class Comment
    {
        public Comment(){}
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}

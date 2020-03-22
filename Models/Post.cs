using System.ComponentModel.DataAnnotations;
using blog.Areas.Identity.Data;

namespace blog.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        public string Title {get;set;}

        public string Slug {get;set;}

        public Category Category {get;set;}

        public Writer Writer {get;set;}

    }
}
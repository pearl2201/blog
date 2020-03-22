using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using blog.Areas.Identity.Data;

namespace blog.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Writer writer;
    }
}
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using blog.Areas.Identity.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Writer writer {get;set;}


        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Category()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
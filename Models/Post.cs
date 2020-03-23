using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public ICollection<PostTag> PostTags {get;set;}

        public DateTime CreatedDate { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModifiedDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Post(){
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
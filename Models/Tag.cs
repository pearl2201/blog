using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using blog.Areas.Identity.Data;

namespace blog.Models
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<PostTag> postTags {get;set;}

        public DateTime CreatedDate { get; set; }
     

        public Tag()
        {
            CreatedDate = DateTime.Now;

           
        }
    }
}
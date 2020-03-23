using System;
using System.ComponentModel.DataAnnotations;
using blog.Areas.Identity.Data;

namespace blog.Models
{
    public class PostTag
    {
       
        public int PostID {get;set;}
        public Post Post { get; set; }

        public Tag Tag { get; set; }
        public int TagID {get;set;}


    }
}
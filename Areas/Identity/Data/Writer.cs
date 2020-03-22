using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using blog.Models;
using Microsoft.AspNetCore.Identity;

namespace blog.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Writer class
    public class Writer : IdentityUser
    {
        public ICollection<Category> Categories;
        public ICollection<Post> posts;
    }
}

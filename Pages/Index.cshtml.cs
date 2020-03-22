using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using blog.Data;
namespace blog.Pages
{
    public class IndexModel : LayoutModel<IndexModel>
    {

       public IndexModel(ILogger<IndexModel> logger, BlogIdentityDbContext context) : base(logger, context)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace blog.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {



        public PrivacyModel(ILogger<PrivacyModel> logger, BlogIdentityDbContext context)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace blog.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : LayoutModel<ErrorModel>
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public ErrorModel(ILogger<ErrorModel> logger, BlogIdentityDbContext context) : base(logger, context)
        {

        }


        public override async Task OnGetAsync() 
        {
            await base.OnGetAsync();
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}

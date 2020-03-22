using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Data;
using blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace blog.Models.Services{
    public class LayoutService{
        private readonly BlogIdentityDbContext _context;
        private readonly ILogger<LayoutService> _logger;

        
        public IList<Category> Categories {get;set;}
        public LayoutService(ILogger<LayoutService> logger,BlogIdentityDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IList<Category>> AsyncGetCategories()
        {
            var categories = from m in _context.Categories select m;
            return await categories.ToListAsync();
        }
    }
}
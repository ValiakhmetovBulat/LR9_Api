using Api.Models;

namespace Api
{
    public class Global
    {
        private static ApiContext _context;
        public static ApiContext ApiContext
        {
            get { return _context ?? (_context = new ApiContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApiContext>())); }
        }
    }
}

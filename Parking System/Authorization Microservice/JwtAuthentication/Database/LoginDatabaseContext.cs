using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Database
{
    public class LoginDatabaseContext: DbContext
    {
        public LoginDatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Login> Logins { get; set; }
    }
}

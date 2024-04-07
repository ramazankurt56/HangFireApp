using Microsoft.EntityFrameworkCore;

namespace HangFireApp.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}

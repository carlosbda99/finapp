using Finapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Finapp.Repository.Context;

public class FinappContext : DbContext
{
    public FinappContext(DbContextOptions<FinappContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;
}
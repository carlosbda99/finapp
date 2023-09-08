using Finapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Finapp.Repository.Context;

public class FinappContext : DbContext
{
    public FinappContext(DbContextOptions<FinappContext> options) : base(options) { }

    public DbSet<Bill> Bills { get; set; } = null!;
}
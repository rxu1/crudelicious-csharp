using Microsoft.EntityFrameworkCore; 
using System.Linq; 
using Microsoft.AspNetCore.Mvc; 
using CRUDelicious.Models;

namespace CRUDelicious.Models
{
  public class crudeliciousContext : DbContext
  {
    public crudeliciousContext(DbContextOptions options) : base(options) { }
    public DbSet<Dishes> Dishes { get; set; }
  }
}
using alura_backend_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace alura_backend_csharp.Data;

public class TutorContext : DbContext
{
    public TutorContext(DbContextOptions<TutorContext> opts) : base(opts)
    { }

    public DbSet<Tutor> Tutores { get; set; }

}

using ELearn.Core.Domain;
using ELearn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELearn.Persistence.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Author> GetAuthorWithCourses(int id)
    {
        return AppDbContext.Authors.Include(a => a.Courses).SingleOrDefaultAsync(a => a.Id == id);
    }

    public AppDbContext AppDbContext
    {
        get { return Context as AppDbContext; }
    }
}
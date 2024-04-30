using ELearn.Core;
using ELearn.Core.Repositories;
using ELearn.Persistence.Repositories;

namespace ELearn.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Courses = new CourseRepository(_context);
        Authors = new AuthorRepository(_context);
    }

    public ICourseRepository Courses { get; private set; }
    public IAuthorRepository Authors { get; private set; }

    public Task<int> CompleteAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
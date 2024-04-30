using ELearn.Core.Domain;
using ELearn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELearn.Persistence.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) 
        : base(context)
    {
    }

    public async Task<IEnumerable<Course>> GetTopSellingCourses(int count)
    {
        return await AppDbContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToListAsync();
    }

    public async Task<IEnumerable<Course>> GetCoursesWithAuthorsAsync(int pageIndex, int pageSize = 10)
    {
        return await AppDbContext.Courses
            .Include(c => c.Author)
            .OrderBy(c => c.Name)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public AppDbContext AppDbContext
    {
        get { return Context as AppDbContext; }
    }
}
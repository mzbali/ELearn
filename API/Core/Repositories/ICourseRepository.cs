using ELearn.Core.Domain;

namespace ELearn.Core.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    Task<IEnumerable<Course>> GetTopSellingCourses(int count);
    Task<IEnumerable<Course>> GetCoursesWithAuthorsAsync(int pageIndex, int pageSize);
}
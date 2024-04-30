using ELearn.Core.Domain;

namespace ELearn.Core.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author> GetAuthorWithCourses(int id);
}
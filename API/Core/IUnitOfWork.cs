using ELearn.Core.Repositories;

namespace ELearn.Core;

public interface IUnitOfWork : IDisposable
{
    ICourseRepository Courses { get; }
    IAuthorRepository Authors { get; }
    Task<int> CompleteAsync();
}
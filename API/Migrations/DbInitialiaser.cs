using ELearn.Core.Domain;
using ELearn.Persistence;

namespace ELearn.Migrations;

public static class DbInitialiser
{
    public static async Task InitialiseAsync(AppDbContext context)
    {
        if (!context.Tags.Any())
        {
            var tags = new Dictionary<string, Tag>
            {
                { "c#", new Tag { Id = 1, Name = "c#" } },
                { "angularjs", new Tag { Id = 2, Name = "angularjs" } },
                { "javascript", new Tag { Id = 3, Name = "javascript" } },
                { "nodejs", new Tag { Id = 4, Name = "nodejs" } },
                { "oop", new Tag { Id = 5, Name = "oop" } },
                { "linq", new Tag { Id = 6, Name = "linq" } }
            };

            await context.Tags.AddRangeAsync(tags.Values);
            await context.SaveChangesAsync();
        }

        if (!context.Authors.Any())
        {
            var authors = new List<Author>
            {
                new() { Id = 1, Name = "Mosh Hamedani" },
                new() { Id = 2, Name = "Anthony Alicea" },
                new() { Id = 3, Name = "Eric Wise" },
                new() { Id = 4, Name = "Tom Owsiak" },
                new() { Id = 5, Name = "John Smith" }
            };

            await context.Authors.AddRangeAsync(authors);
            await context.SaveChangesAsync();
        }

        if (!context.Courses.Any())
        {
            var courses = new List<Course>
            {
                new()
                {
                    Id = 1,
                    Name = "C# Basics",
                    AuthorId = 1,
                    FullPrice = 49,
                    Description = "Description for C# Basics",
                    Level = 1,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "c#") }
                },
                new()
                {
                    Id = 2,
                    Name = "C# Intermediate",
                    AuthorId = 1,
                    FullPrice = 49,
                    Description = "Description for C# Intermediate",
                    Level = 2,
                    Tags = new List<Tag>
                    {
                        context.Tags.Single(t => t.Name == "c#"),
                        context.Tags.Single(t => t.Name == "oop")
                    }
                },
                new()
                {
                    Id = 3,
                    Name = "C# Advanced",
                    AuthorId = 1,
                    FullPrice = 69,
                    Description = "Description for C# Advanced",
                    Level = 3,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "c#") }
                },
                new()
                {
                    Id = 4,
                    Name = "Javascript: Understanding the Weird Parts",
                    AuthorId = 2,
                    FullPrice = 149,
                    Description = "Description for Javascript",
                    Level = 2,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "javascript") }
                },
                new()
                {
                    Id = 5,
                    Name = "Learn and Understand AngularJS",
                    AuthorId = 2,
                    FullPrice = 99,
                    Description = "Description for AngularJS",
                    Level = 2,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "angularjs") }
                },
                new()
                {
                    Id = 6,
                    Name = "Learn and Understand NodeJS",
                    AuthorId = 2,
                    FullPrice = 149,
                    Description = "Description for NodeJS",
                    Level = 2,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "nodejs") }
                },
                new()
                {
                    Id = 7,
                    Name = "Programming for Complete Beginners",
                    AuthorId = 3,
                    FullPrice = 45,
                    Description = "Description for Programming for Beginners",
                    Level = 1,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "c#") }
                },
                new()
                {
                    Id = 8,
                    Name = "A 16 Hour C# Course with Visual Studio 2013",
                    AuthorId = 4,
                    FullPrice = 150,
                    Description = "Description 16 Hour Course",
                    Level = 1,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "c#") }
                },
                new()
                {
                    Id = 9,
                    Name = "Learn JavaScript Through Visual Studio 2013",
                    AuthorId = 4,
                    FullPrice = 20,
                    Description = "Description Learn Javascript",
                    Level = 1,
                    Tags = new List<Tag> { context.Tags.Single(t => t.Name == "javascript") }
                }
            };

            await context.Courses.AddRangeAsync(courses);
            await context.SaveChangesAsync();
        }
    }
}
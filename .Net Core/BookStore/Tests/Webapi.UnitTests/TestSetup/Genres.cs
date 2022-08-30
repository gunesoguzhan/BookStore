using Webapi.Data;
using Webapi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre()
                {
                    Name = "Personal Growth",
                    IsActive = true
                },
                new Genre()
                {
                    Name = "Science Fiction",
                    IsActive = true
                },
                new Genre()
                {
                    Name = "Noval",
                    IsActive = false
                }
            );
        }
    }
}
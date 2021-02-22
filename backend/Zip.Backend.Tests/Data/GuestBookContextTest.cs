using System;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Zip.Backend.Data;

namespace Zip.Backend.Tests.Data
{
    public class GuestBookContextTest
    {
        [Fact]
        public async void Test1()
        {
            // Setup
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<GuestBookContext>()
                .UseInMemoryDatabase(databaseName: dbName).Options;
            
            var expectedGuest = new Guest()
            {
                Id = Guid.NewGuid(),
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                Created = DateTime.Now
            };
            
            // Seed
            await using (var dbContext = new GuestBookContext(options))
            {
                await dbContext.GuestBook.AddAsync(expectedGuest);
                await dbContext.SaveChangesAsync();
            }

            // Verify if insert works
            await using (var dbContext = new GuestBookContext(options))
            {
                var actualGuest = await dbContext.GuestBook.SingleAsync(x => x.Id == expectedGuest.Id);
        
                // verify reference
                actualGuest.Should().NotBe(null);

                // verify properties
                actualGuest.Id.Should().Be(expectedGuest.Id);
                actualGuest.FirstName.Should().Be(expectedGuest.FirstName);
                actualGuest.LastName.Should().Be(expectedGuest.LastName);
                actualGuest.Created.Should().Be(expectedGuest.Created);
            }
        }
        [Fact]
    public async void Test2()
    {
      // Setup
      var dbName = Guid.NewGuid().ToString();
      var options = new DbContextOptionsBuilder<GuestBookContext>()
          .UseInMemoryDatabase(databaseName: dbName).Options;

    
      var expectedNewPicture = new DogsRandomPictures()
      {
        Id = Guid.NewGuid(),
        FileSize = 78505,
        Pictureurl = Guid.NewGuid().ToString(),
        Created = DateTime.Now
      };

      // Seed
      await using (var dbContext = new GuestBookContext(options))
      {
        await dbContext.DogRandomPictures.AddAsync(expectedNewPicture);
        await dbContext.SaveChangesAsync();
      }

      // Verify if insert works
      await using (var dbContext = new GuestBookContext(options))
      {
        var actualGuest = await dbContext.DogRandomPictures.SingleAsync(x => x.Id == expectedNewPicture.Id);

        // verify reference
        actualGuest.Should().NotBe(null);

        // verify properties
        actualGuest.Id.Should().Be(expectedNewPicture.Id);
        actualGuest.FileSize.Should().Be(expectedNewPicture.FileSize);
        actualGuest.Pictureurl.Should().Be(expectedNewPicture.Pictureurl);
        actualGuest.Created.Should().Be(expectedNewPicture.Created);
      }
    }
  }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAwardsAPI.Controllers;
using MoviesAwardsAPI.Models;
using Xunit;
using MoviesAwardsAPI.Models.Context;

namespace MoviesAwardsAPITests
{
    public class MoviesControllerTests
    {
        private readonly MoviesAwardsDbContext context;
        public MoviesControllerTests()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<MoviesAwardsDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").UseInternalServiceProvider(serviceProvider);
            context = new MoviesAwardsDbContext(builder.Options);
            context.AddRange(Enumerable.Range(1, 10).Select(t => new Title { TitleId = t }));
            context.SaveChanges();
        }
        [Fact]
        public async Task GetAllTasks()
        {
            // Arrange
            var controller = new MovieController(context);
            //Act
            var result = await controller.GetAllTitles();
            //Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Title>>(result);
            Assert.Equal(10, model.Count());
        }


        [Fact]
        public async Task GetMovieById_NotFound_InvalidId()
        {
            // Arrange
            var controller = new MovieController(context);

            //Act
            var result = await controller.GetTitle(100);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutMovie_BadRequestWhenInvalidId()
        {
            // Arrange
            var controller = new MovieController(context);

            //Act
            var result = await controller.PutTitle(100, new Title { TitleId = 100, TitleName = "Test"});

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutMovie_BadRequestWhenInvalidMovieUpdateRequest()
        {
            // Arrange
            var controller = new MovieController(context);

            //Act
            var result = await controller.PutTitle(1, new Title { TitleId = 2, TitleName = "Test" });

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async Task DeleteMovie_NotFoundWhenInvalidId()
        {
            // Arrange
            var controller = new MovieController(context);

            //Act
            var result = await controller.DeleteTitle(100);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteMovie_NoContentWhenItemDeleted()
        {
            // Arrange
            var controller = new MovieController(context);

            //Act
            var result = await controller.DeleteTitle(2);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

    }
}

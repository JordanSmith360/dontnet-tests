//Moq
//FluentAsasertions
//How to Test

using DotnetTests.Application.Contracts;
using DotnetTests.Application.Features.Users;
using DotnetTests.Domain.Models;
using FluentAssertions;
using Moq;

namespace DotnetTests.Tests;

public class When_adding_a_user
{
    private IUserService _userService;
    private Mock<IUserRepository> _mockUserRepo;

    public When_adding_a_user()
    {
        _mockUserRepo = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepo.Object);
    }

    //[Fact]
    //public async Task When_adding_a_user_Return_an_int()
    //{
    //    var user = new User();
    //    var result = await _userService.CreateUserAsync(user);

    //    result.Should().Be(-1);
    //}

    //

    [Fact]
    public async Task Then_repository_should_be_invoked()
    {
        var user = new User();
        await _userService.CreateUserAsync(user);

        _mockUserRepo.Verify((x) => x.AddUserAsync(It.IsAny<User>()),
            Times.Once);
    }

    [Fact]
    public async Task With_repo_return_an_int_Then_function_return_should_be_that_value()
    {
        var stub = 1;
        var user = new User();
        _mockUserRepo.Setup(x => x.AddUserAsync(It.IsAny<User>()))
            .ReturnsAsync(stub);

        var result = await _userService.CreateUserAsync(user);

        result.Should().Be(stub);
    }

    [Fact]
    public async Task With_repo_throwing_an_error_Then_negative_one_should_be_returned()
    {
        var user = new User();
        _mockUserRepo.Setup(x => x.AddUserAsync(It.IsAny<User>()))
            .ThrowsAsync(new Exception("My Exception"));

        var result = await _userService.CreateUserAsync(user);

        result.Should().Be(-1);
    }
}
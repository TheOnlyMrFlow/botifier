using System;
using FluentAssertions;
using Xunit;

namespace WD.Botifier.SeedWork.Test;

public class IdValueBaseTest
{
    class UserId : IdValueBase
    {
        public UserId(Guid value) : base(value) { }
    }
    
    class AccountId : IdValueBase
    {
        public AccountId(Guid value) : base(value) { }
    }
    
    [Fact]
    public void Given_TwoIdValuesOfTheSameClassWithSameValue_Then_TheyShouldBeEqual()
    {
        var guid = Guid.Parse("34d4e050-36bd-4a23-98f2-fc8bddde412c");
        var userId1 = new UserId(guid);
        var userId2 = new UserId(guid);

        userId1.Should().Be(userId2);
    }
    
    [Fact]
    public void Given_TwoIdValuesOfTheSameClassWithDifferentValue_Then_TheyShouldNotBeEqual()
    {
        var guid1 = Guid.Parse("34d4e050-36bd-4a23-98f2-fc8bddde412c");
        var userId1 = new UserId(guid1);
        
        var guid2 = Guid.Parse("64dabcc5-3dfe-443b-9c5e-f3fbee54e341");
        var userId2 = new UserId(guid2);

        userId1.Should().NotBe(userId2);
    }
    
    [Fact]
    public void Given_TwoStringValuesOfDifferentClassWithSameValue_Then_TheyShouldNotBeEqual()
    {
        var guid = Guid.Parse("34d4e050-36bd-4a23-98f2-fc8bddde412c");
        var userId = new UserId(guid);
        var accountId = new AccountId(guid);

        userId.Should().NotBe(accountId);
    }
}
using FluentAssertions;
using Xunit;

namespace WD.Botifier.SeedWork.Test;

public class StringValueBaseTest
{
    class FirstName : StringValueBase
    {
        public FirstName(string value) : base(value) { }
    }
    
    class LastName : StringValueBase
    {
        public LastName(string value) : base(value) { }
    }
    
    [Fact]
    public void Given_TwoStringValuesOfTheSameClassWithSameValue_Then_TheyShouldBeEqual()
    {
        var firstName1 = new FirstName("Michel");
        var firstName2 = new FirstName("Michel");

        firstName1.Should().Be(firstName2);
    }
    
    [Fact]
    public void Given_TwoStringValuesOfTheSameClassWithDifferentValue_Then_TheyShouldNotBeEqual()
    {
        var firstName1 = new FirstName("Michel");
        var firstName2 = new FirstName("Roger");

        firstName1.Should().NotBe(firstName2);
    }
    
    [Fact]
    public void Given_TwoStringValuesOfDifferentClassWithSameValue_Then_TheyShouldNotBeEqual()
    {
        var firstName = new FirstName("Michel");
        var lastName = new LastName("Michel");

        firstName.Should().NotBe(lastName);
    }
}
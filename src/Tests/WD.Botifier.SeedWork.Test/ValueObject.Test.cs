using FluentAssertions;
using Xunit;

namespace WD.Botifier.SeedWork.Test;

public class ValueObjectTest
{
    class AmountOfFiatMoney : ValueObject
    {
        public AmountOfFiatMoney(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        
        public decimal Amount { get; }
        
        public string Currency { get; }
    }
    
    class AmountOfCryptoMoney : ValueObject
    {
        public AmountOfCryptoMoney(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        
        public decimal Amount { get; }
        
        public string Currency { get; }
    }
    
    [Fact]
    public void Given_TwoValueObjectsOfTheSameClassWithSameAttributeValues_Then_TheyShouldBeEqual()
    {
        var amount1 = new AmountOfFiatMoney(10m, "USD");
        var amount2 = new AmountOfFiatMoney(10m, "USD");

        amount1.Should().Be(amount2);
    }
    
    [Fact]
    public void Given_TwoValueObjectsOfTheSameClassWithDifferentAttributeValues_Then_TheyShouldNotBeEqual()
    {
        var amount1 = new AmountOfFiatMoney(10m, "USD");
        var amount2 = new AmountOfFiatMoney(10m, "EUR");

        amount1.Should().NotBe(amount2);
    }
    
    [Fact]
    public void Given_TwoValueObjectsOfDifferentClassWithSameAttributeValues_Then_TheyShouldNotBeEqual()
    {
        var amount1 = new AmountOfFiatMoney(10m, "USD");
        var amount2 = new AmountOfCryptoMoney(10m, "USD");

        amount1.Should().NotBe(amount2);
    }
}
using JsonReader.Extensions;

namespace JsonReader.Tests.UnitTests;

public class EmployeeCommandProcessorTests
{
    [Test]
    public void ConvertToNumber_ShouldReturnFalse_WhenInputIsInvalid()
    {
        const string input = "invalid_number";
        
        var result = ConsoleHelper.ConvertToNumber<int>(input);

        Assert.That(result.IsT1);
    }
    
    [Test]
    public void ConvertToNumber_ShouldReturnIntValue_WhenInputIsIntNumber()
    {
        const string input = "324";
        
        var result = ConsoleHelper.ConvertToNumber<int>(input);
        
        Assert.That(result.IsT0);
    }
    
    [Test]
    public void ConvertToNumber_ShouldReturnFloatValue_WhenInputIsFloatNumber()
    {
        const string input = "324,324";
        
        var result = ConsoleHelper.ConvertToNumber<float>(input);
        
        Assert.That(result.IsT0);
    }
    
    [Test]
    public void ConvertToNumber_ShouldReturnDoubleValue_WhenInputIsDoubleNumber()
    {
        const string input = "324,324";
        
        var result = ConsoleHelper.ConvertToNumber<double>(input);
        
        Assert.That(result.IsT0);
    }
    
    [Test]
    public void ConvertToNumber_ShouldReturnDecimalValue_WhenInputIsDecimalNumber()
    {
        const string input = "324,324";
        
        var result = ConsoleHelper.ConvertToNumber<decimal>(input);
        
        Assert.That(result.IsT0);
    }
}
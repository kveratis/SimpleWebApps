namespace BusinessRules.Demo.SimpleBusinessRules;


public class Demo
{
    [Theory]
    [MemberData(nameof(Usernames))]
    public void CheckUsernames(string value, bool expected)
    {
        // Arrange
        var sut = new Username(value);
    }

    public static IEnumerable<object[]> Usernames()
    {
        return new List<object[]>()
        {
            new object[]{"a", false},
            new object[]{"", false},
            new object[]{null!, false},
            new object[]{"abc*", false},
            new object[]{"abc", true},
        };
    }
}


public record Username
{
    private readonly string value;
    
    public Username(string value)
    {
        bool valid = value switch
        {
            "" => false,
            { Length: > 50 } => false,
            { Length: < 3 } => false,
            _ => true
        };

        if (!value.Any(char.IsLetterOrDigit)) throw new ArgumentException();

        if (!valid) throw new ArgumentException();
        
        this.value = value;
    }

    public string Value => value;
}
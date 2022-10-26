using CSharpFunctionalExtensions;

namespace Domain;

public class User
{
    private User(string name)
    { 
        Name = name;
    }

    public static Result<User> Create(string name)
    {
        if (name.StartsWith("A"))
            return Result.Failure<User>("ljsdlsqd");
        return new User(name);
    }

    private string Name { get; }
}
namespace EfCoreInheritanceProblem;

public class Name
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    public string FirstName { get; }
    public string LastName { get; }
}

public abstract class Parent
{
    public Guid Id { get; set; }
}

public class ChildOne : Parent
{
    public int Number { get; set; }
}

public class ChildTwo : Parent
{
    public Name Name { get; set; }
}
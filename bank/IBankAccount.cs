namespace bank;

public interface IBankAccount : IAccount
{
    public Person Owner { get; }
    public string Number { get; }
    object? ApplyInterests();
}
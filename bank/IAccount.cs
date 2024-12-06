namespace bank;

public interface IAccount
{
    public double Balance { get; }
    void Deposit(double amount);
    void Withdraw(double amount);
}
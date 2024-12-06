using bank;

public abstract class Account : IBankAccount
{
    protected double balance { get; private set; }
    public string Number { get; }

    public double Balance => balance;
    public Person Owner { get; }
    
    public Account(string number, double balance, Person owner)
    {
        Number = number;
        this.balance = balance;
        Owner = owner;
    }
    
    public void Withdraw(double amount)
    {
        balance -= amount;
    }
    
    public void Deposit(double amount)
    {
        balance += amount;
    }

    protected abstract double CalculateInterests();

    public object ApplyInterests()
    {
        return CalculateInterests();
    }
}
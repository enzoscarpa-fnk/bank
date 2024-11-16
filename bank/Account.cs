public class Account
{
    protected string type { get; private set; }
    protected double balance { get; private set; }
    public string Number { get; set; }
    public string Type
    {
        get => type;
        set => type = value;
    }

    public double Balance => balance;
    public Person Owner { get; set; }
    
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
}
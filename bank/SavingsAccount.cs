public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; private set; }
    
    public SavingsAccount(string number, string type, double balance, Person owner, DateTime dateLastWithdraw) : base(number, balance, owner)
    {
        Type = "Savings";
        DateLastWithdraw = dateLastWithdraw;
    }
    
    public void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine($"You cannot withdraw more than {Balance:C}.");
        }
        else
        {
            base.Withdraw(amount);
            Console.WriteLine($"You withdrew {amount:C}.");
            Console.WriteLine($"The balance is now {Balance:C}.");
        }
    }

    public void Deposit(double amount)
    {
        base.Deposit(amount);
        Console.WriteLine($"You deposited {amount:C} to your balance.");
        Console.WriteLine($"The balance is now {Balance:C}.");
    }
}
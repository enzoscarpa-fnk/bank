public class CurrentAccount : Account
{
    public double MaxCreditLine { get; set; }
    public double CreditLineUsed { get; private set; }

    public CurrentAccount(string number, string type, double balance, double maxCreditLine, Person owner) : base(number, balance, owner)
    {
        Type = "Current";
        MaxCreditLine = maxCreditLine;
        CreditLineUsed = 0;
    }

    public void Withdraw(double amount)
    {
        if (amount > (Balance + (MaxCreditLine - CreditLineUsed)))
        {
            Console.WriteLine($"You cannot withdraw more than {(Balance + (MaxCreditLine - CreditLineUsed)):C}.");
        }
        else
        {
            if (amount > Balance && amount <= (Balance + (MaxCreditLine - CreditLineUsed)))
            {
                double amountToWithdraw = amount;
                double difference = amountToWithdraw - Balance;
                base.Withdraw(amountToWithdraw-difference);
                CreditLineUsed += difference;
            }
            else
            {
                base.Withdraw(amount);
            }
            Console.WriteLine($"You withdrew {amount:C}.");
            Console.WriteLine($"The balance is now {Balance:C}. The credit line used is now {CreditLineUsed:C}. The credit line limit allowed is {MaxCreditLine:C}.");
        }
    }

    public void Deposit(double amount)
    {
        if (CreditLineUsed > 0)
        {
            if (amount >= CreditLineUsed)
            {
                amount -= CreditLineUsed;
                CreditLineUsed = 0;
                base.Deposit(amount);
                Console.WriteLine($"You repaid the credit line and deposited {amount:C} to your balance.");
            }
            else
            {
                CreditLineUsed -= amount;
                Console.WriteLine($"You repaid {amount:C} to your credit line. No money was added to your balance.");
            }
        }
        else
        {
            base.Deposit(amount);
            Console.WriteLine($"You deposited {amount:C} to your balance.");
        }
        Console.WriteLine($"The balance is now {Balance:C}. The credit line used is now {CreditLineUsed:C}. The credit line limit allowed is {MaxCreditLine:C}.");
    }
}
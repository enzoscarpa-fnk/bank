// Exercice banque
Person p1 = new Person("Jean", "Paroit", 12, 03, 1993);
CurrentAccount ca1 = new CurrentAccount("BE93001938277309", 12900, 1000, p1);
p1.ShowPersonInfo();
ca1.ShowAccountInfo();
menu();

void menu()
{
    bool exit = false;
    Console.WriteLine("Welcome to your bank!");
    while (exit == false)
    {
        Console.WriteLine("Please select an action.");
        Console.WriteLine("| [1] Withdraw money | [2] Deposit Money | [3] Exit |");
        var inputIsNumber = int.TryParse(Console.ReadLine(), out int input);
        if (!inputIsNumber)
        {
            Console.WriteLine("Please select a valid action.");
        }

        switch (input)
        {
            case 1:
                Console.WriteLine("Enter the amount of money you want to withdraw: ");
                var withdrawIsNumber = double.TryParse(Console.ReadLine(), out double withdrawAmount);
                if (!withdrawIsNumber)
                {
                    Console.WriteLine("Please input a valid amount.");
                }

                ca1.Withdraw(withdrawAmount);
                break;
            case 2:
                Console.WriteLine("Enter the amount of money you want to deposit: ");
                var depositIsNumber = double.TryParse(Console.ReadLine(), out double depositAmount);
                if (!depositIsNumber)
                {
                    Console.WriteLine("Please input a valid amount.");
                }

                ca1.Deposit(depositAmount);
                break;
            case 3:
                Console.WriteLine($"Thank you for your visit. Have a nice day!");
                exit = true;
                break;
        }
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
    public Person(string firstName, string lastName, int day, int month, int year)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = new DateTime(year, month, day);
    }

    public void ShowPersonInfo()
    {
        Console.WriteLine($"First Name: {FirstName} | Last Name: {LastName} | Birth Date: {BirthDate.ToShortDateString()}");
    }
}
public class CurrentAccount
{
    private double balance;
    public string Number { get; set; }
    public double Balance => balance;
    public double MaxCreditLine { get; set; }
    public double CreditLineUsed { get; private set; }
    // public double CreditLine { get; set; }
    public Person Owner { get; set; }
    
    public CurrentAccount(string number, double balance, double maxCreditLine, Person owner)
    {
        Number = number;
        this.balance = balance;
        MaxCreditLine = maxCreditLine;
        CreditLineUsed = 0;
        //CreditLine = creditLine;
        Owner = owner;
    }

    public void ShowAccountInfo()
    {
        Console.WriteLine($"Account Number: {Number} | Balance: {balance:C} | Credit Used: {CreditLineUsed:C} | Max Credit Line: {MaxCreditLine:C} | Owner: {Owner.FirstName} {Owner.LastName}");
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
                balance = 0;
                CreditLineUsed += difference;
            }
            else
            {
                balance -= amount;
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
                balance += amount;
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
            balance += amount;
            Console.WriteLine($"You deposited {amount:C} to your balance.");
        }
        Console.WriteLine($"The balance is now {Balance:C}. The credit line used is now {CreditLineUsed:C}. The credit line limit allowed is {MaxCreditLine:C}.");
    }
}

/*class Bank()
{
    private Dictionary<string, CurrentAccount> Accounts { get; }
    string Name { get; set; }

    void AddAccount(CurrentAccount account)
    {
        Console.WriteLine($"Who is the owner of the new account?");
        string owner = Console.ReadLine();
        Console.WriteLine($"What is the name of the new account?");
        var name = Console.ReadLine();
        Console.WriteLine($"What is the number of the new account?");
        string number = Console.ReadLine();
        Console.WriteLine($"What is the balance of the new account?");
        var balanceRead = double.TryParse(Console.ReadLine(), out double balance);
        Console.WriteLine($"What is the credit line of the new account?");
        var creditLineRead = double.TryParse(Console.ReadLine(), out double creditLine);
        CurrentAccount name = new(number, balance, creditLine, owner);
    }

    void DeleteAccount(CurrentAccount account)
    {
        
    }
}*/
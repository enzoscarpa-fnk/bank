using System.Linq;
using bank;

class Bank
{
    public static Dictionary<string, Account> Accounts { get; } = new();
    public string? Name { get; set; }

    public static void AddAccount(Account account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine($"Account {account.Number} already exists.");
        }
        else
        {
            Accounts.Add(account.Number, account);
        }
    }

    public static void DeleteAccount(string number)
    {
        if (Accounts.ContainsKey(number))
        {
            Console.WriteLine("Type DELETE to delete account.");
            var confirm = Console.ReadLine();
            if (confirm == "DELETE")
            {
                Accounts.Remove(number);
                Console.WriteLine($"Account {number} has been deleted.");
            }
        }
        else
        {
            Console.WriteLine("Account not found");
        }
    }

    public static void ShowAccounts()
    {
        Console.WriteLine("List of your accounts:");
        foreach (KeyValuePair<string, Account> kvp in Accounts)
        {
            if (kvp.Value is CurrentAccount currentAccount)
            {
                Console.WriteLine(
                    "Account Number: {0} | Balance: {1:C} | Credit Used: {2:C} | Max Credit Line: {3:C} | Owner: {4} {5}", kvp.Key, currentAccount.Balance, currentAccount.CreditLineUsed, currentAccount.MaxCreditLine, currentAccount.Owner.FirstName, currentAccount.Owner.LastName);
            }
            else if (kvp.Value is SavingsAccount savingsAccount)
            {
                Console.WriteLine("Account Number: {0} | Balance: {1:C} | Owner: {2} {3}", kvp.Key, savingsAccount.Balance, savingsAccount.Owner.FirstName, savingsAccount.Owner.LastName);
            }
        }
    }

    public static void ShowTotalBalance()
    {
        var totalBalance = Accounts.Sum(x => x.Value.Balance);
        Console.WriteLine($"Total balance: {totalBalance:C}");
    }
    
    public static void CalculateInterests()
    {
        Console.WriteLine("List of your accounts with interests:");
        foreach (KeyValuePair<string, Account> kvp in Accounts)
        {
            if (kvp.Value is CurrentAccount currentAccount)
            {
                Console.WriteLine(
                    "Account Number: {0} | Balance: {1:C} | Credit Used: {2:C} | Max Credit Line: {3:C} | Balance with interests: {4:C} | Owner: {5} {6}", kvp.Key, currentAccount.Balance, currentAccount.CreditLineUsed, currentAccount.MaxCreditLine, currentAccount.ApplyInterests(), currentAccount.Owner.FirstName, currentAccount.Owner.LastName);
            }
            else if (kvp.Value is SavingsAccount savingsAccount)
            {
                Console.WriteLine("Account Number: {0} | Balance: {1:C} | Balance with interests: {2:C} | Owner: {3} {4}", kvp.Key, savingsAccount.Balance, savingsAccount.ApplyInterests(), savingsAccount.Owner.FirstName, savingsAccount.Owner.LastName);
            }
        }
    }
}
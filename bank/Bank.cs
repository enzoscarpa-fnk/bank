class Bank()
{
    public static Dictionary<string, CurrentAccount> Accounts { get; } = [];
    public string Name { get; set; }

    public static void AddAccount(CurrentAccount account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine($"Account {account} already exists.");
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
            Accounts.Remove(number);
            Console.WriteLine($"Account {number} has been deleted.");
        }
        else
        {
            Console.WriteLine("Account not found");
        }
    }

    public static void ShowAccounts()
    {
        Console.WriteLine("List of your accounts:");
        foreach (KeyValuePair<string, CurrentAccount> kvp in Accounts)
        {
            Console.WriteLine("Account Number: {0} | Balance: {1:C} | Credit Used: {2:C} | Max Credit Line: {3:C} | Owner: {4} {5}", kvp.Key, kvp.Value.Balance, kvp.Value.CreditLineUsed, kvp.Value.MaxCreditLine, kvp.Value.Owner.FirstName, kvp.Value.Owner.LastName);
        }
    }
}
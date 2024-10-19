// Exercice banque
Person p1 = new Person("Jean", "Paroit", 12, 03, 1993);
CurrentAccount ca1 = new CurrentAccount("BE93001938277309", 12900, 1000, p1);
Bank.AddAccount(ca1);
p1.ShowPersonInfo();
menu();

void menu()
{
    bool exit = false;
    Console.WriteLine("Welcome to your bank!");
    while (exit == false)
    {
        Console.WriteLine("Please select an action.");
        Console.WriteLine("| [1] Withdraw money | [2] Deposit Money | [3] Add Account | [4] Delete Account | [5] Show Accounts | [6] Exit |");
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
                Console.WriteLine($"What is the number of the new account?");
                string addAccountNumber = Console.ReadLine();
                CurrentAccount currentAccount = new CurrentAccount(addAccountNumber, 0, 1000, p1);
                Bank.AddAccount(currentAccount);
                Console.WriteLine($"Your account number {currentAccount.Number} has been created.");
                break;
            case 4:
                Console.WriteLine($"What is the number of the account you want to delete?");
                string deleteAccountNumber = Console.ReadLine();
                Bank.DeleteAccount(deleteAccountNumber);
                break;
            case 5:
                Bank.ShowAccounts();
                break;
            case 6:
                Console.WriteLine($"Thank you for your visit. Have a nice day!");
                exit = true;
                break;
        }
    }
}
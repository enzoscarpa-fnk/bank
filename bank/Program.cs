// Exercice banque

using bank;

Person p1 = new Person("Jean", "Paroit", 12, 03, 1993);
CurrentAccount ca1 = new CurrentAccount("BE93001938277309", 12900, 1000, p1);
SavingsAccount sa1 = new SavingsAccount("BE60929200108556", 1000, p1, DateTime.MinValue);
Bank.AddAccount(ca1);
Bank.AddAccount(sa1);
p1.ShowPersonInfo();
Bank.ShowAccounts();
menu();

void menu()
{
    bool exit = false;
    Console.WriteLine("Welcome to your bank!");
    while (exit == false)
    {
        Console.WriteLine("Please select an action.");
        Console.WriteLine("| [1] Manage Accounts | [2] Withdraw Money | [3] Deposit Money | [4] Exit |");
        var inputIsNumberM1 = int.TryParse(Console.ReadLine(), out int inputM1);
        if (!inputIsNumberM1)
        {
            Console.WriteLine("Please select a valid action.");
        }

        switch (inputM1)
        {
            case 1:
                Console.WriteLine("| [1] Show Accounts | [2] Add Account | [3] Delete Account | [4] Show Total Balance | [5] Calculate Interests | [6] Back |");
                var inputIsNumberM2 = int.TryParse(Console.ReadLine(), out int inputM2);
                if (!inputIsNumberM2)
                {
                    Console.WriteLine("Please select a valid action.");
                }

                switch (inputM2)
                {
                    case 1:
                        Bank.ShowAccounts();
                        break;
                    case 2:
                        Console.WriteLine($"What is the number of the new account?");
                        string addAccountNumber = Console.ReadLine();
                        CurrentAccount currentAccount = new CurrentAccount(addAccountNumber, 0, 1000, p1);
                        Bank.AddAccount(currentAccount);
                        Console.WriteLine($"Your account number {currentAccount.Number} has been created.");
                        break;
                    case 3:
                        Console.WriteLine($"What is the number of the account you want to delete?");
                        string deleteAccountNumber = Console.ReadLine();
                        Bank.DeleteAccount(deleteAccountNumber);
                        break;
                    case 4:
                        Bank.ShowTotalBalance();
                        break;
                    case 5:
                        Bank.CalculateInterests();
                        break;
                    case 6:
                        menu();
                        break;
                }
                break;
            case 2:
                Console.WriteLine("Enter the amount of money you want to withdraw: ");
                var withdrawIsNumber = double.TryParse(Console.ReadLine(), out double withdrawAmount);
                if (!withdrawIsNumber)
                {
                    Console.WriteLine("Please input a valid amount.");
                }

                ca1.Withdraw(withdrawAmount);
                break;
            case 3:
                Console.WriteLine("Enter the amount of money you want to deposit: ");
                var depositIsNumber = double.TryParse(Console.ReadLine(), out double depositAmount);
                if (!depositIsNumber)
                {
                    Console.WriteLine("Please input a valid amount.");
                }

                ca1.Deposit(depositAmount);
                break;
            case 4:
                Console.WriteLine($"Thank you for your visit. Have a nice day!");
                exit = true;
                break;
        }
    }
}
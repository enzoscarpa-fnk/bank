public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; set; }
    
    public SavingsAccount(string number, double balance, Person owner, DateTime dateLastWithdraw) : base(number, balance, owner)
    {
        DateLastWithdraw = dateLastWithdraw;
    }
}
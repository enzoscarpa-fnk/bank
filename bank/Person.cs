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
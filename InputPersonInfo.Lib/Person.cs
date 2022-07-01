namespace InputPersonInfo.Lib;
public class Person : ICloneable
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public string Patronymic { get; set; }
    public DateTime? SelectedDate { get; set; }
    public Person(){}
    public Person(string? firstName, string? lastName, int age, string patronymic, DateTime? selectedDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Patronymic = patronymic;
        SelectedDate = selectedDate;
    }
    public object Clone()
    {
        return new Person(FirstName, LastName, Age, Patronymic, SelectedDate);
    }
}
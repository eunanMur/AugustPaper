using System.Windows.Controls;
using System;


public class Member : IComparable
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }

    public int Age
    {
        get
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Now.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }

    // Constructor to initialize a member with a first name, surname, and date of birth
    public Member(string firstName, string surname, DateTime dateOfBirth)
    {
        FirstName = firstName;
        Surname = surname;
        DateOfBirth = dateOfBirth;
    }

    // Q7: Override ToString to display player information in the ListBox
    // Format: "FirstName LastName (Age) POSITION"
    public override string ToString()
    {
        return $"{Surname} {FirstName} - {DateOfBirth} ({Age})";
    }

    // Method to compare members based on their surname
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Member otherMember = obj as Member;
        if (otherMember != null)
            return Surname.CompareTo(otherMember.Surname);
        else
            throw new ArgumentException("Object is not a Member");
    }
}
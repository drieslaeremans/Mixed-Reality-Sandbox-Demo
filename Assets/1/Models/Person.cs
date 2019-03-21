using System;
using System.Collections.Generic;

[System.Serializable]
public class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int NationalityId { get; set; }
    public virtual Nationality Nationality { get; set; }
}

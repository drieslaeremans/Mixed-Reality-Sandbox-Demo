using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class DataContext : Singleton<DataContext>
{
    private static int personID;
    private static int natID;

    private System.Random r = new System.Random();

    public List<Person> People
    {
        get; private set;
    }
    public List<Nationality> Nationalities
    {
        get; private set;
    }

    protected DataContext()
    {
        CreateData();
    }

    private void CreateData()
    {
        Nationalities = new List<Nationality>{ 
            new Nationality { ID = Interlocked.Increment(ref natID), Code = "FR", Country = "France"},
            new Nationality { ID = Interlocked.Increment(ref natID), Code = "BE", Country = "Belgium"},
            new Nationality { ID = Interlocked.Increment(ref natID), Code = "DE", Country = "Germany"},
            new Nationality { ID = Interlocked.Increment(ref natID), Code = "ES", Country = "Spain"},
            new Nationality { ID = Interlocked.Increment(ref natID), Code = "IT", Country = "Italy"},
        };

        People = new List<Person>
        {
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Antoine",
                LastName = "Griezmann",
                DateOfBirth = new DateTime(1989, 02, 01),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Maxi",
                LastName = "Gomez",
                DateOfBirth = new DateTime(1995, 04, 26),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Kevin",
                LastName = "De Bruyne",
                DateOfBirth = new DateTime(1993, 02, 06),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Marco",
                LastName = "Veratti",
                DateOfBirth = new DateTime(1994, 04, 04),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Mohamed",
                LastName = "Salah",
                DateOfBirth = new DateTime(1991, 08, 30),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Franco",
                LastName = "Vazquez",
                DateOfBirth = new DateTime(1992, 12, 16),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Sergio",
                LastName = "Ramos",
                DateOfBirth = new DateTime(1988, 06, 22),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
            new Person {
                ID = Interlocked.Increment(ref personID),
                FirstName = "Toni",
                LastName = "Kroos",
                DateOfBirth = new DateTime(1989, 02, 19),
                NationalityId = Nationalities[r.Next(0, Nationalities.Count -1)].ID
            },
        };
    }

    public Person GetRandomPerson()
    {
        System.Random r = new System.Random();
        Person person = People.Skip(r.Next(0, People.Count - 1)).FirstOrDefault();
        person.Nationality = Nationalities.Where(n => n.ID == person.NationalityId).FirstOrDefault();

        return person;
    }

    public Person GetPerson(int id)
    {
        Person person = People.Where(p => p.ID == id).FirstOrDefault();
        person.Nationality = Nationalities.Where(n => n.ID == person.NationalityId).FirstOrDefault();

        return person;
    }

    public List<Person> GetAllPeople()
    {
        List<Person> people = People;
        foreach (var p in people)
        {
            p.Nationality = Nationalities.Where(n => n.ID == p.NationalityId).FirstOrDefault();
        }

        return people;
    }

    public List<Person> GetAllPeopleWhereNationality(int nationalityID)
    {
        List<Person> people = People.FindAll(p => p.NationalityId == nationalityID).ToList();
        foreach (var p in people)
        {
            p.Nationality = Nationalities.Where(n => n.ID == p.NationalityId).FirstOrDefault();
        }

        return people;
    }

    public void CreatePerson(Person person)
    {
        People.Add(person);
    }

    public void UpdatePerson(Person person)
    {
        People.Where(p => p.ID == person.ID).ToList().ForEach(p => p = person);
    }

    public void RemovePerson(Person person)
    {
        int indexToRemove = People.FindIndex(p => p.ID == person.ID);
        People.RemoveAt(indexToRemove);
    }

    public Nationality GetNationality(int id)
    {
        Nationality nationality = Nationalities.Where(n => n.ID == id).FirstOrDefault();

        return nationality;
    }

    public List<Nationality> GetNationalities()
    {
        return Nationalities.OrderBy(n => n.Code).ToList();
    }

    public void CreateNationality(Nationality nationality)
    {
        Nationalities.Add(nationality);
    }

    public void UpdateNationality(Nationality nationality)
    {
        Nationalities.Where(n => n.ID == nationality.ID).ToList().ForEach(n => n = nationality);
    }

    public void RemoveNationality(Nationality nationality)
    {
        int indexToRemove = Nationalities.FindIndex(n => n.ID == nationality.ID);
        Nationalities.RemoveAt(indexToRemove);
    }
}

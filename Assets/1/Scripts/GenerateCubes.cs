using HoloToolkit.Unity.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GenerateCubes : MonoBehaviour
{
    public int itemsPerRow = 4;

    public GameObject prefab;
    private List<Person> people;

    private void Start()
    {
        ObjectCollection objectCollection = gameObject.GetComponent<ObjectCollection>();
        objectCollection.SurfaceType = SurfaceTypeEnum.Plane;
        objectCollection.OrientType = OrientTypeEnum.FaceFoward;
        objectCollection.CellWidth = 0.25f;
        objectCollection.CellHeight = 0.15f;

        objectCollection.UpdateCollection();
    }

    public void SetPeople(List<Person> value)
    {
        people = value;
    }


    // Function called by BroadcastMessage of parent-container People.
    public void ChangeToNewNationality(int newNationalityID = 0)
    {
        SetPeople(DataContext.Instance.GetAllPeopleWhereNationality(newNationalityID));
        StartCoroutine(GenerateDataCubes());
    }

    public IEnumerator GenerateDataCubes()
    {
        DestroyCurrentCubes();

        // Wait for .15 seconds so OnClickHandler doesn't register previous click as new one on the TextPanel object.
        yield return new WaitForSecondsRealtime(.15f);

        if (DataContext.IsInitialized)
        {
            foreach (var person in people)
            {
                GameObject newPanel = Instantiate(prefab);
                newPanel.transform.SetParent(gameObject.transform);

                GameObject textContent;
                if ((textContent = newPanel.transform.Find("TextContent").gameObject) != null)
                {
                    newPanel.GetComponent<PersonObjectHolder>().Person = person;
                    SetObjectData(person, textContent);
                }
            }

            RefreshCollection();
        }
    }

    private static void SetObjectData(Person person, GameObject textContent)
    {
        textContent.transform.Find("Lastname").gameObject.GetComponent<TextMesh>().text = person.LastName;
        textContent.transform.Find("Firstname").gameObject.GetComponent<TextMesh>().text = person.FirstName;
        textContent.transform.Find("Date of Birth").gameObject.GetComponent<TextMesh>().text = person.DateOfBirth.ToString("dd/MM/yyyy");

        string spriteName = person.Nationality.Country.Trim().Replace(" ", "_");
        textContent.transform.Find("Flag").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Flags/" + spriteName);
    }

    private void DestroyCurrentCubes()
    {
        if (transform.childCount <= 0)
        {
            return;
        }

        foreach (Transform child in transform.Cast<Transform>().ToArray())
        {
            Destroy(child.gameObject);
        }
    }

    private void RefreshCollection()
    {
        ObjectCollection objectCollection = gameObject.GetComponent<ObjectCollection>();

        // Calculate items per row : (#People / #ItemsPerRows ) => rounded up to get extra row if amount of rows is not even 
        float rowsFloat = (float)people.Count / (float)itemsPerRow;
        print("count: " + people.Count);
        print("perRow: " + itemsPerRow);
        print("rowsfloat: " + rowsFloat);
        print("RowsInt: " + Convert.ToInt32(Math.Ceiling(rowsFloat)));
        objectCollection.Rows = Convert.ToInt32(Math.Ceiling(rowsFloat));

        objectCollection.UpdateCollection();
    }
}

using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonObjectHolder : MonoBehaviour, IInputClickHandler {

    //public GameObject EditPersonForm;

    public Person Person
    {
        get; set;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (Person == null)
        {
            return;
        } 

        print("Selected: " + Person.FirstName + " " + Person.LastName);
    }
}

using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonObjectHolder : MonoBehaviour, IInputClickHandler {

    public Person Person
    {
        get; set;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        print("Selected: " + Person.FirstName + " " + Person.LastName);
    }
}

using HoloToolkit.UI.Keyboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PersonEditorModes
{
    Create, Update
}

public class PersonEditor : MonoBehaviour
{

    [HideInInspector]
    public PersonEditorModes personEditorMode;
    public Person Person { get; set; }

    private void Awake()
    {
        SetInputFieldValues();
    }

    public void SetInputFieldValues()
    {
        if (personEditorMode == PersonEditorModes.Update && Person != null)
        {
            gameObject.transform.Find("EditPersonCanvas/Background/LastnameInputField").gameObject.GetComponent<KeyboardInputField>().text = Person.LastName;
            gameObject.transform.Find("EditPersonCanvas/Background/FirstnameInputField").gameObject.GetComponent<KeyboardInputField>().text = Person.FirstName;
        }
    }
}

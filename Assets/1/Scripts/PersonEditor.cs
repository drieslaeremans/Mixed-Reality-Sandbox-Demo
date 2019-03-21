using HoloToolkit.UI.Keyboard;
using HoloToolkit.Unity.Receivers;
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
            gameObject.transform.Find("Background/LastnameInputField").gameObject.GetComponent<KeyboardInputField>().text = Person.LastName;
            gameObject.transform.Find("Background/FirstnameInputField").gameObject.GetComponent<KeyboardInputField>().text = Person.FirstName;
        }
    }

    public void SavePerson()
    {
        Person _person = Person;
        GetInputFieldValues(ref _person);

        switch (personEditorMode)
        {
            case PersonEditorModes.Update:
                DataContext.Instance.UpdatePerson(_person);
                break;
            case PersonEditorModes.Create:
                DataContext.Instance.CreatePerson(_person);
                break;
        }

        CancelPerson();
    }

    public void CancelPerson()
    {
        Keyboard.Instance.Close();

        this.SendMessageUpwards("FormFinished", SendMessageOptions.RequireReceiver);
    }

    private void GetInputFieldValues(ref Person person)
    {
        person.LastName = gameObject.transform.Find("Background/LastnameInputField").gameObject.GetComponent<KeyboardInputField>().text;
        person.FirstName = gameObject.transform.Find("Background/FirstnameInputField").gameObject.GetComponent<KeyboardInputField>().text;
    }
}

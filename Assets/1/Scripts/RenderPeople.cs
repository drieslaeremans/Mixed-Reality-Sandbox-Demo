using HoloToolkit.Unity.Receivers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPeople : MonoBehaviour
{
    public GameObject PersonObjectCollection;
    public GameObject ChangeNationalityButton;
    public GameObject PersonForm;

    // Nationality Menu Object
    [SerializeField]
    private GameObject nationalityButtonsCollection;
    private int currentNationalityID;

    // Use this for initialization
    void Awake()
    {

    }

    public void NationalityHasChanged(int newNationalityID)
    {
        currentNationalityID = newNationalityID;
        BroadcastMessage("ChangeToNewNationality", newNationalityID);
    }

    public void GoToChangeNationality()
    {
        gameObject.SetActive(false);

        nationalityButtonsCollection.SetActive(true);
    }

    public void EditPersonStarted(Person person)
    {
        PersonForm.GetComponent<PersonEditor>().Person = person;
        PersonForm.GetComponent<PersonEditor>().personEditorMode = PersonEditorModes.Update;

        PersonObjectCollection.SetActive(false);
        ChangeNationalityButton.SetActive(false);
        PersonForm.SetActive(true);
    }

    public void CreatePersonStarted()
    {
        PersonForm.GetComponent<PersonEditor>().Person = new Person { LastName = "", FirstName = "" };
        PersonForm.GetComponent<PersonEditor>().personEditorMode = PersonEditorModes.Create;

        PersonObjectCollection.SetActive(false);
        ChangeNationalityButton.SetActive(false);
        PersonForm.SetActive(true);
    }

    public void FormFinished()
    {
        PersonForm.SetActive(false);
        PersonObjectCollection.SetActive(true);
        ChangeNationalityButton.SetActive(true);


        NationalityHasChanged(currentNationalityID);
    }
}

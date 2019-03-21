using HoloToolkit.Unity.Receivers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPeople : MonoBehaviour {

    // Nationality Menu Object
    [SerializeField]
    private GameObject nationalityButtonsCollection;

    // Use this for initialization
    void Awake()
    {
       
    }

    public void NationalityHasChanged(int newNationalityID)
    {
        BroadcastMessage("ChangeToNewNationality", newNationalityID);
    }

    public void GoToChangeNationality()
    {
        gameObject.SetActive(false);

        nationalityButtonsCollection.SetActive(true);
    }
}

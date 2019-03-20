using HoloToolkit.Unity.Receivers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPeople : MonoBehaviour {

    // Nationality Menu Object
    [SerializeField]
    private GameObject nationalityButtonsCollection;

    //// Children Objects
    //[SerializeField]
    //private GameObject collectionContainer;
    //private GenerateCubes generateCubesRefScript;
    //[SerializeField]
    //private GameObject changeNationalityButton;

    // Use this for initialization
    void Awake()
    {
        //if (collectionContainer != null)
        //{
        //    generateCubesRefScript = collectionContainer.GetComponent<GenerateCubes>();
        //}

    }

    public void NationalityHasChanged(int newNationalityID)
    {
        BroadcastMessage("ChangeToNewNationality", newNationalityID);

        //generateCubesRefScript.SetPeople(DataContext.Instance.GetAllPeopleWhereNationality(newNationalityID));
        //generateCubesRefScript.GenerateDataCubes();
    }

    public void GoToChangeNationality()
    {
        gameObject.SetActive(false);

        nationalityButtonsCollection.SetActive(true);
    }
}

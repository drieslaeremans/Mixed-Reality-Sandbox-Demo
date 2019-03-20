using HoloToolkit.Unity.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.Networking;
using System.Linq;

public class GenerateNationalityButtons : MonoBehaviour {

    // Button prefab to be instantiated
    public GameObject button;

	// Use this for initialization
	void Start ()
    {
        if (DataContext.IsInitialized)
        {
            GenerateButtons();

            gameObject.SetActive(true);
            transform.position = new Vector3(0, 0, 2);
        }
    }

    private void GenerateButtons()
    {
        List<Nationality> nationalities = DataContext.Instance.GetNationalities();
        foreach (var nat in nationalities)
        {
            GameObject newButton = Instantiate(button);
            newButton.transform.SetParent(gameObject.transform);
            newButton.GetComponentInChildren<TextMesh>().text = ("(" + nat.Code + ") " + nat.Country);

            string spriteName = nat.Country.Trim().Replace(" ", "_");
            newButton.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Flags/" + spriteName);
            newButton.GetComponent<ButtonIdentifier>().SetIdentifier(nat.ID);

            gameObject.GetComponent<NationalityButtonsReceiver>().interactables.Add(newButton);
        }

        RefreshCollection();
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
        gameObject.SetActive(true);

        ObjectCollection objectCollection = gameObject.GetComponent<ObjectCollection>();
        objectCollection.SurfaceType = SurfaceTypeEnum.Plane;
        objectCollection.OrientType = OrientTypeEnum.FaceFoward;
        objectCollection.Rows = 1;
        objectCollection.CellWidth = 0.12f;
        objectCollection.CellHeight = 0.12f;
        objectCollection.HorizontalMargin = 0;
        objectCollection.VerticalMargin = 0;

        objectCollection.UpdateCollection();
    }

}

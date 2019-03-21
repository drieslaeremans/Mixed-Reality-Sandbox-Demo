using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.Receivers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NationalityButtonsReceiver : InteractionReceiver
{

    public GameObject peopleContainerObject;

    // Use this for initialization
    void Start() { }

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
        gameObject.SetActive(false);
        peopleContainerObject.SetActive(true);

        int nationalityIdentifier = obj.GetComponent<ButtonIdentifier>().GetIdentifier();
        peopleContainerObject.GetComponent<RenderPeople>().NationalityHasChanged(nationalityIdentifier);
    }
}

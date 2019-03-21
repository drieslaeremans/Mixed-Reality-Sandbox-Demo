using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.Receivers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNationalityReceiver : InteractionReceiver
{

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
        gameObject.GetComponent<RenderPeople>().GoToChangeNationality();
    }
}

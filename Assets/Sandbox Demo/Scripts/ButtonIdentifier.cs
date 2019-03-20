using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIdentifier : MonoBehaviour {

    private int identifier;

    public int GetIdentifier()
    {
        return identifier;
    }

    public void SetIdentifier(int value)
    {
        identifier = value;
    }
}

using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButtonController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public SpriteButton spriteButton;

	// Use this for initialization
	void Start () {
        if (spriteButton == null && spriteRenderer == null)
        {
            Debug.Log("Please link the SpriteRenderer and SpriteButton components of this GameObject to the script.");
            DestroyImmediate(gameObject);
        }
	}

    // Function called by BroadcastMessage of parent-container People.
    public void ChangeToNewNationality(int newNationalityID)
    {
        Nationality nationality;

        if((nationality = DataContext.Instance.GetNationality(newNationalityID)) != null)
        {
            string spriteName = nationality.Country.Trim().Replace(" ", "_");
            Sprite sprite = Resources.Load<Sprite>("Flags/" + spriteName);

            SetSpriteRenderer(sprite);
            SetSpriteButton(sprite);
        }
    }

    private void SetSpriteButton(Sprite sprite)
    {
        foreach (SpriteButtonDatum state in spriteButton.ButtonStates)
        {
            state.ButtonSprite = sprite;
        }
    }

    private void SetSpriteRenderer(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}

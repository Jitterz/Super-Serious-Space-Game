using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject myShip;
    private SpriteRenderer mySprite;
    public Sprite[] shipSprites;

	// Use this for initialization
	void Start ()
    {
        mySprite = myShip.GetComponent<SpriteRenderer>();
        GetMyShip();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void GetMyShip()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            mySprite.sprite = shipSprites[0];
        }
        if (PlayerInfoStatic.CurrentShipName == "Tugarak")
        {
            mySprite.sprite = shipSprites[1];
        }
        if (PlayerInfoStatic.CurrentShipName == "Shupe")
        {
            mySprite.sprite = shipSprites[2];
        }
    }
}

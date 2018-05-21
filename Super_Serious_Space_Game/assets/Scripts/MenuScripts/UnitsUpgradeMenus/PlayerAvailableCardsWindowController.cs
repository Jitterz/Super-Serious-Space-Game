using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvailableCardsWindowController : MonoBehaviour {

    public GameObject cardSlot;

	// Use this for initialization
	void Start ()
    {
        PopulatePlayerCardsWindow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PopulatePlayerCardsWindow()
    {
        foreach (GameObject playerCards in PlayerInfoStatic.PlayerUnitCards)
        {
            GameObject newCardSlot = Instantiate(cardSlot, gameObject.transform.position, Quaternion.identity);
            newCardSlot.transform.SetParent(gameObject.transform, false);
            GameObject newPlayerCard = Instantiate(playerCards, newCardSlot.transform.position, Quaternion.identity);
            newPlayerCard.transform.SetParent(newCardSlot.transform, false);
            newPlayerCard.transform.position = newCardSlot.transform.position;
        }
    }
}

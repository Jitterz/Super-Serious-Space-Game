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
            playerCards.transform.SetParent(newCardSlot.transform, false);
            playerCards.transform.position = newCardSlot.transform.position;
            playerCards.SetActive(true);
        }
    }  

    public void BuildPlayerCardsList()
    {
        PlayerInfoStatic.PlayerUnitCards.Clear();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).childCount == 1)
            {                
                PlayerInfoStatic.PlayerUnitCards.Add(gameObject.transform.GetChild(i).transform.GetChild(0).gameObject);
            }
        }

        GameObject playerCardsParent = GameObject.Find("PlayerCardsHolder");
        foreach (GameObject playerCards in PlayerInfoStatic.PlayerUnitCards)
        {
            playerCards.transform.SetParent(playerCardsParent.transform, false);
            playerCards.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPanelController : MonoBehaviour {

    public List<GameObject> cardSlots; 

	// Use this for initialization
	void Start ()
    {
        PopulatePlayerDeckWindow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuildDeckList()
    {
        //remove me
        Debug.Log("remove me");
        if (PlayerInfoStatic.PlayerDeck == null)
        {
            PlayerInfoStatic.PlayerDeck = new List<GameObject>();
        }
        // remove me

        PlayerInfoStatic.PlayerDeck.Clear();
        for (int i = 0; i < cardSlots.Count; i++)
        {
            if(cardSlots[i].transform.childCount == 1)
            {                
                PlayerInfoStatic.PlayerDeck.Add(cardSlots[i].transform.GetChild(0).gameObject);
            }
        }

        GameObject deckParent = GameObject.Find("PlayerDeckHolder");
        foreach (GameObject deckCard in PlayerInfoStatic.PlayerDeck)
        {
            deckCard.transform.SetParent(deckParent.transform, false);
            deckCard.SetActive(false);
        }
    }

    private void PopulatePlayerDeckWindow()
    {
        // remove this        
        if (PlayerInfoStatic.PlayerDeck == null)
        {
            PlayerInfoStatic.PlayerDeck = new List<GameObject>();
        }       
        // remove this

        foreach (GameObject playerCards in PlayerInfoStatic.PlayerDeck)
        {
            for (int i = 0; i < cardSlots.Count; i++)
            {
                if (cardSlots[i].transform.childCount == 0)
                {
                    playerCards.transform.SetParent(cardSlots[i].transform, false);
                    playerCards.transform.position = cardSlots[i].transform.position;
                    playerCards.SetActive(true);
                    break;
                }
            }
        }
    }
}

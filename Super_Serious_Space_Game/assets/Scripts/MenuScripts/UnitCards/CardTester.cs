using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTester : MonoBehaviour {

    public GameObject prefab;
    public GameObject cardSlot;
    public RectTransform content;
    private UnitCardBuilder cardBuild;

	public void CreateTestCard()
    {
        PlayerStatsUpgradesStatic.discoveredUnits = new List<string>();
        PlayerStatsUpgradesStatic.discoveredUnits.Add("Settler");
        cardBuild = GetComponent<UnitCardBuilder>();

        if (PlayerInfoStatic.PlayerUnitCards == null)
        {
            PlayerInfoStatic.PlayerUnitCards = new List<GameObject>();
        }
        PlayerInfoStatic.PlayerUnitCards.Add(cardBuild.BuildCard(PlayerHiddenLevelStatic.playerLevel));

        TestAddingCards();
    }

    public void TestAddingCards()
    {
        foreach (GameObject playerCards in PlayerInfoStatic.PlayerUnitCards)
        {
            GameObject newCardSlot = Instantiate(cardSlot, content.transform.position, Quaternion.identity);
            newCardSlot.transform.SetParent(content.transform, false);
            GameObject newPlayerCard = Instantiate(playerCards, newCardSlot.transform.position, Quaternion.identity);
            newPlayerCard.transform.SetParent(newCardSlot.transform, false);
            newPlayerCard.transform.position = newCardSlot.transform.position;
        }
    }
}

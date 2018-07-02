using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTester : MonoBehaviour {

    public int playerLevel;
    public GameObject prefab;
    public GameObject cardSlot;
    public RectTransform content;
    private UnitCardBuilder cardBuild;

	public void CreateTestCard()
    {
        PlayerStatsUpgradesStatic.discoveredUnits = new List<string>();
        PlayerStatsUpgradesStatic.discoveredUnits.Add("Settler");
        PlayerStatsUpgradesStatic.discoveredUnits.Add("Nix");
        PlayerStatsUpgradesStatic.discoveredUnits.Add("Chomp");
        cardBuild = GetComponent<UnitCardBuilder>();

        if (PlayerInfoStatic.PlayerUnitCards == null)
        {
            PlayerInfoStatic.PlayerUnitCards = new List<GameObject>();
        }

        TestAddingCards();
    }

    public void TestAddingCards()
    {
        PlayerHiddenLevelStatic.playerLevel = playerLevel;
        GameObject newCardSlot = Instantiate(cardSlot, content.transform.position, Quaternion.identity);
        newCardSlot.transform.SetParent(content.transform, false);
        GameObject newPlayerCard = Instantiate(cardBuild.BuildCard(PlayerHiddenLevelStatic.playerLevel), newCardSlot.transform.position, Quaternion.identity);
        newPlayerCard.transform.SetParent(newCardSlot.transform, false);
        newPlayerCard.transform.position = newCardSlot.transform.position;
        playerLevel += 1;
    }
}

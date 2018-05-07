using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTester : MonoBehaviour {

    public GameObject prefab;
    private UnitCardBuilder cardBuild;

	public void CreateTestCard()
    {
        PlayerStatsUpgradesStatic.discoveredUnits = new List<string>();
        PlayerStatsUpgradesStatic.discoveredUnits.Add("Settler");
        cardBuild = GetComponent<UnitCardBuilder>();

        cardBuild.BuildCard(PlayerHiddenLevelStatic.playerLevel);
    }
}

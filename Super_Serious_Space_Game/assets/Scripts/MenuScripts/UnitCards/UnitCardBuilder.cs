using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCardBuilder : MonoBehaviour {

    private GameObject newCard;
    private UnitCard unitCardScript;
    private UnitStats unitStatsScript;

    private int numberOfAffectedStats;

    private List<string> selectedStatTypes;
    private List<string> possibleStatTypes;

    private List<float> minimumStats;
    private List<float> maximumStats;

    private string unitName;

	public GameObject BuildCard(int playerLevel, GameObject cardPrefab)
    {
        newCard = Instantiate(cardPrefab);
        newCard.SetActive(false);
        unitCardScript = newCard.GetComponent<UnitCard>();
        unitStatsScript = newCard.GetComponent<UnitStats>();
       
        BuildLists();

        // get how many stats will be affected on the card
        GetNumberOfAffectedStats(playerLevel);
        // get which stats on the card will be affected
        GetRandomStatTypesToAffect();
        // get which type of unit this card represents
        GetUnitType();
        // Set the current and maximum possible stats for each selected type based on player level
        SetStatAmounts();

        return newCard;
    }

    private void GetUnitType()
    {
        int random = Random.Range(1, PlayerStatsUpgradesStatic.discoveredUnits.Count);

        unitName = PlayerStatsUpgradesStatic.discoveredUnits[random];
    }

    private void SetStatAmounts()
    {
        UnitStatsBuilder statsBuilder = new UnitStatsBuilder();

        for (int i = 0; i < selectedStatTypes.Count; i++)
        {
            statsBuilder.GetUnitTypeAndBuildTheStats(unitName, unitStatsScript, selectedStatTypes[i]);
            statsBuilder.statsModified = true;
        }
    }

    private void GetRandomStatTypesToAffect()
    {
        int random;

        for (int i = 0; i < numberOfAffectedStats - 1; i++)
        {
            random = Random.Range(1, 6);
            selectedStatTypes.Add(possibleStatTypes[random]);
            possibleStatTypes.RemoveAt(random);
        }
    }

    private void GetNumberOfAffectedStats(int playerLevel)
    {
        // if the player is a low level then the card will most likely improve 1 stat and max 2 stats
        if (playerLevel <= 10)
        {
            numberOfAffectedStats = Random.Range(1, 3);
        }
        else if (playerLevel <= 25)
        {
            numberOfAffectedStats = Random.Range(1, 5);
        }
        else if (playerLevel <= 40)
        {
            numberOfAffectedStats = Random.Range(1, 6);
        }
        else if (playerLevel <= 65)
        {
            numberOfAffectedStats = Random.Range(2, 6);
        }
        else
        {
            numberOfAffectedStats = Random.Range(3, 6);
        }
    }

    private void BuildLists()
    {
        selectedStatTypes = new List<string>();        
        minimumStats = new List<float>();
        maximumStats = new List<float>();

        possibleStatTypes = new List<string>();
        possibleStatTypes.Add("Attack");
        possibleStatTypes.Add("Health");
        possibleStatTypes.Add("Attack Speed");
        possibleStatTypes.Add("Move Speed");
        possibleStatTypes.Add("Build Time");
        possibleStatTypes.Add("Resource Cost");
    }
}

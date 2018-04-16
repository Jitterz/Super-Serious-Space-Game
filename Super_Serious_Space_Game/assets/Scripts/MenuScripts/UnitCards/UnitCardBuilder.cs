using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCardBuilder : MonoBehaviour {

    private GameObject newCard;

    private float cardPowerLevel = 0;
    private float powerLevelMultiplier = 5f;
    private int numberOfAffectedStats;
    private List<string> selectedStatTypes;
    private List<string> possibleStatTypes;

    private List<float> minimumStats;
    private List<float> maximumStats;

	public GameObject BuildCard(int playerLevel, GameObject cardPrefab)
    {
        newCard = Instantiate(cardPrefab);
        newCard.SetActive(false);
        UnitCard unitCardScript = newCard.GetComponent<UnitCard>();
        UnitStats unitStatsScript = newCard.GetComponent<UnitStats>();
       
        BuildLists();

        // get how many stats will be affected on the card
        GetNumberOfAffectedStats(playerLevel);
        // get which stats on the card will be affected
        GetRandomStatTypesToAffect();
        // Set the minimum and maximum possible stats for each selected type based on player level

        return newCard;
    }

    private void SetMinimumAndMaximumStatAmounts(int playerLevel)
    {
        
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
            cardPowerLevel += numberOfAffectedStats * powerLevelMultiplier;
        }
        else if (playerLevel <= 25)
        {
            numberOfAffectedStats = Random.Range(1, 5);
            cardPowerLevel += numberOfAffectedStats * powerLevelMultiplier;
        }
        else if (playerLevel <= 40)
        {
            numberOfAffectedStats = Random.Range(1, 6);
            cardPowerLevel += numberOfAffectedStats * powerLevelMultiplier;
        }
        else if (playerLevel <= 65)
        {
            numberOfAffectedStats = Random.Range(2, 6);
            cardPowerLevel += numberOfAffectedStats * powerLevelMultiplier;
        }
        else
        {
            numberOfAffectedStats = Random.Range(3, 6);
            cardPowerLevel += numberOfAffectedStats * powerLevelMultiplier;
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

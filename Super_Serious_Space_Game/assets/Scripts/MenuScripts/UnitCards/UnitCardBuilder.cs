using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCardBuilder : MonoBehaviour {

    public GameObject cardPrefab;

    private GameObject newCard;
    private UnitCard unitCardScript;
    private UnitStats unitStatsScript;

    private int numberOfAffectedStats;

    private List<string> selectedStatTypes;
    private List<string> possibleStatTypes;

    private string unitName;

	public GameObject BuildCard(int playerLevel)
    {
        newCard = Instantiate(cardPrefab);
        //newCard.SetActive(false);
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
        // build the card visuals
        CreateCardVisuals();
        // get the credits value of the card
        GetCardCreditsValue();

        return newCard;
    }

    public GameObject BuildCardAI(string unitType, int aiLevel)
    {
        unitName = unitType;
        newCard = Instantiate(cardPrefab);
        //newCard.SetActive(false);
        unitCardScript = newCard.GetComponent<UnitCard>();
        unitStatsScript = newCard.GetComponent<UnitStats>();

        BuildLists();

        // get how many stats will be affected on the card
        GetNumberOfAffectedStats(aiLevel);
        // get which stats on the card will be affected
        GetRandomStatTypesToAffect();
        // Set the current and maximum possible stats for each selected type based on player level
        SetStatAmounts();
        // build the card visuals
        CreateCardVisuals();      

        return newCard;
    }

    private void GetCardCreditsValue()
    {
        unitStatsScript.cardCreditsValue = (int)unitStatsScript.unitPowerLevel;
        unitCardScript.cardCreditsValue.text = unitStatsScript.cardCreditsValue.ToString();
    }

    private void CreateCardVisuals()
    {
        // determine the card background
        if (unitStatsScript.unitPowerLevel <= 25)
        {
            unitCardScript.cardBackground.sprite = unitCardScript.cardBackgrounds[0];
        }
        else if (unitStatsScript.unitPowerLevel <= 58)
        {
            unitCardScript.cardBackground.sprite = unitCardScript.cardBackgrounds[1];
        }
        else if (unitStatsScript.unitPowerLevel <= 99)
        {
            unitCardScript.cardBackground.sprite = unitCardScript.cardBackgrounds[2];
        }
        else if (unitStatsScript.unitPowerLevel <= 155)
        {
            unitCardScript.cardBackground.sprite = unitCardScript.cardBackgrounds[3];
        }
        else
        {
            unitCardScript.cardBackground.sprite = unitCardScript.cardBackgrounds[4];
        }
        //determine the resource image
        for (int i = 0; i < unitCardScript.resourceTypes.Count - 1; i++)
        {
            if (unitStatsScript.unitResourceType == unitCardScript.resourceTypes[i])
            {
                unitCardScript.resourceImage.sprite = unitCardScript.resourceSprites[i];
                break;
            }
        }
        // get the unit image for the card
        for (int i = 0; i < unitCardScript.unitTypes.Count; i++)
        {
            if (unitStatsScript.unitName == unitCardScript.unitTypes[i])
            {
                unitCardScript.unitImage.sprite = unitCardScript.unitImages[i];
            }
        }

        unitCardScript.unitName.text = unitStatsScript.unitName;
        unitCardScript.unitCapacity.text = unitStatsScript.unitCapacity.ToString();
        unitCardScript.resourceCost.text = unitStatsScript.unitCost.ToString();
        unitCardScript.cardLevel.text = unitStatsScript.unitPowerLevel.ToString();
    }

    private void GetUnitType()
    {
        //REMOVE ME
        Debug.Log("Remove list initialization");
        if (PlayerStatsUpgradesStatic.discoveredUnits == null)
        {
            PlayerStatsUpgradesStatic.discoveredUnits = new List<string>();
            PlayerStatsUpgradesStatic.discoveredUnits.Add("Settler");
        }
        //REMOVE ME

        int random = Random.Range(0, PlayerStatsUpgradesStatic.discoveredUnits.Count);

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

        for (int i = 0; i < numberOfAffectedStats; i++)
        {
            random = Random.Range(0, possibleStatTypes.Count);
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

        possibleStatTypes = new List<string>();
        possibleStatTypes.Add("Attack");
        possibleStatTypes.Add("Health");
        possibleStatTypes.Add("Attack Speed");
        possibleStatTypes.Add("Move Speed");
        possibleStatTypes.Add("Build Time");
        possibleStatTypes.Add("Resource Cost");
    }
}

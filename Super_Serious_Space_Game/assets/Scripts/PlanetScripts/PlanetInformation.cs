using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInformation : MonoBehaviour {

    public string planetName;
    public string type;
    public string uiType;
    public string difficulty;
    public string uiDifficulty;
    public string negativeEffect;
    public string revealInformationCase = "Scan00";

    public Sprite currentSprite;
    public Sprite planetSprite;
    public Sprite planetConqueredSprite;
    public Sprite planetLostSprite;
    public Sprite unknownPlanetSprite;
    public Sprite unknownPlanetScanSprite;

    public GameObject planetAI;
    
    public List<string> resources;
    public List<string> uiResources;

    public int fuelRewardAmount;
    public string uiFuelRewardAmount;
    public int xPRewardAmount;
    public string uixPRewardAmount;
    public int creditRewardAmount;
    public string uiCreditRewardAmount;

    public float fuelCostToPlanet;
    public string uiFuelCostToPlanet;

    public bool planetComplete;
    public bool isScanned = false;
    public bool planetProximityScan = false;

    private SpaceUIManager spaceUI;
    private GameObject conqueredLostSpriteHolder;
    private SpriteRenderer mySprite;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        conqueredLostSpriteHolder = transform.GetChild(48).gameObject;
        CalculateFuelReward();
        CalculateXPReward();
        CalculateCreditReward();
    }

    private void Update()
    {
        // if a planet was attacked and it is this planet
        if (SavedPlanetForBattleStatic.wasAttacked == true && SavedPlanetForBattleStatic.thePlanet == gameObject)
        {
            SavedPlanetForBattleStatic.wasAttacked = false;
            SpriteRenderer conqueredLostSpriteRenderer = conqueredLostSpriteHolder.GetComponent<SpriteRenderer>();

            if (SavedPlanetForBattleStatic.isConquered == true)
            {
                planetComplete = true;
                spaceUI = GameObject.Find("SpaceUIManager").transform.GetChild(0).GetComponent<SpaceUIManager>();
                conqueredLostSpriteRenderer.sprite = planetConqueredSprite;
                conqueredLostSpriteRenderer.enabled = true;
                spaceUI.DisplayAwardsSplash();
            }
            else
            {
                planetComplete = true;
                conqueredLostSpriteRenderer.sprite = planetLostSprite;
                conqueredLostSpriteRenderer.enabled = true;              
            }
        }       

        if (planetProximityScan || isScanned)
        {
            mySprite.sprite = planetSprite;
        }
    }

    public int CalculateFuelReward()
    {
        // need to calculate based on the planet difficulty, planet ai, ai cards, ai buffs ect
        if (difficulty == "Very Easy")
        {
            fuelRewardAmount = Random.Range(5, 12);
        }
        else if (difficulty == "Easy")
        {
            fuelRewardAmount = Random.Range(7, 15);
        }
        else if (difficulty == "Medium")
        {
            fuelRewardAmount = Random.Range(9, 22);
        }
        else if (difficulty == "Hard")
        {
            fuelRewardAmount = Random.Range(11, 28);
        }
        else if (difficulty == "Very Hard")
        {
            fuelRewardAmount = Random.Range(13, 34);
        }
        else
        {
            fuelRewardAmount = 1;
        }
        return fuelRewardAmount;
    }

    public int CalculateXPReward()
    {
        if (difficulty == "Very Easy")
        {
            xPRewardAmount = Random.Range(50, 120);
        }
        else if (difficulty == "Easy")
        {
            xPRewardAmount = Random.Range(70, 150);
        }
        else if (difficulty == "Medium")
        {
            xPRewardAmount = Random.Range(90, 220);
        }
        else if (difficulty == "Hard")
        {
            xPRewardAmount = Random.Range(110, 280);
        }
        else if (difficulty == "Very Hard")
        {
            xPRewardAmount = Random.Range(130, 340);
        }
        else
        {
            xPRewardAmount = 1;
        }
        return xPRewardAmount;
    }

    public int CalculateCreditReward()
    {
        if (difficulty == "Very Easy")
        {
            creditRewardAmount = Random.Range(10, 50);
        }
        else if (difficulty == "Easy")
        {
            creditRewardAmount = Random.Range(21, 82);
        }
        else if (difficulty == "Medium")
        {
            creditRewardAmount = Random.Range(30, 120);
        }
        else if (difficulty == "Hard")
        {
            creditRewardAmount = Random.Range(35, 155);
        }
        else if (difficulty == "Very Hard")
        {
            creditRewardAmount = Random.Range(43, 211);
        }
        else
        {
            creditRewardAmount = 1;
        }
        return creditRewardAmount;
    }

    public void PlanetSpriteStateMachine()
    {
        switch (revealInformationCase)
        {
            case "Scan00":
                // default state nothing is known about the planet
                mySprite.sprite = unknownPlanetSprite;
                uiType = "? ? ? ?";
                uiResources.Clear();
                uiResources.Add("UnknownResource");
                uiResources.Add("UnknownResource");
                uiResources.Add("UnknownResource");
                uiResources.Add("UnknownResource");
                uiDifficulty = "? ? ? ? ?";
                uiFuelCostToPlanet = "? ? ? ? ?";
                uiFuelRewardAmount = "??";
                uixPRewardAmount = "??";
                uiCreditRewardAmount = "??";
                break;
            case "Scan01":
                // just a proximity scan. ship is close to planet get basic information
                // unlock the planets actual sprite
                mySprite.sprite = planetSprite;
                uiType = type;
                // reveal only the first two resources
                uiResources.Clear();
                uiResources.Add(resources[0]);
                uiResources.Add(resources[1]);
                uiResources.Add("UnknownResource");
                uiResources.Add("UnknownResource");
                // change the other planet information to unknown
                uiDifficulty = "? ? ? ? ?";
                uiFuelCostToPlanet = "? ? ? ? ?";
                uiFuelRewardAmount = "??";
                uixPRewardAmount = "??";
                uiCreditRewardAmount = "??";
                break;
            case "Scan02":
                // upgraded scanner reveal all resources
                mySprite.sprite = planetSprite;
                uiType = type;
                uiResources.Clear();
                uiResources.Add(resources[0]);
                uiResources.Add(resources[1]);
                uiResources.Add(resources[2]);
                uiResources.Add(resources[3]);
                uiDifficulty = "? ? ? ? ?";
                uiFuelCostToPlanet = "? ? ? ? ?";
                uiFuelRewardAmount = "??";
                uixPRewardAmount = "??";
                uiCreditRewardAmount = "??";
                break;
            case "Scan03":
                // upgraded more also reveal rewards
                mySprite.sprite = planetSprite;
                uiType = type;
                uiResources.Clear();
                uiResources.Add(resources[0]);
                uiResources.Add(resources[1]);
                uiResources.Add(resources[2]);
                uiResources.Add(resources[3]);
                uiDifficulty = "? ? ? ? ?";
                uiFuelCostToPlanet = "? ? ? ? ?";
                uiFuelRewardAmount = fuelRewardAmount.ToString();
                uixPRewardAmount = xPRewardAmount.ToString();
                uiCreditRewardAmount = creditRewardAmount.ToString();
                break;
            case "Scan04":
                // reveal difficulty
                mySprite.sprite = planetSprite;
                uiType = type;
                uiResources.Clear();
                uiResources.Add(resources[0]);
                uiResources.Add(resources[1]);
                uiResources.Add(resources[2]);
                uiResources.Add(resources[3]);
                uiDifficulty = difficulty;
                uiFuelCostToPlanet = "? ? ? ? ?";
                uiFuelRewardAmount = fuelRewardAmount.ToString();
                uixPRewardAmount = xPRewardAmount.ToString();
                uiCreditRewardAmount = creditRewardAmount.ToString();
                break;
            case "Scan05":
                // reveal fuel cost to travel to the planet
                mySprite.sprite = planetSprite;
                uiType = type;
                uiResources.Clear();
                uiResources.Add(resources[0]);
                uiResources.Add(resources[1]);
                uiResources.Add(resources[2]);
                uiResources.Add(resources[3]);
                uiDifficulty = difficulty;
                uiFuelCostToPlanet = fuelCostToPlanet.ToString();
                uiFuelRewardAmount = fuelRewardAmount.ToString();
                uixPRewardAmount = xPRewardAmount.ToString();
                uiCreditRewardAmount = creditRewardAmount.ToString();
                break;
        }
    }

}

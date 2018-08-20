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

    public int planetPowerLevel;
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
        CalculateRewards();
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
    }

    private void CalculateRewards()
    {
        // need to calculate based on the planet difficulty, planet ai, ai cards, ai buffs ect
        if (planetPowerLevel <= 15)
        {
            fuelRewardAmount = Random.Range(2, 6);
            xPRewardAmount = Random.Range(15, 35);
            creditRewardAmount = Random.Range(3, 10);
        }
        else if (planetPowerLevel <= 30)
        {
            fuelRewardAmount = Random.Range(3, 10);
            xPRewardAmount = Random.Range(20, 40);
            creditRewardAmount = Random.Range(5, 12);
        }
        else if (planetPowerLevel <= 50)
        {
            fuelRewardAmount = Random.Range(4, 15);
            xPRewardAmount = Random.Range(23, 39);
            creditRewardAmount = Random.Range(5, 15);
        }
        else if (planetPowerLevel <= 75)
        {
            fuelRewardAmount = Random.Range(6, 23);
            xPRewardAmount = Random.Range(31, 44);
            creditRewardAmount = Random.Range(6, 20);
        }
        else if (planetPowerLevel <= 100)
        {
            fuelRewardAmount = Random.Range(8, 26);
            xPRewardAmount = Random.Range(37, 55);
            creditRewardAmount = Random.Range(7, 27);
        }
        else if (planetPowerLevel <= 150)
        {
            fuelRewardAmount = Random.Range(9, 34);
            xPRewardAmount = Random.Range(40, 57);
            creditRewardAmount = Random.Range(9, 33);
        }
        else
        {
            fuelRewardAmount = Random.Range(10, 37);
            xPRewardAmount = Random.Range(47, 62);
            creditRewardAmount = Random.Range(10, 39);
        }
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

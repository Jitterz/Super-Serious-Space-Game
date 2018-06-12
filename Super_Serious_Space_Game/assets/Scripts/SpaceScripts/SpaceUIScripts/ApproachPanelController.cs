using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApproachPanelController : MonoBehaviour {

    public GameObject playerShip;
    public GameObject selectedPlanet;
    public Text planetType;
    public Text planetNegativeEffect;
    public Image planetImageSprite;
    public Text planetDifficulty;
    public Text planetName;
    public Text fuelTravelCost;
    public GameObject aiSaver;

    public Image[] resourceImages;
    public Sprite[] resourceSprites;
    public Text fuelRewardText;
    public Text xpRewardText;
    public Text creditsRewardText;
    public Text attackButtonText;

    private ShipController shipController;
    private Button attackButton;
    private LevelManager levelManager;

    // Use this for initialization
    void Start ()
    {
        shipController = playerShip.GetComponent<ShipController>();
        levelManager = new LevelManager();
    }

    private void Awake()
    {
        attackButton = attackButtonText.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void PopulateAttackPanel(GameObject clickedPlanet)
    {
        // temp testing distance
        float distance = Vector3.Distance(clickedPlanet.transform.position, playerShip.transform.position);
        // end temp testing

        // need to redo all of this for the scanner
        selectedPlanet = clickedPlanet;
        PlanetInformation planetInfo = clickedPlanet.GetComponent<PlanetInformation>();        
        planetNegativeEffect.text = "Planet Effect: " + "<color=#ff0000ff>" + planetInfo.negativeEffect + "</color>";

        // switch statement moved to the actual planet the ui will get all of the planet info from the planet itself
        if (ShipCloseToPlanet(clickedPlanet))
        {
            if (!planetInfo.isScanned)
            {
                planetInfo.revealInformationCase = "Scan01";
                planetInfo.planetProximityScan = true;
                planetInfo.PlanetSpriteStateMachine();
            }       
        }
        if (!ShipCloseToPlanet(clickedPlanet) && !planetInfo.isScanned)
        {
            planetInfo.revealInformationCase = "Scan00";
            planetInfo.PlanetSpriteStateMachine();           
        }
        if (!ShipCloseToPlanet(clickedPlanet) && planetInfo.planetProximityScan)
        {
            planetInfo.revealInformationCase = "Scan01";
            planetInfo.PlanetSpriteStateMachine();
        }
        // if the planet is scanned then the state machine is already set so reveal the information
        if (planetInfo.isScanned)
        {
            planetInfo.PlanetSpriteStateMachine();
        }

        planetImageSprite.sprite = planetInfo.GetComponent<SpriteRenderer>().sprite;
        planetType.text = "Planet Type: " + planetInfo.uiType;
        planetDifficulty.text = "Planet Difficulty: " + planetInfo.uiDifficulty;
        planetName.text = planetInfo.planetName;
        fuelTravelCost.text = "Fuel Cost to Planet: " +  planetInfo.uiFuelCostToPlanet;
        GetResourceImages(planetInfo);
        fuelRewardText.text = planetInfo.uiFuelRewardAmount;
        xpRewardText.text = planetInfo.uixPRewardAmount;
        creditsRewardText.text = planetInfo.uiCreditRewardAmount;

        if (ShipCloseToPlanet(clickedPlanet))
        {
            attackButton.enabled = true;
            attackButtonText.text = "Attack Planet";
            attackButtonText.color = Color.white;
        }
        else
        {
            attackButton.enabled = false;
            attackButtonText.text = "(Planet too far to attack)";
            attackButtonText.color = Color.gray;
        }
    }

    public void AttackPlanetClicked()
    {
        PlanetInformation selectedPlanetInfo = selectedPlanet.GetComponent<PlanetInformation>();
        SavedPlanetForBattleStatic.thePlanet = selectedPlanet;
        SavedPlanetForBattleStatic.resources = selectedPlanetInfo.resources;
        SavedPlanetForBattleStatic.type = selectedPlanetInfo.type;
        SavedPlanetForBattleStatic.fuelReward = selectedPlanetInfo.fuelRewardAmount;
        SavedPlanetForBattleStatic.xPReward = selectedPlanetInfo.xPRewardAmount;
        SavedPlanetForBattleStatic.creditReward = selectedPlanetInfo.creditRewardAmount;
        selectedPlanetInfo.planetAI.transform.SetParent(aiSaver.transform);
        DontDestroyOnLoad(aiSaver);

        levelManager.LoadLevel("03a_Battle");
        gameObject.SetActive(false);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private void GetResourceImages(PlanetInformation planetInfo)
    {
        // need to code this for each resource type just return gold for now
        for (int i = 0; i < planetInfo.resources.Count; i++)
        {
            if (planetInfo.uiResources[i] == "UnknownResource")
            {
                resourceImages[i].sprite = resourceSprites[0];
            }
            else if (planetInfo.uiResources[i] == "Gold")
            {
                resourceImages[i].sprite = resourceSprites[1];
            }
            else if (planetInfo.uiResources[i] == "Iron")
            {
                resourceImages[i].sprite = resourceSprites[2];
            }
            else if (planetInfo.uiResources[i] == "Copper")
            {
                resourceImages[i].sprite = resourceSprites[3];
            }
            else if (planetInfo.uiResources[i] == "Nickel")
            {
                resourceImages[i].sprite = resourceSprites[4];
            }
            else if (planetInfo.uiResources[i] == "Silver")
            {
                resourceImages[i].sprite = resourceSprites[5];
            }
            else if (planetInfo.uiResources[i] == "Cobalt")
            {
                resourceImages[i].sprite = resourceSprites[6];
            }
            else if (planetInfo.uiResources[i] == "Cadmium")
            {
                resourceImages[i].sprite = resourceSprites[7];
            }
            else if (planetInfo.uiResources[i] == "Iridium")
            {
                resourceImages[i].sprite = resourceSprites[8];
            }
            else if (planetInfo.uiResources[i] == "Paladium")
            {
                resourceImages[i].sprite = resourceSprites[9];
            }
        }
    }

    private bool ShipCloseToPlanet(GameObject planet)
    {
        float currentDistance = Vector3.Distance(planet.transform.position, playerShip.transform.position);
        float desiredDistance = 3f;

        if (currentDistance <= desiredDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour {

    public GameObject myUnit;
    public GameObject myUnitCard;
    public GameObject playerBattleManager;
    public Image cooldownImage;
    public Text myCostText;
    public int myButtonNumber;

    private GameObject mySpawnableUnit;
    private PlayerBattleManager playerBattleManagerScript;
    private UnitStats myStats;
    private Button myButton;
    private int playerResourceAmountMyResource;
    private float startBuilTime;
    private bool isOnCooldown;
    private int myUnitCost;
    private int myBuildTime;

	// Use this for initialization
	void Start ()
    {
        myStats = myUnitCard.GetComponent<UnitStats>();
        myButton = gameObject.GetComponent<Button>();
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();

        // need to set all of my variables based on any upgrades the unit might have
        myUnitCost = myStats.unitCost;
        myBuildTime = myStats.unitBuildTime;

        InstantiateMyUnit();

        myCostText.text = myUnitCost.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerResourceAmountMyResource();

        DisableOrEnableButton();       
    }

    private void InstantiateMyUnit()
    {
        mySpawnableUnit = Instantiate(myUnit);
        mySpawnableUnit.SetActive(false);
        mySpawnableUnit.name = "SpawnableUnit " + myButtonNumber.ToString();
        UnitStats myOldStats = mySpawnableUnit.GetComponent<UnitStats>();
        myOldStats.health = myStats.health;
        myOldStats.unitCost = myStats.unitCost;
        myOldStats.unitDamage = myStats.unitDamage;
        myOldStats.unitBuildTime = myStats.unitBuildTime;
        myOldStats.unitCapacity = myStats.unitCapacity;
        myOldStats.unitMoveSpeed = myStats.unitMoveSpeed;
        myOldStats.unitAttackSpeed = myStats.unitAttackSpeed;
    }

    public void SpawnUnit()
    {
        if (playerResourceAmountMyResource >= myUnitCost)
        {       
            playerBattleManagerScript.SpawnPlayerUnit(mySpawnableUnit, myBuildTime, myUnitCost);
            playerBattleManagerScript.spawnedUnitsCapacityCount++;
        }
    }

    private void DisableOrEnableButton()
    {      

        if (playerResourceAmountMyResource >= myUnitCost && playerBattleManagerScript.spawnPodCount >= 1 && playerBattleManagerScript.spawnedUnitsCapacityCount < ShipStatsUpgradesStatic.GetShipUnitCapacity())
        {
            myButton.interactable = true;
        }
        else
        {
            myButton.interactable = false;
        }
    }

    private void UpdatePlayerResourceAmountMyResource()
    {
        if (myStats.unitResourceType == "Gold")
        {
            playerResourceAmountMyResource = playerBattleManagerScript.playerResourcesAmount[0];
        }
        else if (myStats.unitResourceType == "Iron")
        {
            playerResourceAmountMyResource = playerBattleManagerScript.playerResourcesAmount[1];
        }
        else if (myStats.unitResourceType == "Copper")
        {
            playerResourceAmountMyResource = playerBattleManagerScript.playerResourcesAmount[2];
        }
    }
}

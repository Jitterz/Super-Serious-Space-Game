using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerButton : MonoBehaviour {

    public GameObject myUnit;
    public GameObject playerBattleManager;
    public Image cooldownImage;
    public Text myCostText;

    private PlayerBattleManager playerBattleManagerScript;
    private UnitStats myStats;
    private Button myButton;
    private int playerResourceAmountMyResource;
    private float startBuilTime;
    private bool isOnCooldown;
    private int myUnitCost;
    private float myBuildTime;
    private int playerUnitMaxCapacity;

    // Use this for initialization
    void Start()
    {
        myStats = myUnit.GetComponent<UnitStats>();
        myButton = gameObject.GetComponent<Button>();
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();

        // need to set all of my variables based on any upgrades the unit might have
        myUnitCost = myStats.unitCost - MinersStatsUpgradesStatic.pokoMinerResourceUpgrade;
        myBuildTime = myStats.unitBuildTime - MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade;

        myCostText.text = myUnitCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerResourceAmountMyResource();

        DisableOrEnableButton();
    }

    public void SpawnUnit()
    {
        if (playerResourceAmountMyResource >= myUnitCost)
        {
            playerBattleManagerScript.SpawnPlayerUnit(myUnit, myBuildTime, myUnitCost);
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

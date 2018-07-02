using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerButton : MonoBehaviour {

    public GameObject myUnit;
    public GameObject playerBattleManager;
    public Image cooldownImage;
    public Text myCostText;

    private RetrieveUnitUpgrades retrieveUnitUpgrades;
    private PlayerBattleManager playerBattleManagerScript;
    private UnitStats myStats;
    private Button myButton;
    private int playerResourceAmountMyResource;
    private float startBuilTime;
    private bool isOnCooldown;
    private int myUnitCost;
    private int myBuildTime;

    // Use this for initialization
    void Start()
    {
        retrieveUnitUpgrades = new RetrieveUnitUpgrades();
        myStats = myUnit.GetComponent<UnitStats>();
        myButton = gameObject.GetComponent<Button>();
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();

        // need to set all of my variables based on any upgrades the unit might have
        myUnitCost = myStats.unitCost - retrieveUnitUpgrades.GetUnitResourceDiscount(myStats.unitName);
        myBuildTime = myStats.unitBuildTime - retrieveUnitUpgrades.GetUnitSpawnTimeDiscount(myStats.unitName);

        myCostText.text = myUnitCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerResourceAmountMyResource();

        DisableOrEnableButton();

        if (isOnCooldown)
        {
            if (AnimateButtonBuildTime())
            {
                myButton.interactable = true;
                isOnCooldown = false;
                cooldownImage.fillAmount = 0;
            }
        }
    }

    public void SpawnUnit()
    {
        if (playerResourceAmountMyResource >= myUnitCost)
        {
            startBuilTime = 0;
            cooldownImage.fillAmount = 1;
            isOnCooldown = true;
            playerBattleManagerScript.SpawnPlayerUnit(myUnit, myBuildTime, myUnitCost);
            myButton.interactable = false;
        }
    }

    private bool AnimateButtonBuildTime()
    {
        startBuilTime += Time.deltaTime;
        if (startBuilTime >= myBuildTime)
        {
            return true;
        }
        else
        {
            cooldownImage.fillAmount -= Time.deltaTime / myBuildTime;
            return false;
        }
    }

    private void DisableOrEnableButton()
    {
        if (playerResourceAmountMyResource >= myUnitCost && playerBattleManagerScript.spawnPodCount >= 1 && playerBattleManagerScript.spawnedUnitsCapacityCount < PlayerStatsUpgradesStatic.unitMaxCapacity)
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

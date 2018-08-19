using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPodButton : MonoBehaviour {

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
        myUnitCost = (myStats.unitCost - SpawnerStatsUpgradesStatic.spawnPodCostUpgrade);
        myBuildTime = (myStats.unitBuildTime - SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgrade);

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

    // need to change this for the spawn pod
    // find the next open spawning location
    // then start the spawning animation
    public void SpawnUnit()
    {
        if (playerResourceAmountMyResource >= myUnitCost && playerBattleManagerScript.playerSpawnPodLocations.Count != 0)
        {
            Vector3 spawnLocation = new Vector3(0,0,0);
            startBuilTime = 0;
            cooldownImage.fillAmount = 1;
            isOnCooldown = true;
            spawnLocation = playerBattleManagerScript.playerSpawnPodLocations[0].transform.position;
            GameObject newSpawnPod = Instantiate(myUnit, spawnLocation, Quaternion.identity);           
            newSpawnPod.name = "PlayerSpawnPod";
            playerResourceAmountMyResource -= myUnitCost;
            myButton.interactable = false;
            playerBattleManagerScript.playerSpawnPodLocations.RemoveAt(0);
            newSpawnPod.GetComponent<SpawnPod>().isNewSpawnPod = true;
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
        //SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgrade + 1 is because the player already starts with 1 spawn pod
        if (playerResourceAmountMyResource >= myUnitCost  && playerBattleManagerScript.activeSpawnPodScripts.Count < SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgrade + 1 && !isOnCooldown)
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

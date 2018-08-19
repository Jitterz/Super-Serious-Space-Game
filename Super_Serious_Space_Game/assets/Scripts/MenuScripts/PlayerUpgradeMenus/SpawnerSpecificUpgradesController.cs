using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerSpecificUpgradesController : MonoBehaviour {

    public Image upgradeBar;
    public GameObject myPanel;
    public Text myCreditsCost;
    public Text myValue;

    private float upgradeCostIncreaseMultiplier = 0.256f;
    private ShowHidePlayerUpgrades upgradeCostControl;
    private string myName;

    // Use this for initialization
    void Start()
    {
        myName = myPanel.gameObject.name;
        upgradeCostControl = GetComponent<ShowHidePlayerUpgrades>();
        GetMyUpgradeCostAndUpdatePanel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitUpgrade()
    {
        if (PlayerInfoStatic.SelectedSpawner == "SpawnPod")
        {
            if (myName == "SpawnPodMaxSpawnedUpgradePanel")
            {
                SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgrade += 1;
                PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.spawnPodMaxSpawnedUpgradeCost += (int)(StoredUpgradeCostsStatic.spawnPodMaxSpawnedUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgrade, SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgradeMax);
            }
            else if (myName == "SpawnPodBuildTimeUpgradePanel")
            {
                SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgrade += 1;
                PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.spawnPodBuildTimeUpgradeCost += (int)(StoredUpgradeCostsStatic.spawnPodBuildTimeUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgrade, SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgradeMax);
            }
            else if (myName == "SpawnPodCostUpgradePanel")
            {
                SpawnerStatsUpgradesStatic.spawnPodCostUpgrade += 5;
                PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.spawnPodCostUpgradeCost += (int)(StoredUpgradeCostsStatic.spawnPodCostUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodCostUpgrade, SpawnerStatsUpgradesStatic.spawnPodCostUpgradeMax);
            }
            else if (myName == "SpawnPodUnitBuildSpeedUpgradePanel")
            {
                SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgrade += 0.2f;
                PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.spawnPodUnitBuildSpeedUpgradeCost += (int)(StoredUpgradeCostsStatic.spawnPodUnitBuildSpeedUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgrade, SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgradeMax);
            }
        }

        GetMyUpgradeCostAndUpdatePanel();
    }

    private void CheckIfStatIsMaxed(int currentStat, int statMax)
    {
        if (currentStat >= statMax)
        {
            currentStat = statMax;
            upgradeCostControl.upgradeMaxed = true;
        }
    }

    private void CheckIfStatIsMaxed(float currentStat, float statMax)
    {
        if (currentStat >= statMax)
        {
            currentStat = statMax;
            upgradeCostControl.upgradeMaxed = true;
        }
    }

    private void GetMyUpgradeCostAndUpdatePanel()
    {
        if (PlayerInfoStatic.SelectedSpawner == "SpawnPod")
        {
            if (myName == "SpawnPodMaxSpawnedUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.spawnPodMaxSpawnedUpgradeCost;
                myValue.text = SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgrade.ToString();
                myCreditsCost.text = StoredUpgradeCostsStatic.spawnPodMaxSpawnedUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgrade / (float)SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgradeMax);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgrade, SpawnerStatsUpgradesStatic.spawnPodMaxSpawnedUpgradeMax);
            }
            else if (myName == "SpawnPodBuildTimeUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.spawnPodBuildTimeUpgradeCost;
                myValue.text = SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgrade.ToString();
                myCreditsCost.text = StoredUpgradeCostsStatic.spawnPodBuildTimeUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgrade / (float)SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgradeMax);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgrade, SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgradeMax);
            }
            else if (myName == "SpawnPodCostUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.spawnPodCostUpgradeCost;
                myValue.text = SpawnerStatsUpgradesStatic.spawnPodCostUpgrade.ToString();
                myCreditsCost.text = StoredUpgradeCostsStatic.spawnPodCostUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)SpawnerStatsUpgradesStatic.spawnPodCostUpgrade / (float)SpawnerStatsUpgradesStatic.spawnPodCostUpgradeMax);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodCostUpgrade, SpawnerStatsUpgradesStatic.spawnPodCostUpgradeMax);
            }
            else if (myName == "SpawnPodUnitBuildSpeedUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.spawnPodUnitBuildSpeedUpgradeCost;
                myValue.text = SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgrade.ToString();
                myCreditsCost.text = StoredUpgradeCostsStatic.spawnPodUnitBuildSpeedUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgrade / (float)SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgradeMax);
                CheckIfStatIsMaxed(SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgrade, SpawnerStatsUpgradesStatic.spawnPodUnitBuildSpeedUpgradeMax);
            }
        }
    }
}

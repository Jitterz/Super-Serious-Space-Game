using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinerSpecificUpgradesController : MonoBehaviour {

    public Image upgradeBar;
    public GameObject myPanel;
    public Text myXPCost;
    public Text myValue;

    private float upgradeCostIncreaseMultiplier = 0.026f;
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
        if (PlayerInfoStatic.SelectedMiner == "PokoMiner")
        {
            if (myName == "HealthUpgradePanel")
            {
                MinersStatsUpgradesStatic.pokoMinerHealthUpgrade += 10;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerHealthUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerHealthUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerHealthUpgrade, MinersStatsUpgradesStatic.pokoMinerHealthUpgradeMax);
            }
            else if (myName == "MiningGainUpgradePanel")
            {
                MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade += 5;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerResourceMiningGainUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerResourceMiningGainUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade, MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgradeMax);
            }
            else if (myName == "ResourceCostUpgradePanel")
            {
                MinersStatsUpgradesStatic.pokoMinerResourceUpgrade += 5;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerResourceUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerResourceUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerResourceUpgrade, MinersStatsUpgradesStatic.pokoMinerResourceUpgradeMax);
            }
            else if (myName == "BuildTimeUpgradePanel")
            {
                MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade += 0.2f;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerSpawnTimeUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerSpawnTimeUpgradeCost * upgradeCostIncreaseMultiplier); ;
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade, MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgradeMax);
            }
            else if (myName == "MoveSpeedUpgradePanel")
            {
                MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade += 2;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerMoveSpeedUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerMoveSpeedUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade, MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgradeMax);
            }            
        }

        GetMyUpgradeCostAndUpdatePanel();
    }

    private void CheckIfStatIsMaxed(float currentStat, float statMax)
    {
        if (currentStat >= statMax)
        {
            currentStat = statMax;
            upgradeCostControl.upgradeMaxed = true;
        }
    }

    private void CheckIfStatIsMaxed(int currentStat, int statMax)
    {
        if (currentStat >= statMax)
        {
            currentStat = statMax;
            upgradeCostControl.upgradeMaxed = true;
        }
    }

    private void GetMyUpgradeCostAndUpdatePanel()
    {
        if (PlayerInfoStatic.SelectedMiner == "PokoMiner")
        {
            if (myName == "HealthUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerHealthUpgradeCost;
                myValue.text = MinersStatsUpgradesStatic.pokoMinerHealthUpgrade.ToString();
                myXPCost.text = StoredUpgradeCostsStatic.pokoMinerHealthUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)MinersStatsUpgradesStatic.pokoMinerHealthUpgrade / (float)MinersStatsUpgradesStatic.pokoMinerHealthUpgradeMax);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerHealthUpgrade, MinersStatsUpgradesStatic.pokoMinerHealthUpgradeMax);
            }
            else if (myName == "MiningGainUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerResourceMiningGainUpgradeCost;
                myValue.text = MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade / (float)MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgradeMax);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade, MinersStatsUpgradesStatic.pokoMinerResourceMiningGainUpgradeMax);
            }
            else if (myName == "ResourceCostUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerResourceUpgradeCost;
                myValue.text = MinersStatsUpgradesStatic.pokoMinerResourceUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)MinersStatsUpgradesStatic.pokoMinerResourceUpgrade / (float)MinersStatsUpgradesStatic.pokoMinerResourceUpgradeMax);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerResourceUpgrade, MinersStatsUpgradesStatic.pokoMinerResourceUpgradeMax);
            }
            else if (myName == "BuildTimeUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerSpawnTimeUpgradeCost;
                myValue.text = MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade / (float)MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgradeMax);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade, MinersStatsUpgradesStatic.pokoMinerSpawnTimeUpgradeMax);
            }
            else if (myName == "MoveSpeedUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerMoveSpeedUpgradeCost;
                myValue.text = MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade / (float)MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgradeMax);
                CheckIfStatIsMaxed(MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade, MinersStatsUpgradesStatic.pokoMinerMoveSpeedUpgradeMax);
            }           
        }
    }
}

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
                PlayerStatsUpgradesStatic.pokoMinerHealthUpgrade += 10;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerHealthUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerHealthUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.pokoMinerHealthUpgrade, PlayerStatsUpgradesStatic.pokoMinerHealthUpgradeMax);
            }
            else if (myName == "MiningGainUpgradePanel")
            {
                PlayerStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade += 5;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerResourceMiningGainUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerResourceMiningGainUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade, PlayerStatsUpgradesStatic.pokoMinerResourceMiningGainUpgradeMax);
            }
            else if (myName == "ResourceCostUpgradePanel")
            {
                PlayerStatsUpgradesStatic.pokoMinerResourceUpgrade += 5;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerResourceUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerResourceUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.pokoMinerResourceUpgrade, PlayerStatsUpgradesStatic.pokoMinerResourceUpgradeMax);
            }
            else if (myName == "BuildTimeUpgradePanel")
            {
                PlayerStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade += 0.2f;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerSpawnTimeUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerSpawnTimeUpgradeCost * upgradeCostIncreaseMultiplier); ;
                CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade, PlayerStatsUpgradesStatic.pokoMinerSpawnTimeUpgradeMax);
            }
            else if (myName == "MoveSpeedUpgradePanel")
            {
                PlayerStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade += 2;
                PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
                StoredUpgradeCostsStatic.pokoMinerMoveSpeedUpgradeCost += (int)(StoredUpgradeCostsStatic.pokoMinerMoveSpeedUpgradeCost * upgradeCostIncreaseMultiplier);
                CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade, PlayerStatsUpgradesStatic.pokoMinerMoveSpeedUpgradeMax);
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
                myValue.text = PlayerStatsUpgradesStatic.pokoMinerHealthUpgrade.ToString();
                myXPCost.text = StoredUpgradeCostsStatic.pokoMinerHealthUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.pokoMinerHealthUpgrade / (float)PlayerStatsUpgradesStatic.pokoMinerHealthUpgradeMax);
            }
            else if (myName == "MiningGainUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerResourceMiningGainUpgradeCost;
                myValue.text = PlayerStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.pokoMinerResourceMiningGainUpgrade / (float)PlayerStatsUpgradesStatic.pokoMinerResourceMiningGainUpgradeMax);
            }
            else if (myName == "ResourceCostUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerResourceUpgradeCost;
                myValue.text = PlayerStatsUpgradesStatic.pokoMinerResourceUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.pokoMinerResourceUpgrade / (float)PlayerStatsUpgradesStatic.pokoMinerResourceUpgradeMax);
            }
            else if (myName == "BuildTimeUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerSpawnTimeUpgradeCost;
                myValue.text = PlayerStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.pokoMinerSpawnTimeUpgrade / (float)PlayerStatsUpgradesStatic.pokoMinerSpawnTimeUpgradeMax);
            }
            else if (myName == "MoveSpeedUpgradePanel")
            {
                upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.pokoMinerMoveSpeedUpgradeCost;
                myValue.text = PlayerStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade.ToString();
                myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
                upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.pokoMinerMoveSpeedUpgrade / (float)PlayerStatsUpgradesStatic.pokoMinerMoveSpeedUpgradeMax);
            }           
        }
    }
}

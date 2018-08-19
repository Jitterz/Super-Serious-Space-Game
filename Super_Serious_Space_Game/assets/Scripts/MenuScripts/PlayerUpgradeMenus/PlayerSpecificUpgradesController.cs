using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpecificUpgradesController : MonoBehaviour {

    public Image upgradeBar;
    public GameObject myPanel;
    public Text myXPCost;
    public Text myValue;

    private float upgradeCostIncreaseMultiplier = 0.156f;
    private ShowHidePlayerUpgrades upgradeCostControl;
    private string myName;

	// Use this for initialization
	void Start ()
    {
        myName = myPanel.gameObject.name;
        upgradeCostControl = GetComponent<ShowHidePlayerUpgrades>();
        GetMyUpgradeCostAndUpdatePanel();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void SubmitUpgrade()
    {
        if (myName == "LuckUpgradePanel")
        {
            PlayerStatsUpgradesStatic.luck += 1;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.luckUpgradeCost += (int)(StoredUpgradeCostsStatic.luckUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.luck, PlayerStatsUpgradesStatic.luckMax);
        }
        else if (myName == "StartingMinersUpgradePanel")
        {
            PlayerStatsUpgradesStatic.startingMiners += 1;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.startingMinersUpgradeCost += (int)(StoredUpgradeCostsStatic.startingMinersUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.startingMiners, PlayerStatsUpgradesStatic.startingMinersMax);
        }
        else if (myName == "XPGainIncreaseUpgradePanel")
        {
            PlayerStatsUpgradesStatic.xpGainIncrease += 5;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.xpGainIncreaseUpgradeCost += (int)(StoredUpgradeCostsStatic.xpGainIncreaseUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.xpGainIncrease, PlayerStatsUpgradesStatic.xpGainIncreaseMax);
        }
        else if (myName == "CreditsGainIncreaseUpgradePanel")
        {
            PlayerStatsUpgradesStatic.creditsGainIncrease += 5;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.creditsGainIncreaseUpgradeCost += (int)(StoredUpgradeCostsStatic.creditsGainIncreaseUpgradeCost * upgradeCostIncreaseMultiplier); ;
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.creditsGainIncrease, PlayerStatsUpgradesStatic.creditsGainIncreaseMax);
        }
        else if (myName == "FuelGainIncreaseUpgradePanel")
        {
            PlayerStatsUpgradesStatic.fuelGainIncrease += 5;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.fuelGainIncreaseUpgradeCost += (int)(StoredUpgradeCostsStatic.fuelGainIncreaseUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.fuelGainIncrease, PlayerStatsUpgradesStatic.fuelGainIncreaseMax);
        }
        else if (myName == "LowerShopPricesUpgradePanel")
        {
            PlayerStatsUpgradesStatic.lowerShopPrices += 5;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.lowerPricesUpgradeCost += (int)(StoredUpgradeCostsStatic.lowerPricesUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.lowerShopPrices, PlayerStatsUpgradesStatic.lowerShopPricesMax);
        }
        else if (myName == "SellValueUpgradePanel")
        {
            PlayerStatsUpgradesStatic.sellValueIncrease += 5;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.sellValueIncreaseUpgradeCost += (int)(StoredUpgradeCostsStatic.sellValueIncreaseUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.sellValueIncrease, PlayerStatsUpgradesStatic.sellValueIncreaseMax);
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

    private void GetMyUpgradeCostAndUpdatePanel()
    {
        if (myName == "LuckUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.luckUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.luck.ToString();
            myXPCost.text = StoredUpgradeCostsStatic.luckUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.luck / (float)PlayerStatsUpgradesStatic.luckMax);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.luck, PlayerStatsUpgradesStatic.luckMax);
        }
        else if (myName == "StartingMinersUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.startingMinersUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.startingMiners.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.startingMiners / (float)PlayerStatsUpgradesStatic.startingMinersMax);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.startingMiners, PlayerStatsUpgradesStatic.startingMinersMax);
        }
        else if (myName == "XPGainIncreaseUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.xpGainIncreaseUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.xpGainIncrease.ToString() + "%";
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.xpGainIncrease / (float)PlayerStatsUpgradesStatic.xpGainIncreaseMax);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.xpGainIncrease, PlayerStatsUpgradesStatic.xpGainIncreaseMax);
        }
        else if (myName == "CreditsGainIncreaseUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.creditsGainIncreaseUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.creditsGainIncrease.ToString() + "%";
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.creditsGainIncrease / (float)PlayerStatsUpgradesStatic.creditsGainIncreaseMax);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.creditsGainIncrease, PlayerStatsUpgradesStatic.creditsGainIncreaseMax);
        }
        else if (myName == "FuelGainIncreaseUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.fuelGainIncreaseUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.fuelGainIncrease.ToString() + "%";
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.fuelGainIncrease / (float)PlayerStatsUpgradesStatic.fuelGainIncreaseMax);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.fuelGainIncrease, PlayerStatsUpgradesStatic.fuelGainIncreaseMax);
        }
        else if (myName == "LowerShopPricesUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.lowerPricesUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.lowerShopPrices.ToString() + "%";
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.lowerShopPrices / (float)PlayerStatsUpgradesStatic.lowerShopPricesMax);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.lowerShopPrices, PlayerStatsUpgradesStatic.lowerShopPricesMax);
        }
        else if (myName == "SellValueUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.sellValueIncreaseUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.sellValueIncrease.ToString() + "%";
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.sellValueIncrease / (float)PlayerStatsUpgradesStatic.sellValueIncreaseMax);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.sellValueIncrease, PlayerStatsUpgradesStatic.sellValueIncreaseMax);
        }
    }
}

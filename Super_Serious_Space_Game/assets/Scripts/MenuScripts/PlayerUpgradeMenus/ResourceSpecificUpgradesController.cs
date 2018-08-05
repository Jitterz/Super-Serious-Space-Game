using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSpecificUpgradesController : MonoBehaviour
{

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
        if (myName == "GoldMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceGoldMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.goldMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.goldMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceGoldMaxAmount, PlayerStatsUpgradesStatic.resourceGoldMaxAmountMax);
        }
        else if (myName == "IronMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceIronMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.ironMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.ironMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceIronMaxAmount, PlayerStatsUpgradesStatic.resourceIronMaxAmountMax);
        }
        else if (myName == "CopperMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceCopperMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.copperMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.copperMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceCopperMaxAmount, PlayerStatsUpgradesStatic.resourceCopperMaxAmountMax);
        }
        else if (myName == "NickelMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceNickelMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.nickelMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.nickelMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier); ;
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceNickelMaxAmount, PlayerStatsUpgradesStatic.resourceNickelMaxAmountMax);
        }
        else if (myName == "SilverMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceSilverMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.silverMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.silverMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceSilverMaxAmount, PlayerStatsUpgradesStatic.resourceSilverMaxAmountMax);
        }
        else if (myName == "CobaltMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceCobaltMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.cobaltMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.cobaltMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceCobaltMaxAmount, PlayerStatsUpgradesStatic.resourceCobaltMaxAmountMax);
        }
        else if (myName == "CadmiumMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceCadmiumMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.cadmiumMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.cadmiumMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceCadmiumMaxAmount, PlayerStatsUpgradesStatic.resourceCadmiumMaxAmountMax);
        }
        else if (myName == "IridiumMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourceIridiumMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.iridiumMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.iridiumMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourceIridiumMaxAmount, PlayerStatsUpgradesStatic.resourceIridiumMaxAmountMax);
        }
        else if (myName == "PaladiumMaxUpgradePanel")
        {
            PlayerStatsUpgradesStatic.resourcePaladiumMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.paladiumMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.paladiumMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(PlayerStatsUpgradesStatic.resourcePaladiumMaxAmount, PlayerStatsUpgradesStatic.resourcePaladiumMaxAmountMax);
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
        if (myName == "GoldMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.goldMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceGoldMaxAmount.ToString();
            myXPCost.text = StoredUpgradeCostsStatic.goldMaxStorageUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceGoldMaxAmount / (float)PlayerStatsUpgradesStatic.resourceGoldMaxAmountMax);
        }
        else if (myName == "IronMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.ironMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceIronMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceIronMaxAmount / (float)PlayerStatsUpgradesStatic.resourceIronMaxAmountMax);
        }
        else if (myName == "CopperMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.copperMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceCopperMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceCopperMaxAmount / (float)PlayerStatsUpgradesStatic.resourceCopperMaxAmountMax);
        }
        else if (myName == "NickelMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.nickelMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceNickelMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceNickelMaxAmount / (float)PlayerStatsUpgradesStatic.resourceNickelMaxAmountMax);
        }
        else if (myName == "SilverMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.silverMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceSilverMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceSilverMaxAmount / (float)PlayerStatsUpgradesStatic.resourceSilverMaxAmountMax);
        }
        else if (myName == "CobaltMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.cobaltMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceCobaltMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceCobaltMaxAmount / (float)PlayerStatsUpgradesStatic.resourceCobaltMaxAmountMax);
        }
        else if (myName == "CadmiumMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.cadmiumMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceCadmiumMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceCadmiumMaxAmount / (float)PlayerStatsUpgradesStatic.resourceCadmiumMaxAmountMax);
        }
        else if (myName == "IridiumMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.iridiumMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourceIridiumMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourceIridiumMaxAmount / (float)PlayerStatsUpgradesStatic.resourceIridiumMaxAmountMax);
        }
        else if (myName == "PaladiumMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.paladiumMaxStorageUpgradeCost;
            myValue.text = PlayerStatsUpgradesStatic.resourcePaladiumMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)PlayerStatsUpgradesStatic.resourcePaladiumMaxAmount / (float)PlayerStatsUpgradesStatic.resourcePaladiumMaxAmountMax);
        }
    }
}

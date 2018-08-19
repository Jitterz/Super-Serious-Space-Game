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
            ResourcesStatsUpgradesStatic.resourceGoldMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.goldMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.goldMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceGoldMaxAmount, ResourcesStatsUpgradesStatic.resourceGoldMaxAmountMax);
        }
        else if (myName == "IronMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourceIronMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.ironMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.ironMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceIronMaxAmount, ResourcesStatsUpgradesStatic.resourceIronMaxAmountMax);
        }
        else if (myName == "CopperMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourceCopperMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.copperMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.copperMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceCopperMaxAmount, ResourcesStatsUpgradesStatic.resourceCopperMaxAmountMax);
        }
        else if (myName == "NickelMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourceNickelMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.nickelMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.nickelMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier); ;
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceNickelMaxAmount, ResourcesStatsUpgradesStatic.resourceNickelMaxAmountMax);
        }
        else if (myName == "SilverMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourceSilverMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.silverMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.silverMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceSilverMaxAmount, ResourcesStatsUpgradesStatic.resourceSilverMaxAmountMax);
        }
        else if (myName == "CobaltMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourceCobaltMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.cobaltMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.cobaltMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceCobaltMaxAmount, ResourcesStatsUpgradesStatic.resourceCobaltMaxAmountMax);
        }
        else if (myName == "CadmiumMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.cadmiumMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.cadmiumMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmount, ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmountMax);
        }
        else if (myName == "IridiumMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourceIridiumMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.iridiumMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.iridiumMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceIridiumMaxAmount, ResourcesStatsUpgradesStatic.resourceIridiumMaxAmountMax);
        }
        else if (myName == "PaladiumMaxUpgradePanel")
        {
            ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmount += 25;
            PlayerInfoStatic.CurrentXP -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.paladiumMaxStorageUpgradeCost += (int)(StoredUpgradeCostsStatic.paladiumMaxStorageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmount, ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmountMax);
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
            myValue.text = ResourcesStatsUpgradesStatic.resourceGoldMaxAmount.ToString();
            myXPCost.text = StoredUpgradeCostsStatic.goldMaxStorageUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceGoldMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceGoldMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceGoldMaxAmount, ResourcesStatsUpgradesStatic.resourceGoldMaxAmountMax);
        }
        else if (myName == "IronMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.ironMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourceIronMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceIronMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceIronMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceIronMaxAmount, ResourcesStatsUpgradesStatic.resourceIronMaxAmountMax);
        }
        else if (myName == "CopperMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.copperMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourceCopperMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceCopperMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceCopperMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceCopperMaxAmount, ResourcesStatsUpgradesStatic.resourceCopperMaxAmountMax);
        }
        else if (myName == "NickelMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.nickelMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourceNickelMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceNickelMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceNickelMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceNickelMaxAmount, ResourcesStatsUpgradesStatic.resourceNickelMaxAmountMax);
        }
        else if (myName == "SilverMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.silverMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourceSilverMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceSilverMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceSilverMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceSilverMaxAmount, ResourcesStatsUpgradesStatic.resourceSilverMaxAmountMax);
        }
        else if (myName == "CobaltMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.cobaltMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourceCobaltMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceCobaltMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceCobaltMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceCobaltMaxAmount, ResourcesStatsUpgradesStatic.resourceCobaltMaxAmountMax);
        }
        else if (myName == "CadmiumMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.cadmiumMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmount, ResourcesStatsUpgradesStatic.resourceCadmiumMaxAmountMax);
        }
        else if (myName == "IridiumMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.iridiumMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourceIridiumMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourceIridiumMaxAmount / (float)ResourcesStatsUpgradesStatic.resourceIridiumMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourceIridiumMaxAmount, ResourcesStatsUpgradesStatic.resourceIridiumMaxAmountMax);
        }
        else if (myName == "PaladiumMaxUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.paladiumMaxStorageUpgradeCost;
            myValue.text = ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmount.ToString();
            myXPCost.text = upgradeCostControl.myUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmount / (float)ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmountMax);
            CheckIfStatIsMaxed(ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmount, ResourcesStatsUpgradesStatic.resourcePaladiumMaxAmountMax);
        }
    }
}

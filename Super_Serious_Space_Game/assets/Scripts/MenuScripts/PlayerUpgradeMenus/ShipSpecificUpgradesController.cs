using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSpecificUpgradesController : MonoBehaviour {

    public Image upgradeBar;
    public GameObject myPanel;
    public Text myCreditsCost;
    public Text myValue;

    private float upgradeCostIncreaseMultiplier = 0.156f;
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
        if (myName == "PartiniliShipPowerUpgradePanel")
        {
            ShipStatsUpgradesStatic.partiniliPowerCapacity += 10;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliPowerCapacityUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliPowerCapacityUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.partiniliPowerCapacity, ShipStatsUpgradesStatic.partiniliPowerCapacityMax);
        }
        else if (myName == "PartiniliShipSpeedUpgradePanel")
        {
            ShipStatsUpgradesStatic.partiniliShipSpeed += 1;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliShipSpeedUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliShipSpeedUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.partiniliShipSpeed, ShipStatsUpgradesStatic.partiniliShipSpeedMax);
        }
        else if (myName == "PartiniliScannerUpgradePanel")
        {
            ShipStatsUpgradesStatic.partiniliScannerLevel += 1;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliScannerUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliScannerUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.partiniliScannerLevel, ShipStatsUpgradesStatic.partiniliScannerLevelMax);
        }
        else if (myName == "PartiniliScannerRangeUpgradePanel")
        {
            ShipStatsUpgradesStatic.partiniliScannerRange += 1;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliScannerRangeUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliScannerRangeUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.partiniliScannerRange, ShipStatsUpgradesStatic.partiniliScannerRangeMax);
        }
        else if (myName == "PartiniliUnitCapacityUpgradePanel")
        {
            ShipStatsUpgradesStatic.partiniliUnitMaxCapacity += 1;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliUnitCapacityUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliUnitCapacityUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.partiniliUnitMaxCapacity, ShipStatsUpgradesStatic.partiniliUnitMaxCapacityMax);
        }
        else if (myName == "PartiniliFuelCapacityUpgradePanel")
        {
            ShipStatsUpgradesStatic.partiniliFuelCapacity += 5;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliFuelCapacityUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliFuelCapacityUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.partiniliFuelCapacity, ShipStatsUpgradesStatic.partiniliFuelCapacityMax);
        }
        else if (myName == "TurretDamageUpgradePanel")
        {
            ShipStatsUpgradesStatic.turretDamageUpgrade += 2;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliTurretDamageUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliTurretDamageUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.turretDamageUpgrade, ShipStatsUpgradesStatic.turretDamageUpgradeMax);
        }
        else if (myName == "TurretRangeUpgradePanel")
        {
            ShipStatsUpgradesStatic.turretRangeUpgrade += 1;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliTurretRangeUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliTurretRangeUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.turretRangeUpgrade, ShipStatsUpgradesStatic.turretRangeUpgradeMax);
        }
        else if (myName == "TurretHealthUpgradePanel")
        {
            ShipStatsUpgradesStatic.turretHealthUpgrade += 10;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliTurretHealthUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliTurretHealthUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.turretHealthUpgrade, ShipStatsUpgradesStatic.turretHealthUpgradeMax);
        }
        else if (myName == "TurretCostUpgradePanel")
        {
            ShipStatsUpgradesStatic.turretResourceDiscount += 5;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliTurretCostUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliTurretCostUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.turretResourceDiscount, ShipStatsUpgradesStatic.turretResourceDiscountMax);
        }
        else if (myName == "TurretCooldownUpgradePanel")
        {
            ShipStatsUpgradesStatic.turretCooldownReduction += 5;
            PlayerInfoStatic.CurrentCredits -= upgradeCostControl.myUpgradeCost;
            StoredUpgradeCostsStatic.partiniliTurretCooldownUpgradeCost += (int)(StoredUpgradeCostsStatic.partiniliTurretCooldownUpgradeCost * upgradeCostIncreaseMultiplier);
            CheckIfStatIsMaxed(ShipStatsUpgradesStatic.turretCooldownReduction, ShipStatsUpgradesStatic.turretCooldownReductionMax);
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
        if (myName == "PartiniliShipPowerUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliPowerCapacityUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.partiniliPowerCapacity.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliPowerCapacityUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.partiniliPowerCapacity / (float)ShipStatsUpgradesStatic.partiniliPowerCapacityMax);
        }
        else if (myName == "PartiniliShipSpeedUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliShipSpeedUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.partiniliShipSpeed.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliShipSpeedUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.partiniliShipSpeed / (float)ShipStatsUpgradesStatic.partiniliShipSpeedMax);
        }
        else if (myName == "PartiniliScannerUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliScannerUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.partiniliScannerLevel.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliScannerUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.partiniliScannerLevel / (float)ShipStatsUpgradesStatic.partiniliScannerLevelMax);
        }
        else if (myName == "PartiniliScannerRangeUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliScannerRangeUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.partiniliScannerRange.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliScannerRangeUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.partiniliScannerRange / (float)ShipStatsUpgradesStatic.partiniliScannerRangeMax);
        }
        else if (myName == "PartiniliUnitCapacityUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliUnitCapacityUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.partiniliUnitMaxCapacity.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliUnitCapacityUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.partiniliUnitMaxCapacity / (float)ShipStatsUpgradesStatic.partiniliUnitMaxCapacityMax);
        }
        else if (myName == "PartiniliFuelCapacityUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliFuelCapacityUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.partiniliFuelCapacity.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliFuelCapacityUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.partiniliFuelCapacity / (float)ShipStatsUpgradesStatic.partiniliFuelCapacityMax);
        }
        else if (myName == "TurretDamageUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliTurretDamageUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.turretDamageUpgrade.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliTurretDamageUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.turretDamageUpgrade / (float)ShipStatsUpgradesStatic.turretDamageUpgradeMax);
        }
        else if (myName == "TurretRangeUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliTurretRangeUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.turretRangeUpgrade.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliTurretRangeUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.turretRangeUpgrade / (float)ShipStatsUpgradesStatic.turretRangeUpgradeMax);
        }
        else if (myName == "TurretHealthUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliTurretHealthUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.turretHealthUpgrade.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliTurretHealthUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.turretHealthUpgrade / (float)ShipStatsUpgradesStatic.turretHealthUpgradeMax);
        }
        else if (myName == "TurretCostUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliTurretCostUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.turretResourceDiscount.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliTurretCostUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.turretResourceDiscount / (float)ShipStatsUpgradesStatic.turretResourceDiscountMax);
        }
        else if (myName == "TurretCooldownUpgradePanel")
        {
            upgradeCostControl.myUpgradeCost = StoredUpgradeCostsStatic.partiniliTurretCooldownUpgradeCost;
            myValue.text = ShipStatsUpgradesStatic.turretCooldownReduction.ToString();
            myCreditsCost.text = StoredUpgradeCostsStatic.partiniliTurretCooldownUpgradeCost.ToString();
            upgradeBar.fillAmount = ((float)ShipStatsUpgradesStatic.turretCooldownReduction / (float)ShipStatsUpgradesStatic.turretCooldownReductionMax);
        }
    }
}

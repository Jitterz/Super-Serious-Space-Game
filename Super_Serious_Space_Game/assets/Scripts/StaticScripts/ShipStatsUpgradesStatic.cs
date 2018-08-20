using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatsUpgradesStatic : MonoBehaviour {

    // ---------------------------------------------Partinili-----------------------------------------------//
    public static int partiniliPowerCapacity = 50;
    public static int partiniliPowerCapacityMax = 150;
    public static int partiniliShipSpeed = 4;
    public static int partiniliShipSpeedMax = 10;
    public static int partiniliScannerLevel = 0;
    public static int partiniliScannerLevelMax = 5;
    public static int partiniliScannerRange = 0;
    public static int partiniliScannerRangeMax = 4;
    public static int partiniliUnitCapacity = 8;
    public static int partiniliUnitMaxCapacityMax = 20;
    public static int partiniliFuelCapacity = 75;
    public static int partiniliFuelCapacityMax = 150;
    public static int partiniliScannerCostUpgrade = 0;
    public static int partiniliScannerCostUpgradeMax = 40;

    // ------------------------------------------SHIP SPECIAL------------------------------------------//
    //--------TURRET SPECIAL----------------------//
    public static int turretDamageUpgrade = 0;
    public static int turretDamageUpgradeMax = 30;
    public static int turretRangeUpgrade = 0;
    public static int turretRangeUpgradeMax = 10;
    public static int turretHealthUpgrade = 0;
    public static int turretHealthUpgradeMax = 75;
    public static int turretResourceDiscount = 0;
    public static int turretResourceDiscountMax = 40;
    public static int turretCooldownReduction = 0;
    public static int turretCooldownReductionMax = 20;

    public static int GetShipScannerCost()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliScannerCostUpgrade;
        }
        else
        {
            return 0;
        }
    }
    public static int GetShipUnitCapacity()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliUnitCapacity;
        }
        else
        {
            return 0;
        }
    }

    public static int GetShipUnitCapacityMax()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliUnitMaxCapacityMax;
        }
        else
        {
            return 0;
        }
    }

    public static int GetShipScannerLevel()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliScannerLevel;
        }
        else
        {
            return 0;
        }
    }

    public static float GetShipScannerRange()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliScannerRange;
        }
        else
        {
            return 0;
        }
    }

    public static int GetShipPowerCapacity()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliPowerCapacity;
        }
        else
        {
            return 0;
        }
    }

    public static int GetShipFuelCapacity()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliFuelCapacity;
        }
        else
        {
            return 0;
        }
    }

    public static int GetShipSpeed()
    {
        if (PlayerInfoStatic.CurrentShipName == "Partinili")
        {
            return partiniliShipSpeed;
        }
        else
        {
            return 0;
        }
    }
}

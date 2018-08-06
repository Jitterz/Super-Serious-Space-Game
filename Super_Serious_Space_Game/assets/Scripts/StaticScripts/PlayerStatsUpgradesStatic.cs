using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsUpgradesStatic : MonoBehaviour {
    //-------------------------------------------PLAYER SPECIFIC---------------------------------------//
    public static List<string> discoveredUnits;
    public static int luck = 1;
    public static int luckMax = 50;
    public static int startingMiners = 1;
    public static int startingMinersMax = 8;
    public static int xpGainIncrease = 0;
    public static int xpGainIncreaseMax = 100;
    public static int creditsGainIncrease = 0;
    public static int creditsGainIncreaseMax = 100;
    public static int fuelGainIncrease = 0;
    public static int fuelGainIncreaseMax = 100;
    public static int lowerShopPrices = 0;
    public static int lowerShopPricesMax = 100;
    public static int sellValueIncrease = 0;
    public static int sellValueIncreaseMax = 100;
    // ---------------------------------------------SHIP-----------------------------------------------//
    public static int scannerLevel = 0;
    public static float scannerRange = 0;
    public static int unitMaxCapacity = 8;
    public static int unitMaxCapacityMax = 30;

    // ------------------------------------------SHIP SPECIAL------------------------------------------//
    //--------TURRET SPECIAL----------------------//
    public static int turretDamageUpgrade = 0;
    public static int turretRangeUpgrade = 0;
    public static int turretHealthUpgrade = 0;
    public static int turretResourceDiscount = 0;
    // --------------------------------------------RESOURCES-------------------------------------------//
    public static int resourceGoldMaxAmount = 200;
    public static int resourceGoldMaxAmountMax = 2000;
    public static int resourceIronMaxAmount = 200;
    public static int resourceIronMaxAmountMax = 2000;
    public static int resourceCopperMaxAmount = 200;
    public static int resourceCopperMaxAmountMax = 2000;
    public static int resourceNickelMaxAmount = 200;
    public static int resourceNickelMaxAmountMax = 2000;
    public static int resourceSilverMaxAmount = 200;
    public static int resourceSilverMaxAmountMax = 2000;
    public static int resourceCobaltMaxAmount = 200;
    public static int resourceCobaltMaxAmountMax = 2000;
    public static int resourceCadmiumMaxAmount = 200;
    public static int resourceCadmiumMaxAmountMax = 2000;
    public static int resourceIridiumMaxAmount = 200;
    public static int resourceIridiumMaxAmountMax = 2000;
    public static int resourcePaladiumMaxAmount = 200;
    public static int resourcePaladiumMaxAmountMax = 2000;
    public static int[] maxResourceAmounts = {
        resourceGoldMaxAmount,
        resourceIronMaxAmount,
        resourceCopperMaxAmount,
        resourceNickelMaxAmount,
        resourceSilverMaxAmount,
        resourceCobaltMaxAmount,
        resourceCadmiumMaxAmount,
        resourceIridiumMaxAmount,
        resourcePaladiumMaxAmount,
    };

    // ----------------------------------------------Miners--------------------------------------------//
    // --------------POKO MINER-----------------//
    public static int pokoMinerResourceUpgrade = 0;
    public static int pokoMinerResourceUpgradeMax = 80;
    public static float pokoMinerSpawnTimeUpgrade = 0;
    public static float pokoMinerSpawnTimeUpgradeMax = 3;
    public static int pokoMinerResourceMiningGainUpgrade = 0;
    public static int pokoMinerResourceMiningGainUpgradeMax = 40;
    public static int pokoMinerHealthUpgrade = 0;
    public static int pokoMinerHealthUpgradeMax = 100;
    public static int pokoMinerMoveSpeedUpgrade = 0;
    public static int pokoMinerMoveSpeedUpgradeMax = 20;

}

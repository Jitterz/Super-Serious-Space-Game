using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsUpgradesStatic : MonoBehaviour {
    //-------------------------------------------PLAYER SPECIFIC---------------------------------------//
    public static List<string> discoveredUnits;
    public static int luck = 1;
    //--------------------------------------------PLAYER BATTLE----------------------------------------//
    public static int startingMiners = 1;
    public static int unitMaxCapacity = 2;
    // ---------------------------------------------SHIP-----------------------------------------------//
    public static int scannerLevel = 0;
    public static float scannerRange = 0;

    // ------------------------------------------SHIP SPECIAL------------------------------------------//
    //--------TURRET SPECIAL----------------------//
    public static int turretDamageUpgrade = 0;
    public static int turretRangeUpgrade = 0;
    public static int turretHealthUpgrade = 0;
    public static int turretResourceDiscount = 0;
    // --------------------------------------------RESOURCES-------------------------------------------//
    public static int resourceGoldMaxAmount = 200;
    public static int resourceIronMaxAmount = 200;
    public static int resourceCopperMaxAmount = 200;
    public static int resourceNickelMaxAmount = 200;
    public static int resourceSilverMaxAmount = 200;
    public static int resourceCobaltMaxAmount = 200;
    public static int resourceCadmiumMaxAmount = 200;
    public static int resourceIridiumMaxAmount = 200;
    public static int resourcePaladiumMaxAmount = 200;
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

    // ----------------------------------------------UNITS---------------------------------------------//
    // --------------POKO MINER-----------------//
    public static int pokoMinerResourceDiscount = 0;
    public static int pokoMinerSpawnTimeDiscount = 0;
    public static int pokoMinerResourceMiningGain = 0;
    // --------------SETTLER--------------------//
    public static int settlerResourceDiscount = 0;
    public static int settlerSpawnTimeDiscount = 0;
    public static int settlerDamageUpgrade = 0;
    // --------------NIX------------------------//
    public static int nixResourceDiscount = 0;
    public static int nixSpawnTimeDiscount = 0;
    public static int nixDamageUpgrade = 0;
    public static int nixRangeIncrease = 0;
    // --------------CHOMP------------------------//
    public static int chompResourceDiscount = 0;
    public static int chompSpawnTimeDiscount = 0;
    public static int chompDamageUpgrade = 0;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveUnitUpgrades { 

    public int GetUnitResourceDiscount(string name)
    {
        if (name == "Poko Miner")
            return PlayerStatsUpgradesStatic.pokoMinerResourceDiscount;
        else if (name == "Settler")
            return PlayerStatsUpgradesStatic.settlerResourceDiscount;
        else if (name == "Nix")
            return PlayerStatsUpgradesStatic.nixResourceDiscount;
        else if (name == "Chomp")
            return PlayerStatsUpgradesStatic.chompResourceDiscount;
        else
            Debug.Log("Upgrade resource discount hit 0");
            return 0;
    }

    public int GetUnitSpawnTimeDiscount(string name)
    {
        if (name == "Poko Miner")
            return PlayerStatsUpgradesStatic.pokoMinerSpawnTimeDiscount;
        else if (name == "Settler")
            return PlayerStatsUpgradesStatic.settlerSpawnTimeDiscount;
        else if (name == "Nix")
            return PlayerStatsUpgradesStatic.nixSpawnTimeDiscount;
        else if (name == "Chomp")
            return PlayerStatsUpgradesStatic.chompSpawnTimeDiscount;
        else
            Debug.Log("Upgrade spawn discount hit 0");
        return 0;
    }
	
    public int GetUnitDamageBoost(string name)
    {
        if (name == "Settler")
            return PlayerStatsUpgradesStatic.settlerDamageUpgrade;
        else if (name == "Nix")
            return PlayerStatsUpgradesStatic.nixDamageUpgrade;
        else if (name == "Chomp")
            return PlayerStatsUpgradesStatic.chompDamageUpgrade;
        else
            return 0;
    }

    public int GetUnitRangeIncrease(string name)
    {
        if (name == "Nix")
            return PlayerStatsUpgradesStatic.nixRangeIncrease;
        else
            return 0;
    }
}

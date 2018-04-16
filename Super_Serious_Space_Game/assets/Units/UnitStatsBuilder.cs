using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatsBuilder {

    private int positiveModifier;
    private int negativeModifier;
    private float decimalNegativeModifier;
    private int healthMultiplier = 2;

    public bool statsModified = false;

    private void SetModifiers(UnitStats myStats)
    {
        if (PlayerHiddenLevelStatic.playerLevel <= 10)
        {
            myStats.unitPowerLevel += 5;
            positiveModifier = 1;
            negativeModifier = -1;
            decimalNegativeModifier = -0.1f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 25)
        {
            myStats.unitPowerLevel += 15;
            positiveModifier = 2;
            negativeModifier = -2;
            decimalNegativeModifier = -0.2f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 40)
        {
            myStats.unitPowerLevel += 25;
            positiveModifier = 4;
            negativeModifier = -4;
            healthMultiplier = 3;
            decimalNegativeModifier = -0.3f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 65)
        {
            myStats.unitPowerLevel += 40;
            positiveModifier = 6;
            negativeModifier = -6;
            healthMultiplier = 4;
            decimalNegativeModifier = -0.4f;
        }
        else
        {
            myStats.unitPowerLevel += 65;
            positiveModifier = 7;
            negativeModifier = -7;
            healthMultiplier = 5;
            decimalNegativeModifier = -0.5f;
        }
    }

    // -------------------------------------------------------------SETTLER------------------------------------------------------------//
    private void BuildSettlerStartingStats(UnitStats myStats, string statType)
    {
        // default stats if not modified
        if (!statsModified)
        {
            myStats.unitDamage = 6;
            myStats.unitDamageMax = 10;
            myStats.health = 82;
            myStats.healthMax = 110;
            myStats.unitAttackSpeed = 1.7f;
            myStats.attackSpeedMax = 1.3f;
            myStats.unitMoveSpeed = 21f;
            myStats.moveSpeedMax = 30;
            myStats.unitBuildTime = 14;
            myStats.unitBuildTimeMax = 10;
            myStats.unitCost = 130;
            myStats.unitCostMax = 110;
            myStats.unitPowerLevel += 10;
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = Random.Range(5 + positiveModifier, 10 + positiveModifier);
            myStats.unitDamageMax = Random.Range(11 + positiveModifier, 14 + positiveModifier);
            int difference = (21 - myStats.unitDamage);
            myStats.unitPowerLevel += CalculateBonusPower(21, difference, "positive");

        }
        else if (statType == "Health")
        {
            myStats.health = Random.Range(80 + (positiveModifier * healthMultiplier), 130 + (positiveModifier * healthMultiplier));
            myStats.healthMax = Random.Range(140 + (positiveModifier * healthMultiplier), 180 + (positiveModifier * healthMultiplier));
            int difference = (215 - myStats.health);
            myStats.unitPowerLevel += CalculateBonusPower(215, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = Random.Range(1.2f + decimalNegativeModifier, 1.8f + decimalNegativeModifier);
            myStats.attackSpeedMax = Random.Range(0.8f + decimalNegativeModifier, 1.1f + decimalNegativeModifier);
            int difference = (int)((2.3f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += CalculateBonusPower((int)(2.3f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = -Random.Range(31 + positiveModifier, 36 + positiveModifier);
            int difference = (43 - (int)myStats.unitMoveSpeed);
            myStats.unitPowerLevel += CalculateBonusPower(43, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = Random.Range(10 + negativeModifier, 13 + negativeModifier);
            myStats.unitBuildTime = Random.Range(8 + negativeModifier, 10 + negativeModifier);
            int difference = (12 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(12, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = Random.Range(100 + negativeModifier, 130 + negativeModifier);
            myStats.unitCostMax = Random.Range(80 + negativeModifier, 100 + negativeModifier);
            int difference = (129 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(129, difference, "negative");
        }
    }
    // -------------------------------------------------------------NIX------------------------------------------------------------------//
    private void BuildNixStartingStats(UnitStats myStats, string statType)
    {
        if (!statsModified)
        {
            myStats.unitDamage = 4;
            myStats.unitDamageMax = 9;
            myStats.health = 52;
            myStats.healthMax = 92;
            myStats.unitAttackSpeed = 1.7f;
            myStats.attackSpeedMax = 1.2f;
            myStats.unitMoveSpeed = 21f;
            myStats.moveSpeedMax = 30;
            myStats.unitBuildTime = 12;
            myStats.unitBuildTimeMax = 8;
            myStats.unitCost = 110;
            myStats.unitCostMax = 85;
            myStats.unitPowerLevel += 13;
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = Random.Range(3 + positiveModifier, 8 + positiveModifier);
            myStats.unitDamageMax = Random.Range(8 + positiveModifier, 12 + positiveModifier);
            int difference = (19 - myStats.unitDamage);
            myStats.unitPowerLevel += CalculateBonusPower(19, difference, "positive");
        }
        else if (statType == "Health")
        {
            myStats.health = Random.Range(50 + (positiveModifier * healthMultiplier), 90 + (positiveModifier * healthMultiplier));
            myStats.healthMax = Random.Range(90 + (positiveModifier * healthMultiplier), 130 + (positiveModifier * healthMultiplier));
            int difference = (165 - myStats.health);
            myStats.unitPowerLevel += CalculateBonusPower(165, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = Random.Range(1.1f + decimalNegativeModifier, 1.6f + decimalNegativeModifier);
            myStats.attackSpeedMax = Random.Range(0.7f + decimalNegativeModifier, 1.1f + decimalNegativeModifier);
            int difference = (int)((1.5f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += CalculateBonusPower((int)(1.5f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = -Random.Range(31 + positiveModifier, 36 + positiveModifier);
            int difference = (43 - (int)myStats.unitMoveSpeed);
            myStats.unitPowerLevel += CalculateBonusPower(43, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = Random.Range(8 + negativeModifier, 11 + negativeModifier);
            myStats.unitBuildTime = Random.Range(7 + negativeModifier, 10 + negativeModifier);
            int difference = (10 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(10, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = Random.Range(70 + negativeModifier, 100 + negativeModifier);
            myStats.unitCostMax = Random.Range(60 + negativeModifier, 70 + negativeModifier);
            int difference = (93 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(93, difference, "negative");
        }
    }
    // -------------------------------------------------------------CHOMP------------------------------------------------------------------//
    private void BuildChompStartingStats(UnitStats myStats, string statType)
    {
        if (!statsModified)
        {
            myStats.unitDamage = 4;
            myStats.unitDamageMax = 9;
            myStats.health = 52;
            myStats.healthMax = 92;
            myStats.unitAttackSpeed = 1.7f;
            myStats.attackSpeedMax = 1.2f;
            myStats.unitMoveSpeed = 25f;
            myStats.moveSpeedMax = 36;
            myStats.unitBuildTime = 12;
            myStats.unitBuildTimeMax = 8;
            myStats.unitCost = 105;
            myStats.unitCostMax = 80;
            myStats.unitPowerLevel += 14;
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = Random.Range(3 + positiveModifier, 8 + positiveModifier);
            myStats.unitDamageMax = Random.Range(8 + positiveModifier, 12 + positiveModifier);
            int difference = (19 - myStats.unitDamage);
            myStats.unitPowerLevel += CalculateBonusPower(19, difference, "positive");
        }
        else if (statType == "Health")
        {
            myStats.health = Random.Range(50 + (positiveModifier * healthMultiplier), 90 + (positiveModifier * healthMultiplier));
            myStats.healthMax = Random.Range(90 + (positiveModifier * healthMultiplier), 130 + (positiveModifier * healthMultiplier));
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = Random.Range(1.1f + decimalNegativeModifier, 1.6f + decimalNegativeModifier);
            myStats.attackSpeedMax = Random.Range(0.7f + decimalNegativeModifier, 1.1f + decimalNegativeModifier);
            int difference = (int)((1.5f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += CalculateBonusPower((int)(1.5f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = Random.Range(25 + positiveModifier, 35 + positiveModifier);
            myStats.moveSpeedMax = -Random.Range(36 + positiveModifier, 41 + positiveModifier);
            int difference = (48 - (int)myStats.unitMoveSpeed);
            myStats.unitPowerLevel += CalculateBonusPower(48, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = Random.Range(8 + negativeModifier, 11 + negativeModifier);
            myStats.unitBuildTime = Random.Range(7 + negativeModifier, 10 + negativeModifier);
            int difference = (10 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(10, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = Random.Range(70 + negativeModifier, 100 + negativeModifier);
            myStats.unitCostMax = Random.Range(60 + negativeModifier, 70 + negativeModifier);
            int difference = (93 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(93, difference, "negative");
        }
    }

    private int CalculateBonusPower(int max, int difference, string positiveNegative)
    {
        float amount;
        float percentage;
        float random = Random.Range(0.2f, 0.4f);

        if (difference != 0 && max != 0)
        {
            percentage = difference / max;
        }
        else
        {
            percentage = 0;
        }

        if (positiveNegative == "positive")
        {
            if (percentage >= 0.75f)
            {
                amount = Mathf.Round(20 * random);
            }
            else if (percentage >= 0.50f)
            {
                amount = Mathf.Round(10 * random);
            }
            else
            {
                amount = Mathf.Round(4 * random);
            }
        }
        else
        {
            if (percentage >= 0.75f)
            {
                amount = Mathf.Round(4 * random);
            }
            else if (percentage >= 0.50f)
            {
                amount = Mathf.Round(10 * random);
            }
            else
            {
                amount = Mathf.Round(20 * random);
            }
        }

        return (int)amount;
    }

    public void GetUnitTypeAndBuildTheStats(string unitName, UnitStats myStats, string statType)
    {
        if (!statsModified)
        {
            SetModifiers(myStats);
        }

        if (unitName == "settler")
        {
            BuildSettlerStartingStats(myStats, statType);
        }
        else if (unitName == "Nix")
        {
            BuildNixStartingStats(myStats, statType);
        }
        else if (unitName == "Chomp")
        {
            BuildChompStartingStats(myStats, statType);
        }
    }
}

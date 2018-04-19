using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatsBuilder {

    private int positiveModifier;
    private int negativeModifier;
    private float decimalNegativeModifier;
    private int healthMultiplier = 1;

    public bool statsModified = false;

    private void SetModifiers(UnitStats myStats)
    {
        if (PlayerHiddenLevelStatic.playerLevel <= 5)
        {
            myStats.unitPowerLevel += 2;
            positiveModifier = 1;
            negativeModifier = -1;
            decimalNegativeModifier = -0.025f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 10)
        {
            myStats.unitPowerLevel += 4;
            positiveModifier = 1;
            negativeModifier = -1;
            healthMultiplier = 2;
            decimalNegativeModifier = -0.050f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 15)
        {
            myStats.unitPowerLevel += 8;
            positiveModifier = 2;
            negativeModifier = -2;
            healthMultiplier = 2;
            decimalNegativeModifier = -0.1f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 25)
        {
            myStats.unitPowerLevel += 16;
            positiveModifier = 3;
            negativeModifier = -3;
            healthMultiplier = 2;
            decimalNegativeModifier = -0.15f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 35)
        {
            myStats.unitPowerLevel += 32;
            positiveModifier = 4;
            negativeModifier = -4;
            healthMultiplier = 3;
            decimalNegativeModifier = -0.2f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 45)
        {
            myStats.unitPowerLevel += 64;
            positiveModifier = 5;
            negativeModifier = -5;
            healthMultiplier = 3;
            decimalNegativeModifier = -0.3f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 60)
        {
            myStats.unitPowerLevel += 128;
            positiveModifier = 6;
            negativeModifier = -6;
            healthMultiplier = 4;
            decimalNegativeModifier = -0.4f;
        }
        else
        {
            myStats.unitPowerLevel += 256;
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
            myStats.unitDamage = 5;
            myStats.unitDamageMax = 7;
            myStats.health = 80;
            myStats.healthMax = 90;
            myStats.unitAttackSpeed = 2.5f;
            myStats.attackSpeedMax = 2.2f;
            myStats.unitMoveSpeed = 20;
            myStats.moveSpeedMax = 30;
            myStats.unitBuildTime = 16;
            myStats.unitBuildTimeMax = 14;
            myStats.unitCost = 200;
            myStats.unitCostMax = 190;
            myStats.unitPowerLevel += 10;
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = Random.Range(5 + positiveModifier, 7 + positiveModifier);
            myStats.unitDamageMax = Random.Range(7 + positiveModifier, 9 + positiveModifier);
            int difference = (16 - myStats.unitDamage);
            myStats.unitPowerLevel += CalculateBonusPower(16, difference, "positive");

        }
        else if (statType == "Health")
        {
            myStats.health = Random.Range(80 + (positiveModifier * healthMultiplier), 90 + (positiveModifier * healthMultiplier));
            myStats.healthMax = Random.Range(90 + (positiveModifier * healthMultiplier), 120 + (positiveModifier * healthMultiplier));
            int difference = (155 - myStats.health);
            myStats.unitPowerLevel += CalculateBonusPower(155, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = Random.Range(2.2f + decimalNegativeModifier, 2.5f + decimalNegativeModifier);
            myStats.attackSpeedMax = Random.Range(2.0f + decimalNegativeModifier, 2.2f + decimalNegativeModifier);
            int difference = (int)((2.4f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += CalculateBonusPower((int)(2.4f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = Random.Range(30 + positiveModifier, 35 + positiveModifier);
            int difference = (42 - myStats.unitMoveSpeed);
            myStats.unitPowerLevel += CalculateBonusPower(42, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = Random.Range(14 + negativeModifier, 16 + negativeModifier);
            myStats.unitBuildTimeMax = Random.Range(12 + negativeModifier, 14 + negativeModifier);
            int difference = (15 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(15, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = Random.Range(190 + (negativeModifier * 2), 200 + (negativeModifier * 2));
            myStats.unitCostMax = Random.Range(170 + (negativeModifier * 2), 190 + (negativeModifier * 2));
            int difference = (214 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(214, difference, "negative");
        }
    }
    // -------------------------------------------------------------NIX------------------------------------------------------------------//
    private void BuildNixStartingStats(UnitStats myStats, string statType)
    {
        if (!statsModified)
        {
            myStats.unitDamage = 3;
            myStats.unitDamageMax = 5;
            myStats.health = 50;
            myStats.healthMax = 60;
            myStats.unitAttackSpeed = 1.9f;
            myStats.attackSpeedMax = 1.7f;
            myStats.unitMoveSpeed = 20;
            myStats.moveSpeedMax = 23;
            myStats.unitBuildTime = 14;
            myStats.unitBuildTimeMax = 12;
            myStats.unitCost = 120;
            myStats.unitCostMax = 110;
            myStats.unitPowerLevel += 13;
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = Random.Range(3 + positiveModifier, 5 + positiveModifier);
            myStats.unitDamageMax = Random.Range(5 + positiveModifier, 7 + positiveModifier);
            int difference = (14 - myStats.unitDamage);
            myStats.unitPowerLevel += CalculateBonusPower(14, difference, "positive");
        }
        else if (statType == "Health")
        {
            myStats.health = Random.Range(50 + (positiveModifier * healthMultiplier), 60 + (positiveModifier * healthMultiplier));
            myStats.healthMax = Random.Range(60 + (positiveModifier * healthMultiplier), 90 + (positiveModifier * healthMultiplier));
            int difference = (125 - myStats.health);
            myStats.unitPowerLevel += CalculateBonusPower(125, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = Random.Range(1.7f + decimalNegativeModifier, 1.9f + decimalNegativeModifier);
            myStats.attackSpeedMax = Random.Range(1.5f + decimalNegativeModifier, 1.7f + decimalNegativeModifier);
            int difference = (int)((1.8f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += CalculateBonusPower((int)(1.8f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = Random.Range(30 + positiveModifier, 35 + positiveModifier);
            int difference = (42 - myStats.unitMoveSpeed);
            myStats.unitPowerLevel += CalculateBonusPower(42, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = Random.Range(12 + negativeModifier, 14 + negativeModifier);
            myStats.unitBuildTimeMax = Random.Range(10 + negativeModifier, 12 + negativeModifier);
            int difference = (13 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(13, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = Random.Range(110 + (negativeModifier * 2), 120 + (negativeModifier * 2));
            myStats.unitCostMax = Random.Range(100 + (negativeModifier * 2), 110 + (negativeModifier * 2));
            int difference = (118 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(118, difference, "negative");
        }
    }
    // -------------------------------------------------------------CHOMP------------------------------------------------------------------//
    private void BuildChompStartingStats(UnitStats myStats, string statType)
    {
        if (!statsModified)
        {
            myStats.unitDamage = 3;
            myStats.unitDamageMax = 5;
            myStats.health = 60;
            myStats.healthMax = 70;
            myStats.unitAttackSpeed = 1.7f;
            myStats.attackSpeedMax = 1.5f;
            myStats.unitMoveSpeed = 20;
            myStats.moveSpeedMax = 30;
            myStats.unitBuildTime = 14;
            myStats.unitBuildTimeMax = 12;
            myStats.unitCost = 80;
            myStats.unitCostMax = 70;
            myStats.unitPowerLevel += 14;
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = Random.Range(3 + positiveModifier, 5 + positiveModifier);
            myStats.unitDamageMax = Random.Range(5 + positiveModifier, 7 + positiveModifier);
            int difference = (14 - myStats.unitDamage);
            myStats.unitPowerLevel += CalculateBonusPower(14, difference, "positive");
        }
        else if (statType == "Health")
        {
            myStats.health = Random.Range(60 + (positiveModifier * healthMultiplier), 70 + (positiveModifier * healthMultiplier));
            myStats.healthMax = Random.Range(70 + (positiveModifier * healthMultiplier), 100 + (positiveModifier * healthMultiplier));
            int difference = (135 - myStats.health);
            myStats.unitPowerLevel += CalculateBonusPower(135, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = Random.Range(1.5f + decimalNegativeModifier, 1.7f + decimalNegativeModifier);
            myStats.attackSpeedMax = Random.Range(1.3f + decimalNegativeModifier, 1.5f + decimalNegativeModifier);
            int difference = (int)((1.6f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += CalculateBonusPower((int)(1.6f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = Random.Range(30 + positiveModifier, 40 + positiveModifier);
            int difference = (47 - (int)myStats.unitMoveSpeed);
            myStats.unitPowerLevel += CalculateBonusPower(47, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = Random.Range(12 + negativeModifier, 14 + negativeModifier);
            myStats.unitBuildTimeMax = Random.Range(10 + negativeModifier, 12 + negativeModifier);
            int difference = (13 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(13, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = Random.Range(100 + (negativeModifier * 2), 110 + (negativeModifier * 2));
            myStats.unitCostMax = Random.Range(90 + (negativeModifier * 2), 100 + (negativeModifier * 2));
            int difference = (108 - myStats.unitBuildTime);
            myStats.unitPowerLevel += CalculateBonusPower(108, difference, "negative");
        }
    }

    private int CalculateBonusPower(int max, int difference, string positiveNegative)
    {
        float amount;
        float percentage;
        float random = Random.Range(0.25f, 0.45f);

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
            if (percentage >= 0.90f)
            {
                amount = Mathf.Round(47 * random);
            }
            else if (percentage >= 0.80f)
            {
                amount = Mathf.Round(36 * random);
            }
            else if (percentage >= 0.70f)
            {
                amount = Mathf.Round(26 * random);
            }
            else if (percentage >= 0.50f)
            {
                amount = Mathf.Round(18 * random);
            }
            else if (percentage >= 0.20f)
            {
                amount = Mathf.Round(11 * random);
            }
            else
            {
                amount = Mathf.Round(4 * random);
            }
        }
        else
        {
            if (percentage >= 0.90f)
            {
                amount = Mathf.Round(4 * random);
            }
            else if (percentage >= 0.80f)
            {
                amount = Mathf.Round(11 * random);
            }
            else if (percentage >= 0.70f)
            {
                amount = Mathf.Round(18 * random);
            }
            else if (percentage >= 0.50f)
            {
                amount = Mathf.Round(26 * random);
            }
            else if (percentage >= 0.20f)
            {
                amount = Mathf.Round(36 * random);
            }
            else
            {
                amount = Mathf.Round(47 * random);
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

        if (unitName == "Settler")
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitStatsBuilder {

    private int positiveModifier;
    private int negativeModifier;
    private float decimalNegativeModifier;
    private int healthMultiplier = 1;

    public bool statsModified = false;

    private void SetModifiers(UnitStats myStats)
    {
        if (PlayerHiddenLevelStatic.playerLevel <= 3)
        {
            positiveModifier = (int)0.25f;
            negativeModifier = (int)-0.25f;
            decimalNegativeModifier = -0.025f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 5)
        {
            positiveModifier = (int)0.45f;
            negativeModifier = (int)-0.45f;
            healthMultiplier = (int)1.5f;
            decimalNegativeModifier = -0.035f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 7)
        {
            positiveModifier = (int)0.75f;
            negativeModifier = (int)-0.75f;
            healthMultiplier = (int)1.7f;
            decimalNegativeModifier = -0.045f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 10)
        {
            positiveModifier = 1;
            negativeModifier = -1;
            healthMultiplier = 2;
            decimalNegativeModifier = -0.050f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 14)
        {
            positiveModifier = (int)1.25f;
            negativeModifier = (int)-1.25f;
            healthMultiplier = (int)2.25f;
            decimalNegativeModifier = -0.075f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 17)
        {
            positiveModifier = (int)1.45f;
            negativeModifier = (int)-1.45f;
            healthMultiplier = (int)2.5f;
            decimalNegativeModifier = -0.085f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 20)
        {
            positiveModifier = (int)1.75f;
            negativeModifier = (int)-1.75f;
            healthMultiplier = (int)2.8f;
            decimalNegativeModifier = -0.185f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 23)
        {
            positiveModifier = 2;
            negativeModifier = -2;
            healthMultiplier = 3;
            decimalNegativeModifier = -0.235f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 28)
        {
            positiveModifier = (int)2.25f;
            negativeModifier = (int)-2.25f;
            healthMultiplier = (int)3.5f;
            decimalNegativeModifier = -0.278f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 31)
        {
            positiveModifier = (int)2.45f;
            negativeModifier = (int)-2.45f;
            healthMultiplier = (int)3.5f;
            decimalNegativeModifier = -0.321f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 35)
        {
            positiveModifier = (int)2.75f;
            negativeModifier = (int)-2.75f;
            healthMultiplier = (int)3.8f;
            decimalNegativeModifier = -0.355f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 38)
        {
            positiveModifier = 3;
            negativeModifier = -3;
            healthMultiplier = 4;
            decimalNegativeModifier = -0.385f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 42)
        {
            positiveModifier = (int)3.25f;
            negativeModifier = (int)-3.25f;
            healthMultiplier = (int)4.5f;
            decimalNegativeModifier = -0.420f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 46)
        {
            positiveModifier = (int)3.45f;
            negativeModifier = (int)-3.45f;
            healthMultiplier = (int)4.5f;
            decimalNegativeModifier = -0.456f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 51)
        {
            positiveModifier = (int)3.75f;
            negativeModifier = (int)-3.75f;
            healthMultiplier = (int)4.8f;
            decimalNegativeModifier = -0.475f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 55)
        {
            positiveModifier = 4;
            negativeModifier = -4;
            healthMultiplier = 5;
            decimalNegativeModifier = -0.495f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 59)
        {
            positiveModifier = (int)4.25f;
            negativeModifier = (int)-4.25f;
            healthMultiplier = (int)5.5f;
            decimalNegativeModifier = -0.525f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 62)
        {
            positiveModifier = (int)4.45f;
            negativeModifier = (int)-4.45f;
            healthMultiplier = (int)5.5f;
            decimalNegativeModifier = -0.565f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 65)
        {
            positiveModifier = (int)4.75f;
            negativeModifier = (int)-4.75f;
            healthMultiplier = (int)5.8f;
            decimalNegativeModifier = -0.585f;
        }
        else if (PlayerHiddenLevelStatic.playerLevel <= 69)
        {
            positiveModifier = 5;
            negativeModifier = -5;
            healthMultiplier = 6;
            decimalNegativeModifier = -0.6f;
        }
        else
        {
            positiveModifier = 6;
            negativeModifier = -6;
            healthMultiplier = 7;
            decimalNegativeModifier = -0.7f;
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
            myStats.unitCapacity = 1;
            myStats.unitTargetRange = 70;
            myStats.unitAttackRange = 15;
            myStats.unitName = "Settler";
            myStats.unitResourceType = "Gold";
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = UnityEngine.Random.Range(5 + positiveModifier, 7 + positiveModifier);
            myStats.unitDamageMax = UnityEngine.Random.Range(7 + positiveModifier, 9 + positiveModifier);
            int difference = (16 - myStats.unitDamage);
            myStats.unitPowerLevel += 9 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower(16, difference, "positive");

        }
        else if (statType == "Health")
        {
            myStats.health = UnityEngine.Random.Range(80 + (positiveModifier * healthMultiplier), 90 + (positiveModifier * healthMultiplier));
            myStats.healthMax = UnityEngine.Random.Range(90 + (positiveModifier * healthMultiplier), 120 + (positiveModifier * healthMultiplier));
            int difference = (155 - (myStats.health + 10));
            myStats.unitPowerLevel += CalculateBonusPower(155, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = UnityEngine.Random.Range(2.2f + decimalNegativeModifier, 2.5f + decimalNegativeModifier);           
            myStats.attackSpeedMax = UnityEngine.Random.Range(2.0f + decimalNegativeModifier, 2.2f + decimalNegativeModifier);
            double newSpeed = Math.Round(myStats.unitAttackSpeed, 2);
            myStats.unitAttackSpeed = (float)newSpeed;
            double newMaxSpeed = Math.Round(myStats.attackSpeedMax, 2);
            myStats.attackSpeedMax = (float)newMaxSpeed;
            int difference = (int)((2.4f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += 7 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower((int)(2.4f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = UnityEngine.Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = UnityEngine.Random.Range(30 + positiveModifier, 35 + positiveModifier);
            int difference = (42 - (myStats.unitMoveSpeed + 10));
            myStats.unitPowerLevel += CalculateBonusPower(42, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = UnityEngine.Random.Range(14 + negativeModifier, 16 + negativeModifier);
            myStats.unitBuildTimeMax = UnityEngine.Random.Range(12 + negativeModifier, 14 + negativeModifier);
            int difference = (15 - myStats.unitBuildTime);
            myStats.unitPowerLevel += 5 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower(15, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = UnityEngine.Random.Range(190 + (negativeModifier * 2), 200 + (negativeModifier * 2));
            myStats.unitCostMax = UnityEngine.Random.Range(170 + (negativeModifier * 2), 190 + (negativeModifier * 2));
            int difference = (214 - myStats.unitBuildTime);
            myStats.unitPowerLevel += 3 * positiveModifier;
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
            myStats.unitCapacity = 1;
            myStats.unitTargetRange = 160;
            myStats.unitAttackRange = 125;
            myStats.unitName = "Nix";
            myStats.unitResourceType = "Iron";
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = UnityEngine.Random.Range(3 + positiveModifier, 5 + positiveModifier);
            myStats.unitDamageMax = UnityEngine.Random.Range(5 + positiveModifier, 7 + positiveModifier);
            int difference = (14 - myStats.unitDamage);
            myStats.unitPowerLevel += 9 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower(14, difference, "positive");
        }
        else if (statType == "Health")
        {
            myStats.health = UnityEngine.Random.Range(50 + (positiveModifier * healthMultiplier), 60 + (positiveModifier * healthMultiplier));
            myStats.healthMax = UnityEngine.Random.Range(60 + (positiveModifier * healthMultiplier), 90 + (positiveModifier * healthMultiplier));
            int difference = (125 - (myStats.health + 10));
            myStats.unitPowerLevel += CalculateBonusPower(125, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = UnityEngine.Random.Range(1.7f + decimalNegativeModifier, 1.9f + decimalNegativeModifier);
            myStats.attackSpeedMax = UnityEngine.Random.Range(1.5f + decimalNegativeModifier, 1.7f + decimalNegativeModifier);
            double newSpeed = Math.Round(myStats.unitAttackSpeed, 2);
            myStats.unitAttackSpeed = (float)newSpeed;
            double newMaxSpeed = Math.Round(myStats.attackSpeedMax, 2);
            myStats.attackSpeedMax = (float)newMaxSpeed;
            int difference = (int)((1.8f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += 7 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower((int)(1.8f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = UnityEngine.Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = UnityEngine.Random.Range(30 + positiveModifier, 35 + positiveModifier);
            int difference = (42 - (myStats.unitMoveSpeed + 10));
            myStats.unitPowerLevel += CalculateBonusPower(42, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = UnityEngine.Random.Range(12 + negativeModifier, 14 + negativeModifier);
            myStats.unitBuildTimeMax = UnityEngine.Random.Range(10 + negativeModifier, 12 + negativeModifier);
            int difference = (13 - myStats.unitBuildTime);
            myStats.unitPowerLevel += 5 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower(13, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = UnityEngine.Random.Range(110 + (negativeModifier * 2), 120 + (negativeModifier * 2));
            myStats.unitCostMax = UnityEngine.Random.Range(100 + (negativeModifier * 2), 110 + (negativeModifier * 2));
            int difference = (118 - myStats.unitBuildTime);
            myStats.unitPowerLevel += 3 * positiveModifier;
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
            myStats.unitCapacity = 1;
            myStats.unitTargetRange = 70;
            myStats.unitAttackRange = 15;
            myStats.unitName = "Chomp";
            myStats.unitResourceType = "Copper";
        }

        if (statType == "Attack")
        {
            myStats.unitDamage = UnityEngine.Random.Range(3 + positiveModifier, 5 + positiveModifier);
            myStats.unitDamageMax = UnityEngine.Random.Range(5 + positiveModifier, 7 + positiveModifier);
            int difference = (14 - myStats.unitDamage);
            myStats.unitPowerLevel += 13 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower(14, difference, "positive");
        }
        else if (statType == "Health")
        {
            myStats.health = UnityEngine.Random.Range(60 + (positiveModifier * healthMultiplier), 70 + (positiveModifier * healthMultiplier));
            myStats.healthMax = UnityEngine.Random.Range(70 + (positiveModifier * healthMultiplier), 100 + (positiveModifier * healthMultiplier));
            int difference = (135 - (myStats.health + 10));
            myStats.unitPowerLevel += CalculateBonusPower(135, difference, "positive");
        }
        else if (statType == "Attack Speed")
        {
            myStats.unitAttackSpeed = UnityEngine.Random.Range(1.5f + decimalNegativeModifier, 1.7f + decimalNegativeModifier);
            myStats.attackSpeedMax = UnityEngine.Random.Range(1.3f + decimalNegativeModifier, 1.5f + decimalNegativeModifier);
            double newSpeed = Math.Round(myStats.unitAttackSpeed, 2);
            myStats.unitAttackSpeed = (float)newSpeed;
            double newMaxSpeed = Math.Round(myStats.attackSpeedMax, 2);
            myStats.attackSpeedMax = (float)newMaxSpeed;
            int difference = (int)((1.6f * 100) - (myStats.unitAttackSpeed * 100));
            myStats.unitPowerLevel += 7 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower((int)(1.6f * 100), difference, "negative");
        }
        else if (statType == "Move Speed")
        {
            myStats.unitMoveSpeed = UnityEngine.Random.Range(20 + positiveModifier, 30 + positiveModifier);
            myStats.moveSpeedMax = UnityEngine.Random.Range(30 + positiveModifier, 40 + positiveModifier);
            int difference = (47 - (myStats.unitMoveSpeed + 10));
            myStats.unitPowerLevel += CalculateBonusPower(47, difference, "positive");
        }
        else if (statType == "Build Time")
        {
            myStats.unitBuildTime = UnityEngine.Random.Range(12 + negativeModifier, 14 + negativeModifier);
            myStats.unitBuildTimeMax = UnityEngine.Random.Range(10 + negativeModifier, 12 + negativeModifier);
            int difference = (13 - myStats.unitBuildTime);
            myStats.unitPowerLevel += 5 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower(13, difference, "negative");
        }
        else if (statType == "Resource Cost")
        {
            myStats.unitCost = UnityEngine.Random.Range(100 + (negativeModifier * 2), 110 + (negativeModifier * 2));
            myStats.unitCostMax = UnityEngine.Random.Range(90 + (negativeModifier * 2), 100 + (negativeModifier * 2));
            int difference = (108 - myStats.unitBuildTime);
            myStats.unitPowerLevel += 2 * positiveModifier;
            myStats.unitPowerLevel += CalculateBonusPower(108, difference, "negative");
        }
    }

    private int CalculateBonusPower(int max, int difference, string positiveNegative)
    {
        float amount;
        float percentage;
        float random = UnityEngine.Random.Range(0.40f, 0.45f);

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
            else if (percentage >= 0.60f)
            {
                amount = Mathf.Round(21 * random);
            }
            else if (percentage >= 0.50f)
            {
                amount = Mathf.Round(18 * random);
            }
            else if (percentage >= 0.40f)
            {
                amount = Mathf.Round(15 * random);
            }
            else if (percentage >= 0.30f)
            {
                amount = Mathf.Round(13 * random);
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
            else if (percentage >= 0.60f)
            {
                amount = Mathf.Round(21 * random);
            }
            else if (percentage >= 0.50f)
            {
                amount = Mathf.Round(26 * random);
            }
            else if (percentage >= 0.40f)
            {
                amount = Mathf.Round(15 * random);
            }
            else if (percentage >= 0.30f)
            {
                amount = Mathf.Round(13 * random);
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

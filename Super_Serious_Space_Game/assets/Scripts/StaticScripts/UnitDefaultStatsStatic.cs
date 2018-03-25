using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDefaultStatsStatic { 

    public void GetUnitDefaultStats(UnitStats unit)
    {
        if (unit.name == "Settler")
        {
            unit.health = 100;
            unit.unitCost = 150;
            unit.unitDamage = 10;
            unit.unitBuildTime = 10;
            unit.unitMoveSpeed = 30;
            unit.unitTargetRange = 70;
            unit.unitAttackSpeed = 1.07f;
            unit.unitResourceType = "Gold";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInformationHolder{

    // unit card
    public int CardID;
    public int UnitImageNumber;
    public int ResourceSpriteNumber;
    public int CardBackgroundNumber;
    public int ResourceTypeNumber;
    public int UnitTypeNumber;

    // unit stats
    public int Health;
    public int HealthMax;
    public int UnitCost;
    public int UnitCostMax;
    public int UnitDamage;
    public int UnitDamageMax;
    public int UnitBuildTime;
    public int UnitBuildTimeMax;
    public int UnitCapacity;
    public int UnitMoveSpeed;
    public int MoveSpeedMax;

    public float UnitCurrentMoveSpeed;
    public float UnitTargetRange;
    public float UnitAttackRange;
    public float UnitAttackSpeed;
    public float AttackSpeedMax;
    public float UnitPowerLevel;

    public string UnitName;
    public string UnitNickName;
    public string UnitResourceType;
}

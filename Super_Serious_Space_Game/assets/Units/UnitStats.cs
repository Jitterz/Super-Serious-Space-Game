using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour {

    public int health;
    public int unitCost;
    public int unitCostMin;
    public int unitCostMax;
    public int unitDamage;
    public int unitDamageMin;
    public int unitDamageMax;
    public int unitBuildTime;
    public int unitCapacity;

    public bool imDead;
    public bool isRanged;

    public float unitMoveSpeed;
    public float moveSpeedMin;
    public float moveSpeedMax;
    public float unitCurrentMoveSpeed;
    public float unitTargetRange;
    public float unitAttackRange;
    public float unitAttackSpeed;
    public float attackSpeedMin;
    public float attackSpeedMax;
    public float unitPowerLevel;

    public string unitName;
    public string unitNickName;
    public string unitResourceType;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour {

    public List<object> statsList;

    public int health;
    public int healthMax;
    public int unitCost;
    public int unitCostMax;
    public int unitDamage;
    public int unitDamageMax;
    public int unitBuildTime;
    public int unitBuildTimeMax;
    public int unitCapacity;
    public int unitMoveSpeed;
    public int moveSpeedMax;

    public bool imDead;
    public bool isRanged;

    public float unitCurrentMoveSpeed;
    public float unitTargetRange;
    public float unitAttackRange;
    public float unitAttackSpeed;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInformation : MonoBehaviour {


    public List<GameObject> myUnitCards;
    public List<string> myUnitTypes;
    public int aiPossibleUnitsCount;
    public int aiStrongUnitsCount;
    public int aiMaxUnitCount;
    public int aiMaxMinerCount;
    public int aiLevel;
    public int aiPowerLevel;
    public int shipPowerAmount;

    public GameObject shipSpecialAbility;
    public GameObject spawnerType;

    // upgrades
    public int startingMinersUpgrade;
    public int minerCostUpgrade;

    public int turretSpecialCostUpgrade;
    public int turretSpecialCooldownUpgrade;
    public int turretSpecialHealthUpgrade;
    public int turretSpecialAttackUpgrade;
    public float turretSpecialAttackSpeedUpgrade;
    public int turretSpecialAttackRangeUpgrade;

    public int resource01StorageCapacityUpgrade;
    public int resource02StorageCapacityUpgrade;
    public int resource03StorageCapacityUpgrade;
    public int resource04StorageCapacityUpgrade;

    public int unitCapacityUpgrage;

    public int spawnPodCapacityUpgrade;
    public int spawnPodCostUpgrade;
    public int startingSpawnPodsUpgrade;

    public int generatorHealthUpgrade;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

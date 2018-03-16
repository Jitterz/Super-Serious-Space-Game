using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleManager : MonoBehaviour {

    public int[] enemyResourcesAmount;

    public SpawnPod spawnPod;
    public List<GameObject> activeSpawnPods;
    public List<GameObject> myEnemyMiners;
    public List<Resource> myEnemyResources;
    public List<GameObject> mySpawnedUnits;
    public GameObject playerBase;
    public bool enemyAttacking = false;
    public bool enemyDefending = false;
    public bool enemyFallBack = false;

    // Use this for initialization
    void Start ()
    {
        enemyDefending = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SpawnEnemyUnit(GameObject unitToSpawn)
    {
        for (int i = 0; i < activeSpawnPods.Count; i++)
        {
            if (!activeSpawnPods[i].GetComponent<SpawnPod>().imSpawningSomething)
            {
                SubtractResource(unitToSpawn);
                float spawnTime = unitToSpawn.GetComponent<UnitStats>().unitBuildTime;

                activeSpawnPods[i].GetComponent<SpawnPod>().GiveSpawnPodUnit(unitToSpawn, spawnTime);
            }
        }
    }

    private void SubtractResource(GameObject myUnit)
    {
        UnitStats myStats = myUnit.GetComponent<UnitStats>();
        if (myStats.unitResourceType == "Gold")
        {
            enemyResourcesAmount[0] -= myStats.unitCost;
        }
        else if (myStats.unitResourceType == "Iron")
        {
            enemyResourcesAmount[1] -= myStats.unitCost;
        }
        else if (myStats.unitResourceType == "Copper")
        {
            enemyResourcesAmount[2] -= myStats.unitCost;
        }
    }
}

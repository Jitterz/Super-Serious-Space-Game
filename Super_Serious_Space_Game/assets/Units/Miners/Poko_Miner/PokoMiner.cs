using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokoMiner : MonoBehaviour {

    public SpriteRenderer minerSelectedSprite;
    public GameObject playerBattleManager;
    public GameObject enemyBattleManager;
    public float miningStartTime;
    public float miningEndTime;
    public float miningIncriment;
    public int miningGain;

    private Animator animator;
    private MoveToNode minerAtNode;
    private GameObject targetNode;
    private PlayerBattleManager playerBattleManagerScript;
    private EnemyBattleManager enemyBattleManagerScript;
    private UnitStats myStats;
    private int playerMiningGain = 120;
    private int enemyMiningGain = 20;

    // Use this for initialization
    void Start ()
    {
        myStats = GetComponent<UnitStats>();
        myStats.unitCurrentMoveSpeed = myStats.unitMoveSpeed;
        animator = GetComponent<Animator>();
        minerAtNode = GetComponent<MoveToNode>();
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        enemyBattleManager = GameObject.Find("EnemyBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        enemyBattleManagerScript = enemyBattleManager.GetComponent<EnemyBattleManager>();
        // check if I am an enemy or player miner and add me to their list
        if (gameObject.tag == "PlayerMiner")
        {
            playerBattleManagerScript.myPlayerMiners.Add(gameObject);
            playerBattleManagerScript.mySpawnedUnits.Add(gameObject);
            playerBattleManagerScript.spawnedUnitsCapacityCount++;
            miningGain = playerMiningGain + PlayerStatsUpgradesStatic.pokoMinerResourceMiningGain;
        }
        else
        {
            enemyBattleManagerScript.myEnemyMiners.Add(gameObject);
            enemyBattleManagerScript.mySpawnedUnits.Add(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        LookAtResourceNode();

        if (!myStats.imDead)
        {
            if (minerAtNode.isAtNode)
            {
                MineNode();
            }
            else
            {
                miningStartTime = 0;
            }
        }

        if (myStats.health <= 0)
        {
            Die();
        }

	}

    private void MineNode()
    {
        if (miningStartTime <= miningEndTime)
        {
            miningStartTime += miningIncriment * Time.deltaTime;
        }
        else if (miningStartTime >= miningEndTime)
        {
            miningStartTime = 0;
            GiveResource();
        }          
    }

    private void LookAtResourceNode()
    {
        if (minerAtNode.currentResourceNode != null)
        {
            transform.right = minerAtNode.currentResourceNode.transform.position - transform.position;
            var newRotation = transform.rotation;
            newRotation.z = 0;
            if (minerAtNode.currentResourceNode.transform.position.x < transform.position.x)
            {
                newRotation.y = -180;
            }
            else
            {
                newRotation.y = 0;
            }

            transform.rotation = newRotation;
        }
    }

    private void GiveResource()
    {
        if (minerAtNode.currentResourceNode != null && minerAtNode.isAtNode == true)
        {
            if (gameObject.tag == "PlayerMiner")
            {
                Resource resourceScript = minerAtNode.currentResourceNode.GetComponent<Resource>();
                if (resourceScript.myResourceType == "Gold")
                {
                    playerBattleManagerScript.playerResourcesAmount[0] += miningGain;
                }
                else if (resourceScript.myResourceType == "Iron")
                {
                    playerBattleManagerScript.playerResourcesAmount[1] += miningGain;
                }
                else if (resourceScript.myResourceType == "Copper")
                {
                    playerBattleManagerScript.playerResourcesAmount[2] += miningGain;
                }
                else if (resourceScript.myResourceType == "Nickel")
                {
                    playerBattleManagerScript.playerResourcesAmount[3] += miningGain;
                }
                else if (resourceScript.myResourceType == "Silver")
                {
                    playerBattleManagerScript.playerResourcesAmount[4] += miningGain;
                }
                else if (resourceScript.myResourceType == "Cobalt")
                {
                    playerBattleManagerScript.playerResourcesAmount[5] += miningGain;
                }
                else if (resourceScript.myResourceType == "Cadmium")
                {
                    playerBattleManagerScript.playerResourcesAmount[6] += miningGain;
                }
                else if (resourceScript.myResourceType == "Iridium")
                {
                    playerBattleManagerScript.playerResourcesAmount[7] += miningGain;
                }
                else if (resourceScript.myResourceType == "Paladium")
                {
                    playerBattleManagerScript.playerResourcesAmount[8] += miningGain;
                }
            }
            if (gameObject.tag == "EnemyMiner")
            {
                Resource resourceScript = minerAtNode.currentResourceNode.GetComponent<Resource>();
                if (resourceScript.myResourceType == "Gold")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[0] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Iron")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[1] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Copper")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[2] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Nickel")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[3] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Silver")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[4] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Cobalt")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[5] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Cadmium")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[6] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Iridium")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[7] += (enemyMiningGain);
                }
                else if (resourceScript.myResourceType == "Paladium")
                {
                    enemyBattleManagerScript.enemyResourcesAmount[8] += (enemyMiningGain);
                }
            }
        }
    }

    private void Die()
    {
        myStats.imDead = true;
        animator.SetBool("isMining", false);
        animator.SetBool("isDead", true);
        if (gameObject.tag == "PlayerMiner")
        {
            for (int i = 0; i < playerBattleManagerScript.myPlayerMiners.Count; i++)
            {
                if (playerBattleManagerScript.myPlayerMiners[i] == gameObject)
                {
                    playerBattleManagerScript.myPlayerMiners.RemoveAt(i);
                    playerBattleManagerScript.spawnedUnitsCapacityCount--;
                }
            }
        }
        else
        {
            for (int i = 0; i < enemyBattleManagerScript.myEnemyMiners.Count; i++)
            {
                if (enemyBattleManagerScript.myEnemyMiners[i] == gameObject)
                {
                    enemyBattleManagerScript.myEnemyMiners.RemoveAt(i);
                }
            }
        }
        Destroy(gameObject, 2f);
    }
}

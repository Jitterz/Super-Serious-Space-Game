using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arius : MonoBehaviour {

    // only uses gold. One of the first AI player will encounter. Only pokominer and Settler. 
    public List<GameObject> mySpawnableUnitsPrefab;
    public List<GameObject> mySpawnableUnits;
    
    private AIInformation aiInfo;
    private bool startMining;
    private bool imAttacking;
    private GameObject enemyBattleManager;
    private EnemyBattleManager enemyBattleManagerScript;
    private MoveToNode minerMoveToNode;
    private int maxMinerCount;
    private int maxUnitCount;
    private bool buildMinerBeforeUnits;
    private int myGoldNodes;
    private int originalMinersCount;
    private int attackPlan;
    private float startAttackTimer;
    private float endAttackTime;

    private List<string> aiUnits;

	// Use this for initialization
	void Start ()
    {       
        startAttackTimer = 0;
        endAttackTime = Random.Range(20, 240);
        attackPlan = Random.Range(0, 1);
        originalMinersCount = 2;
        
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "02a_Space")
        {
            BuildMaxUnitCounts();
            BuildAIUnits();
        }       

        mySpawnableUnits = new List<GameObject>();

        // remove me need to add miner cards
        mySpawnableUnits.Add(mySpawnableUnitsPrefab[0]);
        // added default prefab miner for now

        BuildSpawnableUnitsFromCards();
        GetGoldNodesTotal();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "02a_Space")
        {
            if (!startMining)
            {
                StartMining();
            }
            BuildUnits();
        }

        if (originalMinersCount < enemyBattleManagerScript.myEnemyMiners.Count)
        {
            originalMinersCount++;
            FindANode();
        }

        if (enemyBattleManagerScript.enemyAttacking == true)
        {
            if (enemyBattleManagerScript.mySpawnedUnits.Count <= 2)
            {
                enemyBattleManagerScript.enemyAttacking = false;
                enemyBattleManagerScript.enemyDefending = true;
            }
        }
        Attack();
	}

    private void Awake()
    {
        aiInfo = GetComponent<AIInformation>();
        BuildAIInfo();
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "02a_Space")
        {
            enemyBattleManager = GameObject.Find("EnemyBattleManager");
            enemyBattleManagerScript = enemyBattleManager.GetComponent<EnemyBattleManager>();
        }
        aiUnits = new List<string>();
        SavedPlanetForBattleStatic.startingMiners = 1;
    }

    private void GetGoldNodesTotal()
    {
        for (int i = 0; i < enemyBattleManagerScript.myEnemyResources.Count; i++)
        {
            if (enemyBattleManagerScript.myEnemyResources[i].myResourceType  == "Gold")
            {
                myGoldNodes++;
            }
        }
    }

    private void StartMining()
    {
        startMining = true;
        // send the miners to mine the gold nodes right away. Arius will only ever start with 2 miners.
        for (int i = 0; i < enemyBattleManagerScript.myEnemyMiners.Count; i++)
        {
            for (int j = 0; j < enemyBattleManagerScript.myEnemyResources.Count; j++)
            {
                if (enemyBattleManagerScript.myEnemyResources[j].myResourceType == "Gold")
                {
                    minerMoveToNode = enemyBattleManagerScript.myEnemyMiners[i].GetComponent<MoveToNode>();
                    minerMoveToNode.myResource = enemyBattleManagerScript.myEnemyResources[j].transform.gameObject;
                    minerMoveToNode.isMovingToNode = true;
                    break;
                }
            }
        }
    }

    private void FindANode()
    {
        for (int m = 0; m < enemyBattleManagerScript.myEnemyMiners.Count; m++)
        {
            minerMoveToNode = enemyBattleManagerScript.myEnemyMiners[m].GetComponent<MoveToNode>();
            // this will be a new miner
            if (minerMoveToNode.isMovingToNode == false && minerMoveToNode.isAtNode == false)
            {
                for (int i = 0; i < enemyBattleManagerScript.myEnemyResources.Count; i++)
                {
                    Resource resource = enemyBattleManagerScript.myEnemyResources[i].GetComponent<Resource>();
                    if (!resource.position1Taken || !resource.position2Taken)
                    {
                        // Arius only have units that use gold so he will prefer to find a gold node
                        if (enemyBattleManagerScript.myEnemyResources[i].myResourceType == "Gold")
                        {
                            minerMoveToNode = enemyBattleManagerScript.myEnemyMiners[m].GetComponent<MoveToNode>();
                            minerMoveToNode.myResource = enemyBattleManagerScript.myEnemyResources[i].transform.gameObject;
                            minerMoveToNode.isMovingToNode = true;
                            break;
                        }
                    }
                }
            }
        }
    }

    private void BuildUnits()
    {
        // if i am building miners before units and I can have 3 miners
        if (myGoldNodes >= 2 && buildMinerBeforeUnits == true && maxMinerCount == 3 && enemyBattleManagerScript.myEnemyMiners.Count < 3)
        {
            // if i have enough resources to build my miner
            if (enemyBattleManagerScript.enemyResourcesAmount[0] >= mySpawnableUnits[0].GetComponent<UnitStats>().unitCost)
            {
                // build him
                enemyBattleManagerScript.SpawnEnemyUnit(mySpawnableUnits[0]);
            }
        }
        // if I am not building miners fist then build a unit if I have less than my max
        // Arius can only spawn a settler unit
        else if (enemyBattleManagerScript.mySpawnedUnits.Count < maxUnitCount)
        {
            if (enemyBattleManagerScript.enemyResourcesAmount[0] >= mySpawnableUnits[1].GetComponent<UnitStats>().unitCost)
            {
                enemyBattleManagerScript.SpawnEnemyUnit(mySpawnableUnits[1]);
            }
        }
        // if im at max units then build a miner if I can
        else if (enemyBattleManagerScript.mySpawnedUnits.Count >= maxUnitCount)
        {
            // if I can build the miner
            if (enemyBattleManagerScript.myEnemyMiners.Count <= 2 && maxMinerCount == 3)
            {
                // and I have the resources
                if (enemyBattleManagerScript.enemyResourcesAmount[0] >= mySpawnableUnits[0].GetComponent<UnitStats>().unitCost)
                {
                    enemyBattleManagerScript.SpawnEnemyUnit(mySpawnableUnits[0]);
                }
            }
        }

    }

    private void BuildMaxUnitCounts()
    {
        maxMinerCount = Random.Range(2, 4);
        maxUnitCount =  Random.Range(5, 9);

        int random = Random.Range(0, 1);
        if (random == 0)
        {
            buildMinerBeforeUnits = true;
        }
        else
        {
            buildMinerBeforeUnits = false;
        }
    }

    // this should transfer the stats from the AI unit cards to the prefab objects
    // every AI will have a miner, I am skipping the miner for now because they do not have cards
    // deactivate the object afterwards
    private void BuildSpawnableUnitsFromCards()
    {
        for (int i = 1; i < mySpawnableUnitsPrefab.Count; i++)
        {
            GameObject newUnit = Instantiate(mySpawnableUnitsPrefab[i]);
            newUnit.SetActive(false);
            newUnit.name = mySpawnableUnitsPrefab[i].GetComponent<UnitStats>().name + " spawner";
            newUnit.transform.SetParent(gameObject.transform);
            UnitStats myNewStats = aiInfo.myUnitCards[i - 1].GetComponent<UnitStats>();
            UnitStats myOldStats = newUnit.GetComponent<UnitStats>();

            myOldStats.health = myNewStats.health;
            myOldStats.unitCost = myNewStats.unitCost;
            myOldStats.unitDamage = myNewStats.unitDamage;
            myOldStats.unitBuildTime = myNewStats.unitBuildTime;
            myOldStats.unitCapacity = myNewStats.unitCapacity;
            myOldStats.unitMoveSpeed = myNewStats.unitMoveSpeed;
            myOldStats.unitAttackSpeed = myNewStats.unitAttackSpeed;

            mySpawnableUnits.Add(newUnit);
        }
    }

    // temporary to test the units fighting eachother
    private void Attack()
    {
        if (attackPlan == 0)
        {
            if (enemyBattleManagerScript.mySpawnedUnits.Count >= maxUnitCount)
            {
                enemyBattleManagerScript.enemyAttacking = true;
            }
        }
        else
        {
            if (MyAttackTimer())
            {
                enemyBattleManagerScript.enemyAttacking = true;
            }
        }
    }

    private bool MyAttackTimer()
    {
        startAttackTimer += Time.deltaTime;
        if (startAttackTimer >= endAttackTime)
        {
            startAttackTimer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }


    private void BuildAIUnits()
    {
        aiUnits.Add("Settler");
        aiUnits.Add("PokoMiner");
    }

    private void BuildAIInfo()
    {
        // create the card builder
        UnitCardBuilder cardBuilder = GetComponent<UnitCardBuilder>();

        // get my level
        aiInfo.aiLevel = Random.Range(1, 4);
        aiInfo.aiPowerLevel += aiInfo.aiLevel;

        // build my unit cards Arius only has one
        aiInfo.myUnitCards = new List<GameObject>();
        GameObject newUnitCard = cardBuilder.BuildCardAI("Settler", aiInfo.aiLevel);
        newUnitCard.transform.SetParent(gameObject.transform);
        newUnitCard.SetActive(false);
        DontDestroyOnLoad(newUnitCard);
        aiInfo.myUnitCards.Add(newUnitCard);
        aiInfo.aiPowerLevel += (int)newUnitCard.GetComponent<UnitStats>().unitPowerLevel;

        // get miner upgrades
        if (aiInfo.aiLevel >= 3)
        {
            // if he is the higher level of himself then give him a couple small upgrades
            aiInfo.minerCostUpgrade += 10;
            aiInfo.aiPowerLevel += 5;

            aiInfo.resource01StorageCapacityUpgrade += 20;
            aiInfo.resource02StorageCapacityUpgrade += 20;
            aiInfo.resource03StorageCapacityUpgrade += 20;
            aiInfo.resource04StorageCapacityUpgrade += 20;
            aiInfo.aiPowerLevel += 3;

            aiInfo.generatorHealthUpgrade += Random.Range(10, 25);
            aiInfo.aiPowerLevel += (aiInfo.generatorHealthUpgrade - 5);

            int random = Random.Range(1, 100);
            if (random > 50)
            {
                aiInfo.unitCapacityUpgrage = 2;
                aiInfo.aiPossibleUnitsCount += aiInfo.unitCapacityUpgrage;
                aiInfo.aiPowerLevel += 2;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargeting : MonoBehaviour {

    private UnitStats myStats;
    private BasicMovementController moveController;
    public GameObject currentTarget;
    

    public List<GameObject> targetsList;

    private GameObject enemyGenerator;
    private GameObject playerBattleManager;
    private GameObject enemyBattleManager;
    private PlayerBattleManager playerBattleManagerScript;
    private EnemyBattleManager enemyBattleManagerScript;
    private Turret turret;

    // Use this for initialization
    void Start()
    {       
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        enemyBattleManager = GameObject.Find("EnemyBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        enemyBattleManagerScript = enemyBattleManager.GetComponent<EnemyBattleManager>();
        myStats = gameObject.GetComponent<UnitStats>();
        moveController = gameObject.GetComponent<BasicMovementController>();
        targetsList = new List<GameObject>();

        if (myStats.unitName == "Turret")
        {
            turret = GetComponent<Turret>();
        }

        if (myStats.unitName != "Turret")
        {
            if (gameObject.tag == "PlayerUnit")
            {
                enemyGenerator = GameObject.Find("EnemyGenerator");
                targetsList.Add(enemyGenerator);
            }
            else
            {
                enemyGenerator = GameObject.Find("PlayerGenerator");
                targetsList.Add(enemyGenerator);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        BuildTargetsList();
        // keep checking if I have targets in range if i dont already have one
        if (myStats.unitName != "Turret")
        {
            if (moveController.myAttackTarget == null)
            {
                GetTarget();
            }
        }
        else
        {
            if (turret.myAttackTarget == null)
            {
                GetTarget();
            }
        }
	}

    private void GetTarget()
    {
        // if my list of possible targets is not empty
        if (targetsList.Count > 0)
        {
            // randomly pick one of them
            int random = Random.Range(0, targetsList.Count);
            if (targetsList[random] != null)
            {
                currentTarget = targetsList[random];
                if (myStats.unitName != "Turret")
                {
                    moveController.myAttackTarget = currentTarget;
                }
                else
                {
                    turret.myAttackTarget = currentTarget;
                }
            }
            else
            {
                targetsList.RemoveAt(random);
            }
        }
        else
        {
            // if the list is empty nobody is in range so reset my current target
            if (myStats.unitName == "Turret")
            {
                turret.myAttackTarget = null;
            }
            else
            {
                currentTarget = null;
                moveController.myAttackTarget = null;
            }
        }
    }

    private void BuildTargetsList()
    {
        if (gameObject.tag == "PlayerUnit")
        {
            if (enemyBattleManagerScript.mySpawnedUnits.Count > 0)
            {
                for (int i = 0; i < enemyBattleManagerScript.mySpawnedUnits.Count; i++)
                {
                    if (enemyBattleManagerScript.mySpawnedUnits[i] == null || Object.Equals(enemyBattleManagerScript.mySpawnedUnits[i], "null"))
                    {
                        enemyBattleManagerScript.mySpawnedUnits.RemoveAt(i);
                        break;
                    }

                    bool targetInList = false;
                    
                    float distance = Vector3.Distance(gameObject.transform.position, enemyBattleManagerScript.mySpawnedUnits[i].transform.position);

                    if (distance <= myStats.unitTargetRange)
                    {
                        for (int t = 0; t < targetsList.Count; t++)
                        {                           
                            if (targetsList[t] == enemyBattleManagerScript.mySpawnedUnits[i])
                            {
                                targetInList = true;
                                break;
                            }
                        }

                        if (!targetInList)
                        {
                            targetsList.Add(enemyBattleManagerScript.mySpawnedUnits[i]);
                        }
                    }
                    else
                    {
                        // if the enemy is not in range and is in my list then remove him
                        for (int t = 0; t < targetsList.Count; t++)
                        {
                            if (targetsList[t] == enemyBattleManagerScript.mySpawnedUnits[i])
                            {
                                targetsList.RemoveAt(t);
                            }
                        }
                    }
                }
            }
        }

        if (gameObject.tag == "EnemyUnit")
        {
            if (playerBattleManagerScript.mySpawnedUnits.Count > 0)
            {
                for (int i = 0; i < playerBattleManagerScript.mySpawnedUnits.Count; i++)
                {
                    if (playerBattleManagerScript.mySpawnedUnits[i] == null || Object.Equals(playerBattleManagerScript.mySpawnedUnits[i], "null"))
                    {
                        playerBattleManagerScript.mySpawnedUnits.RemoveAt(i);
                        break;
                    }

                    bool targetInList = false;

                    float distance = Vector3.Distance(gameObject.transform.position, playerBattleManagerScript.mySpawnedUnits[i].transform.position);

                    if (distance <= myStats.unitTargetRange)
                    {
                        for (int t = 0; t < targetsList.Count; t++)
                        {
                            if (targetsList[t] == playerBattleManagerScript.mySpawnedUnits[i])
                            {
                                targetInList = true;
                                break;
                            }
                        }

                        if (!targetInList)
                        {
                            targetsList.Add(playerBattleManagerScript.mySpawnedUnits[i]);
                        }
                    }
                    else
                    {
                        // if the enemy is not in range and is in my list then remove him
                        for (int t = 0; t < targetsList.Count; t++)
                        {
                            if (targetsList[t] == playerBattleManagerScript.mySpawnedUnits[i])
                            {
                                targetsList.RemoveAt(t);
                            }
                        }
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nix : MonoBehaviour {

    private Animator animator;
    private BasicMovementController moveController;
    public GameObject playerBattleManager;
    public GameObject enemyBattleManager;
    public GameObject myTarget;
    public GameObject myProjectile;
    public GameObject myGun;

    private UnitStats myTargetsStats;
    private PlayerBattleManager playerBattleManagerScript;
    private EnemyBattleManager enemyBattleManagerScript;
    private UnitStats myStats;
    private BasicTargeting myTargeting;
    private float myAttacktimeStart;
    private RetrieveUnitUpgrades retrieveUnitUpgrades;

    // Use this for initialization
    void Start ()
    {
        retrieveUnitUpgrades = new RetrieveUnitUpgrades();
        moveController = gameObject.GetComponent<BasicMovementController>();
        animator = gameObject.GetComponent<Animator>();

        playerBattleManager = GameObject.Find("PlayerBattleManager");
        enemyBattleManager = GameObject.Find("EnemyBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        enemyBattleManagerScript = enemyBattleManager.GetComponent<EnemyBattleManager>();
        myTargeting = gameObject.GetComponent<BasicTargeting>();
        myStats = gameObject.GetComponent<UnitStats>();
        myStats.unitCurrentMoveSpeed = myStats.unitMoveSpeed;

        if (gameObject.tag == "PlayerUnit")
        {
            playerBattleManagerScript.mySpawnedUnits.Add(gameObject);
        }
        else
        {
            enemyBattleManagerScript.mySpawnedUnits.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if i am not at my defend position then move to it
        if (moveController.animationIsWalking)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
        }
        else if (moveController.isAttacking == true)
        {
            // if i can attack then attack
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);
            // attack will be handled by the unit because they will all be different
            Attack();
        }
        else
        {
            // else idle
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
        }

        HandleMyCurrentTarget();
        Die();
    }

    private void HandleMyCurrentTarget()
    {
        // if i currently have a target
        if (moveController.myAttackTarget != null)
        {
            // if the targets do not match then assign it and its scripts
            if (moveController.myAttackTarget != myTarget)
            {
                myTarget = moveController.myAttackTarget;
                myTargetsStats = myTarget.GetComponent<UnitStats>();
            }
        }
        // if myAttackTarget is null then make the scripts null too
        else
        {
            myTarget = null;
            myTargetsStats = null;
        }
    }

    private void Attack()
    {
        // if I have access to my targets stats
        if (!myStats.imDead)
        {
            if (myTargetsStats != null)
            {
                // run my attack timer
                if (MyAttackTimer())
                {
                    // once timer ends then shoot
                    FireProjectile(myTarget);
                    myTargetsStats.health -= myStats.unitDamage + retrieveUnitUpgrades.GetUnitDamageBoost(myStats.unitName);
                    if (myTargetsStats.health <= 0)
                    {
                        // find them in my target list and kill them
                        for (int i = 0; i < myTargeting.targetsList.Count; i++)
                        {
                            if (myTargeting.targetsList[i] == myTarget)
                            {
                                myTargeting.targetsList.RemoveAt(i);
                            }
                        }

                        myTargeting.currentTarget = null;
                        moveController.myAttackTarget = null;
                        moveController.hasTarget = false;
                        moveController.isAttacking = false;
                        myTarget = null;
                    }
                }
            }
        }
    }

    private void Die()
    {
        if (myStats.health <= 0)
        {
            myStats.imDead = true;
            animator.SetBool("isDead", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
            if (gameObject.tag == "PlayerUnit")
            {
                for (int i = 0; i < playerBattleManagerScript.mySpawnedUnits.Count; i++)
                {
                    if (playerBattleManagerScript.mySpawnedUnits[i] == gameObject)
                    {
                        playerBattleManagerScript.mySpawnedUnits.RemoveAt(i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < enemyBattleManagerScript.mySpawnedUnits.Count; i++)
                {
                    if (enemyBattleManagerScript.mySpawnedUnits[i] == gameObject)
                    {
                        enemyBattleManagerScript.mySpawnedUnits.RemoveAt(i);
                    }
                }
            }
            Destroy(gameObject, 2.0f);
        }
    }

    private bool MyAttackTimer()
    {
        if (myAttacktimeStart <= myStats.unitAttackSpeed)
        {
            myAttacktimeStart += Time.deltaTime;
            return false;
        }
        else
        {
            myAttacktimeStart = 0;
            return true;
        }
    }

    private void FireProjectile(GameObject target)
    {
        GameObject newProjectile = Instantiate(myProjectile, myGun.transform.position, Quaternion.identity);
        NixProjectile projectileScript = newProjectile.GetComponent<NixProjectile>();
        if (gameObject.tag == "PlayerUnit")
        {
            newProjectile.tag = "PlayerProjectile";
        }
        else
        {
            newProjectile.tag = "EnemyProjectile";
        }
        projectileScript.SetProjectileTarget(target, gameObject);
    }
}

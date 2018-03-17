using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Sprite playerTurretBase;
    public Sprite playerTurretHead;
    public Sprite enemyTurretBase;
    public Sprite enemyTurretHead;
    public GameObject turretProjectile;
    public GameObject turretHead;
    public GameObject turretBase;
    public GameObject myAttackTarget;
    public GameObject playerBattleManager;
    public GameObject enemyBattleManager;

    public bool isAttacking;

    private SpriteRenderer turretHeadSprite;
    private SpriteRenderer turretBaseSprite;
    private UnitStats myStats;
    private UnitStats myTargetsStats;
    private float myAttacktimeStart;
    private RetrieveUnitUpgrades retrieveUnitUpgrades;
    private BasicTargeting myTargeting;
    private Quaternion originalRotation;
    private PlayerBattleManager playerBattleManagerScript;
    private EnemyBattleManager enemyBattleManagerScript;
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        enemyBattleManager = GameObject.Find("EnemyBattleManager");
        myTargeting = GetComponent<BasicTargeting>();
        retrieveUnitUpgrades = new RetrieveUnitUpgrades();
        myStats = GetComponent<UnitStats>();
        turretBaseSprite = turretBase.GetComponent<SpriteRenderer>();
        turretHeadSprite = turretHead.GetComponent<SpriteRenderer>();
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        enemyBattleManagerScript = enemyBattleManager.GetComponent<EnemyBattleManager>();

        if (gameObject.tag == "PlayerUnit")
        {
            turretBaseSprite.sprite = playerTurretBase;
            turretHeadSprite.sprite = playerTurretHead;
            playerBattleManagerScript.mySpawnedUnits.Add(gameObject);
        }
        else
        {
            turretBaseSprite.sprite = enemyTurretBase;
            turretHeadSprite.sprite = enemyTurretHead;
            enemyBattleManagerScript.mySpawnedUnits.Add(gameObject);
        }

        originalRotation = turretHead.transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleMyCurrentTarget();

        if (myAttackTarget == null || Object.Equals(myAttackTarget, "null"))
        {
            turretHead.transform.rotation = originalRotation;
            isAttacking = false;
        }
        else
        {
            FaceTarget();

            float distance = Vector3.Distance(transform.position, myAttackTarget.transform.position);
            if (distance <= (myStats.unitAttackRange + retrieveUnitUpgrades.GetUnitDamageBoost(myStats.name)))
            {
                isAttacking = true;
                Attack();
            }
            if (distance > (myStats.unitTargetRange + retrieveUnitUpgrades.GetUnitRangeIncrease(myStats.name)))
            {
                isAttacking = false;
                myAttackTarget = null;
            }
        }

        if (isAttacking)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        Die();
	}

    private void FaceTarget()
    {
        if (myAttackTarget != null)
        {
            var newRotation = Quaternion.LookRotation(turretHead.transform.position - myAttackTarget.transform.position, Vector3.up);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;

            turretHead.transform.rotation = Quaternion.Slerp(turretHead.transform.rotation, newRotation, Time.deltaTime * 100);
        }
    }

    private void HandleMyCurrentTarget()
    {
        // if i currently have a target
        if (myAttackTarget != null)
        {
            myTargetsStats = myAttackTarget.GetComponent<UnitStats>();
        }
        // if myAttackTarget is null then make the scripts null too
        else
        {
            myAttackTarget = null;
            myTargetsStats = null;
            isAttacking = false;
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
                    FireProjectile(myAttackTarget);
                    myTargetsStats.health -= (myStats.unitDamage + retrieveUnitUpgrades.GetUnitDamageBoost(myStats.unitName));
                    if (myTargetsStats.health <= 0)
                    {
                        // find them in my target list and kill them
                        for (int i = 0; i < myTargeting.targetsList.Count; i++)
                        {
                            if (myTargeting.targetsList[i] == myAttackTarget)
                            {
                                myTargeting.targetsList.RemoveAt(i);
                            }
                        }

                        myTargeting.currentTarget = null;
                        myAttackTarget = null;
                        isAttacking = false;
                    }
                }
            }
        }
    }

    private void FireProjectile(GameObject target)
    {
        GameObject newProjectile = Instantiate(turretProjectile, turretHead.transform.position, Quaternion.identity);
        TurretProjectile projectileScript = newProjectile.GetComponent<TurretProjectile>();
        
        projectileScript.SetProjectileTarget(target, gameObject);
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

    private void Die()
    {
        if (myStats.health <= 0)
        {
            myStats.imDead = true;
            animator.SetBool("isDead", true);
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
}

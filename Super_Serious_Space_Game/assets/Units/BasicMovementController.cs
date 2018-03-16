using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementController : MonoBehaviour {

    public bool atDefendPosition;
    public Vector3 newDefendPosition;
    public GameObject myAttackTarget;
    public bool isAttacking = false;
    public bool hasTarget = false;
    public bool haveNewPosition = false;
    public bool animationIsWalking = false;
    public bool haltAttackAction;

    private GameObject myGenerator;
    private GameObject enemyGenerator;
    private PlayerBattleManager playerBattleManagerScript;
    private EnemyBattleManager enemyBattleManagerScript;
    private Vector3 myDefendPosition;
    private UnitStats myStats;


    // Use this for initialization
    void Start()
    {
        myDefendPosition = GetDefendPosition();
        myStats = gameObject.GetComponent<UnitStats>();
        playerBattleManagerScript = GameObject.Find("PlayerBattleManager").GetComponent<PlayerBattleManager>();
        enemyBattleManagerScript = GameObject.Find("EnemyBattleManager").GetComponent<EnemyBattleManager>();
        animationIsWalking = true;

        // set the power generators based on my units perspective
        if (gameObject.tag == "PlayerUnit")
        {
            myGenerator = GameObject.Find("PlayerGenerator");
            enemyGenerator = GameObject.Find("EnemyGenerator");
        }
        else
        {
            myGenerator = GameObject.Find("EnemyGenerator");
            enemyGenerator = GameObject.Find("PlayerGenerator");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!myStats.imDead)
        {
            MoveToAttack();
            MovementStateMachine();
        }
    }

    private void MovementStateMachine()
    {        
        string state = GetCurrentState();

        switch (state)
        {
            case "attacking":
                // if I dont currently have a target then move towards enemy base
                if (!hasTarget)
                {
                    MoveToAttackBase();
                }
                break;
            case "fallingback":
                if (!hasTarget)
                {
                    haltAttackAction = false;
                    MoveToFallBack();
                }
                // if I have a target but am too far from the generator then run back
                if (hasTarget)
                {
                    float distance = Vector3.Distance(transform.position, myGenerator.transform.position);

                    if(distance > 150)
                    {
                        haltAttackAction = true;
                        MoveToFallBack();
                    }
                    else
                    {
                        haltAttackAction = false;
                    }
                }
                break;
            case "defending":
                // if this unit is not fighting, doesnt have a target and I dont have a new defend position then move to my defend position
                if (!isAttacking && !haveNewPosition && !hasTarget)
                {
                    MoveToDefendPosition();
                    FaceDefendPosition();
                }
                // if unit given a new position then make that my new defend position
                if (haveNewPosition)
                {
                    myDefendPosition = newDefendPosition;
                    // reset new position
                    haveNewPosition = false;
                }
                // if I am attacking someone but moved too far from my defend position then go back
                if (hasTarget)
                {
                    float distance = Vector3.Distance(transform.position, myDefendPosition);
                    if (distance > 100)
                    {
                        haltAttackAction = true;
                        MoveToDefendPosition();
                        FaceDefendPosition();
                    }
                    else
                    {
                        haltAttackAction = false;
                    }
                }
                break;

        }
    }

    private void MoveToAttackBase()
    {
        float distance = Vector3.Distance(transform.position, enemyGenerator.transform.position);
        if (distance > myStats.unitAttackRange)
        {
            Vector3 keepFormationPosition = new Vector3();
            keepFormationPosition = transform.position;
            animationIsWalking = true;
            transform.position = Vector3.MoveTowards(transform.position, enemyGenerator.transform.position, myStats.unitCurrentMoveSpeed * Time.deltaTime);
            keepFormationPosition.x = transform.position.x;
            transform.position = keepFormationPosition;     
            FaceTargetPosition(enemyGenerator.transform.position);
        }
        else
        {
            animationIsWalking = false;
        }
    }

    private void MoveToFallBack()
    {
        float distance = Vector3.Distance(transform.position, myGenerator.transform.position);
        if (distance > myStats.unitAttackRange)
        {
            animationIsWalking = true;
            transform.position = Vector3.MoveTowards(transform.position, myGenerator.transform.position, myStats.unitMoveSpeed * Time.deltaTime);
            FaceTargetPosition(myGenerator.transform.position);
        }
        else
        {
            animationIsWalking = false;
        }
    }

    private string GetCurrentState()
    {
        if (gameObject.tag == "PlayerUnit")
        {
            if (playerBattleManagerScript.playerAttacking)
            {
                return "attacking";
            }
            else if (playerBattleManagerScript.playerDefending)
            {
                return "defending";
            }
            else
            {
                return "fallingback";
            }
        }
        else
        {
            if (enemyBattleManagerScript.enemyAttacking)
            {
                return "attacking";
            }
            else if (enemyBattleManagerScript.enemyDefending)
            {
                return "defending";
            }
            else
            {
                return "fallingback";
            }
        }
    }

    public void MoveToDefendPosition()
    {
        float distance = Vector3.Distance(transform.position, myDefendPosition);

        if (distance > 0)
        {
            atDefendPosition = false;
            myDefendPosition.z = -1;
            animationIsWalking = true;
            transform.position = Vector3.MoveTowards(transform.position, myDefendPosition, myStats.unitMoveSpeed * Time.deltaTime);
            FaceDefendPosition();
        }
        else
        {
            atDefendPosition = true;
            animationIsWalking = false;
        }
    }

    public void FaceDefendPosition()
    {
        var newRotation = transform.rotation;
        newRotation.z = 0;
        if (gameObject.tag == "PlayerUnit")
        {
            if (myDefendPosition.x < transform.position.x)
            {
                newRotation.y = -180;
            }
            else
            {
                newRotation.y = 0;
            }
        }
        else
        {
            if (myDefendPosition.x <= transform.position.x)
            {
                newRotation.y = -180;
            }
            else
            {
                newRotation.y = 0;
            }
        }
        transform.rotation = newRotation;
    }

    public void FaceTargetPosition(Vector3 position)
    {
        var newRotation = transform.rotation;
        newRotation.z = 0;
        if (gameObject.tag == "PlayerUnit")
        {
            if (position.x < transform.position.x)
            {
                newRotation.y = -180;
            }
            else
            {
                newRotation.y = 0;
            }
        }
        else
        {
            if (position.x <= transform.position.x)
            {
                newRotation.y = -180;
            }
            else
            {
                newRotation.y = 0;
            }
        }
        transform.rotation = newRotation;
    }

    private Vector3 GetDefendPosition()
    {
        Vector3 myDefendPosition;
        if (gameObject.tag == "PlayerUnit")
        {
            myDefendPosition = new Vector3(Random.Range(-121, 5), Random.Range(-150, 1.5f), -1);
        }
        else
        {
            myDefendPosition = new Vector3(Random.Range(708, 830), Random.Range(-148, -5), -1);
        }
        return myDefendPosition;
    }

    private void MoveToAttack()
    {
        if (myAttackTarget != null && !myAttackTarget.GetComponent<UnitStats>().imDead)
        {
            // get distance bewteen me and my attack target
            float distance = Vector3.Distance(transform.position, myAttackTarget.transform.position);
            // if I am further than my get target radius then remove the target
            if (distance > myStats.unitTargetRange)
            {
                myAttackTarget = null;
                hasTarget = false;
                isAttacking = false;
                haltAttackAction = false;
            }
            // if I am too far to attack but in target range then keep chasing if I am not trying to do something else
            else if (distance <= myStats.unitTargetRange && distance > myStats.unitAttackRange && !haltAttackAction)
            {
                // move towards him
                hasTarget = true;
                isAttacking = false;
                animationIsWalking = true;
                transform.position = Vector3.MoveTowards(transform.position, myAttackTarget.transform.position, myStats.unitCurrentMoveSpeed * Time.deltaTime);
            }
            // if I am close enough to attack then attack
            else if (distance <= myStats.unitAttackRange)
            {
                // attack
                isAttacking = true;
                animationIsWalking = false;
                hasTarget = true;
                FaceTargetPosition(myAttackTarget.transform.position);
            }
            // if 
            else if (haltAttackAction)
            {
                isAttacking = false;
                hasTarget = false;
            }
        }
        else
        {
            myAttackTarget = null;
            hasTarget = false;
            isAttacking = false;
            haltAttackAction = false;
        }
    }
}

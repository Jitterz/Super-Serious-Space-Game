using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour {

    public Sprite playerProjectileSprite;
    public Sprite enemyProjectileSprite;
    public GameObject myTarget;
    public float projectileSpeed;

    private GameObject myTurretUnit;
    private float projectileDistanceTraveled;
    private Vector3 mySpawnedPosition;

    // Use this for initialization
    void Start ()
    {
        projectileDistanceTraveled = 0;
        mySpawnedPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToTarget();
	}

    public void SetProjectileTarget(GameObject target, GameObject myUnit)
    {
        myTarget = target;
        myTurretUnit = myUnit;
        if (myTurretUnit.tag == "PlayerUnit")
        {
            gameObject.tag = "PlayerProjectile";
            gameObject.GetComponent<SpriteRenderer>().sprite = playerProjectileSprite;
        }
        else
        {
            gameObject.tag = "EnemyProjectile";
            gameObject.GetComponent<SpriteRenderer>().sprite = playerProjectileSprite;
        }
    }

    private void MoveToTarget()
    {
        if (myTarget != null)
        {
            projectileDistanceTraveled = Vector3.Distance(mySpawnedPosition, transform.position);
            float distanceToTarget = Vector3.Distance(transform.position, myTarget.transform.position);

            // If i have traveled too far without hitting my target then just despawn
            if (projectileDistanceTraveled >= 300)
            {
                Destroy(gameObject);
            }
            else
            {
                var newRotation = Quaternion.LookRotation(transform.position - myTarget.transform.position, Vector3.up);
                newRotation.x = 0.0f;
                newRotation.y = 0.0f;

                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 100);
                transform.position = Vector3.MoveTowards(transform.position, myTarget.transform.position, projectileSpeed * Time.deltaTime);
            }

            if (distanceToTarget <= 0.5f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

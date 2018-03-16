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

    private SpriteRenderer turretHeadSprite;
    private SpriteRenderer turretBaseSprite;

	// Use this for initialization
	void Start ()
    {
        turretBaseSprite = turretBase.GetComponent<SpriteRenderer>();
        turretHeadSprite = turretHead.GetComponent<SpriteRenderer>();

        if (gameObject.tag == "PlayerUnit")
        {
            turretBaseSprite.sprite = playerTurretBase;
            turretHeadSprite.sprite = playerTurretHead;
        }
        else
        {
            turretBaseSprite.sprite = enemyTurretBase;
            turretHeadSprite.sprite = enemyTurretHead;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

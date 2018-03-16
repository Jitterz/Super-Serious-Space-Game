using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour {

    public Sprite playerSprite;
    public Sprite enemySprite;

    private SpriteRenderer projectileSprite;

	// Use this for initialization
	void Start ()
    {
        projectileSprite = GetComponent<SpriteRenderer>();

		if (gameObject.tag == "PlayerProjectile")
        {
            projectileSprite.sprite = playerSprite;
        }
        else
        {
            projectileSprite.sprite = enemySprite;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

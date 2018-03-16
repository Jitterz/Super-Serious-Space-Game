using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIdentifier : MonoBehaviour {

    public Sprite playerSprite;
    public Sprite enemySprite;

    private SpriteRenderer mySprite;

	// Use this for initialization
	void Start ()
    {
        mySprite = gameObject.GetComponent<SpriteRenderer>();

        if (gameObject.transform.parent.tag == "PlayerUnit")
        {
            mySprite.sprite = playerSprite;
        }
        else
        {
            mySprite.sprite = enemySprite;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

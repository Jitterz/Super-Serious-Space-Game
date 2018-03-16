using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {


    public bool position1Taken;
    public bool position2Taken;
    public Sprite[] mySprite;
    private SpriteRenderer spriteRenderer;

    public List<string> resourceTypes;

    public string myResourceType;

	// Use this for initialization
	void Start ()
    {
        position1Taken = false;
        position2Taken = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void BuildResourceObject(string type)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < resourceTypes.Count; i++)
        {
            if (type == resourceTypes[i])
            {
                spriteRenderer.sprite = mySprite[i];
                myResourceType = resourceTypes[i];
            }
        }
    }
}

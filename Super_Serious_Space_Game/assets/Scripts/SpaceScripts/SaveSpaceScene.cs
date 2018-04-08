using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpaceScene : MonoBehaviour {

    public static GameObject spaceSceneSaver;

	// Use this for initialization
	void Start ()
    {
		if (spaceSceneSaver == null)
        {
            DontDestroyOnLoad(gameObject);
            spaceSceneSaver = gameObject;
        }
        else if (spaceSceneSaver != this)
        {
            Destroy(gameObject);
        }

        if (!spaceSceneSaver.activeSelf)
        {
            spaceSceneSaver.SetActive(true);
        }
	}	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

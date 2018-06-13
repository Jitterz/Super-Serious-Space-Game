using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAISaverStatic : MonoBehaviour {

    public static BattleAISaverStatic battleAISaver;
    public static GameObject savedAIStartingParent;

	// Use this for initialization
	void Start ()
    {
		if (battleAISaver == null)
        {
            DontDestroyOnLoad(gameObject);
            battleAISaver = this;          
        }
        else
        {
            if (battleAISaver != this)
            {
                Destroy(gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public static void ReturnChildToOriginalParent()
    {
        if (battleAISaver.transform.childCount > 0)
        {
            battleAISaver.transform.GetChild(0).transform.SetParent(savedAIStartingParent.transform);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ButtonChangeLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenUpgradesMenu(string name)
    {
        SpaceUIManager.pauseSpaceScene = true;
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void CloseUpgradesMenu(string name)
    {
        SceneManager.UnloadSceneAsync(name);
        SpaceUIManager.pauseSpaceScene = false;
        SpaceUIManager.upgradeMenuClosed = true;
    }
}

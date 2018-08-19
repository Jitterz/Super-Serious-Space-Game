using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerButtonController : MonoBehaviour {

    public List<GameObject> spawnerButtonPrefabs;
    private GameObject mySpawnerPrefab;

	// Use this for initialization
	void Start ()
    {
        BuildAndPlaceSpawnerPrefabButton();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BuildAndPlaceSpawnerPrefabButton()
    {
        if (PlayerInfoStatic.SelectedSpawner == "SpawnPod")
        {
            mySpawnerPrefab = spawnerButtonPrefabs[0];
            GameObject myUnitButton = Instantiate(mySpawnerPrefab, transform.position, Quaternion.identity);
            myUnitButton.transform.SetParent(gameObject.transform, false);
            myUnitButton.transform.position = gameObject.transform.position;
        }
    }
}

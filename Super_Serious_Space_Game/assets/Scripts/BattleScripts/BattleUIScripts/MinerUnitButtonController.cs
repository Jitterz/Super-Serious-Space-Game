using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerUnitButtonController : MonoBehaviour {

    public List<GameObject> minerButtonPrefabs;
    private GameObject myMiner;

	// Use this for initialization
	void Start ()
    {
        BuildAndPlaceMinerPrefabButton();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BuildAndPlaceMinerPrefabButton()
    {
        if (PlayerInfoStatic.SelectedMiner == "PokoMiner")
        {
            myMiner = minerButtonPrefabs[0];
            GameObject myUnitButton = Instantiate(myMiner, transform.position, Quaternion.identity);
            myUnitButton.transform.SetParent(gameObject.transform, false);
            myUnitButton.transform.position = gameObject.transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadUpgradesMenu : MonoBehaviour {

    public GameObject playerShip;
    private ShipController shipController;

	// Use this for initialization
	void Start ()
    {
        shipController = playerShip.GetComponent<ShipController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StopShip()
    {
        shipController.isMoving = false;
    }
}

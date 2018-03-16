using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCameraController : MonoBehaviour {

    public GameObject playerShip;
    public Vector3 offset;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(playerShip.transform.position.x + offset.x, playerShip.transform.position.y + offset.y, offset.z);
    }
}

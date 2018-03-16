using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPlanetSpawnPosition : MonoBehaviour {

    public float gizmoRadious;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, gizmoRadious);
    }
}

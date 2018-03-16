using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sagan : MonoBehaviour {

    private List<string> planetPrefix;
    private List<string> planetSuffix;
    private List<string> planetNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BuildPlanetPrefixList()
    {
        planetPrefix.Add("Calamity");
    }
}

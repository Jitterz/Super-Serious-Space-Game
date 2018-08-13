using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenuMainController : MonoBehaviour {

    public Text playerCurrentXP;
    public Text playerCurrentCredits;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerCurrentXP.text = PlayerInfoStatic.CurrentXP.ToString();
        playerCurrentCredits.text = PlayerInfoStatic.CurrentCredits.ToString();
	}
}

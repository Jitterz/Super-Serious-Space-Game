using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuButtonsController : MonoBehaviour {

    public GameObject unitsPanel;
    public GameObject playerPanel;
    public GameObject resourcesPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateUnitsPanel()
    {
        unitsPanel.SetActive(true);
        playerPanel.SetActive(false);
        resourcesPanel.SetActive(false);
    }

    public void ActivatePlayerPanel()
    {
        unitsPanel.SetActive(false);
        playerPanel.SetActive(true);
        resourcesPanel.SetActive(false);
    }

    public void ActivateResourcesPanel()
    {
        unitsPanel.SetActive(false);
        playerPanel.SetActive(false);
        resourcesPanel.SetActive(true);
    }
}

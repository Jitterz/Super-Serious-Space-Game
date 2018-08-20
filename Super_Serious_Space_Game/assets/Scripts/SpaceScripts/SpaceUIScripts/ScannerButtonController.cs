using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScannerButtonController : MonoBehaviour {

    public Text scannerCostText;
    public Button scannerButton;

    private int scannerCost;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        scannerCostText.text = (50 - ShipStatsUpgradesStatic.GetShipScannerCost()).ToString();
        scannerCost = (50 - ShipStatsUpgradesStatic.GetShipScannerCost());
        EnableDisableScannerButton();
	}

    private void EnableDisableScannerButton()
    {
        if (scannerCost > PlayerInfoStatic.CurrentShipPower)
        {
            scannerButton.interactable = false;
        }
        else
        {
            scannerButton.interactable = true;
        }
    }
}

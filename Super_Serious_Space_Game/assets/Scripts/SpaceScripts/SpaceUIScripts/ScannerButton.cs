using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerButton : MonoBehaviour {

    public GameObject shipScanner;
    private PlanetScanner planetScanner;

    private void Start()
    {
        planetScanner = shipScanner.GetComponent<PlanetScanner>();
    }

    private void OnMouseOver()
    {
        planetScanner.ScannerMouseOver();
    }

    private void OnMouseExit()
    {
        
        planetScanner.ScannerMouseExit();
    }
}

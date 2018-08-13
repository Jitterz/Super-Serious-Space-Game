using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScanner : MonoBehaviour {

    public GameObject playerShip;
    public GameObject planetSpawner;
    public bool isScanning;

    private LineRenderer scannerLine;
    private ShipController playerShipController;
    private SpriteRenderer scannerSprite;
    private PlanetSpawner planetSpawnerScript;
    private Vector3 scannerRange;

    // Use this for initialization
    void Start()
    {
        playerShipController = playerShip.GetComponent<ShipController>();
        scannerSprite = GetComponent<SpriteRenderer>();
        scannerLine = GetComponent<LineRenderer>();
        planetSpawnerScript = planetSpawner.GetComponent<PlanetSpawner>();
        scannerLine.positionCount = 51;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void UseScanner()
    {
        transform.localScale = GetScannerRange();

        // stop the ship
        playerShipController.isMoving = false;
        // make the scanner brighter
        Color alpha = scannerSprite.color;
        alpha.a = 100;
        scannerSprite.enabled = true;
        scannerSprite.color = alpha;
        
        foreach (GameObject planet in planetSpawnerScript.spawnedPlanets)
        {
            PlanetInformation planetInfo = planet.GetComponent<PlanetInformation>();
            if (planetInfo.GetComponent<SpriteRenderer>().sprite == planetInfo.unknownPlanetScanSprite)
            {
                planetInfo.isScanned = true;
                if (ShipStatsUpgradesStatic.GetShipScannerLevel() == 0)
                {
                    planetInfo.revealInformationCase = "Scan01";
                    planetInfo.PlanetSpriteStateMachine();
                }
                else if (ShipStatsUpgradesStatic.GetShipScannerLevel() == 1)
                {
                    planetInfo.revealInformationCase = "Scan02";
                    planetInfo.PlanetSpriteStateMachine();
                }
                else if (ShipStatsUpgradesStatic.GetShipScannerLevel() == 2)
                {
                    planetInfo.revealInformationCase = "Scan03";
                    planetInfo.PlanetSpriteStateMachine();
                }
                else if (ShipStatsUpgradesStatic.GetShipScannerLevel() == 4)
                {
                    planetInfo.revealInformationCase = "Scan04";
                    planetInfo.PlanetSpriteStateMachine();
                }
                else if (ShipStatsUpgradesStatic.GetShipScannerLevel() == 5)
                {
                    planetInfo.revealInformationCase = "Scan05";
                    planetInfo.PlanetSpriteStateMachine();
                }
            }
        }

        scannerSprite.enabled = false;
    }

    private void DrawScannerLine()
    {
        float x;
        float y;

        float yRadius = 2;
        float xRadius = 2;

        float angle = 20f;

        for (int i = 0; i < scannerLine.positionCount; i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yRadius;

            scannerLine.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / scannerLine.positionCount);
        }

    }

    public void ScannerMouseOver()
    {
        isScanning = true;
        transform.localScale = GetScannerRange();

        scannerSprite.enabled = true;
        
        //playerShipController.isMoving = false;

        scannerSprite.color = new Color(scannerSprite.color.r, scannerSprite.color.g, scannerSprite.color.b, 0.2f);
        GetPossiblePlanetsToScan("enter");
    }

    public void ScannerMouseExit()
    {
        isScanning = false;
        Color alpha = scannerSprite.color;
        alpha.a = 100;
        scannerSprite.color = alpha;
        scannerSprite.enabled = false;
        GetPossiblePlanetsToScan("exit");
    }

    private void GetPossiblePlanetsToScan(string enterOrExit)
    {
        if (enterOrExit == "enter")
        {
            foreach (GameObject planet in planetSpawnerScript.spawnedPlanets)
            {
                PlanetInformation planetInfo = planet.GetComponent<PlanetInformation>();

                float distance = Vector3.Distance(planet.transform.position, playerShip.transform.position);
                // if the planet is in range and is not already scanned
                if (ShipStatsUpgradesStatic.GetShipScannerRange() == 0 && (planetInfo.isScanned == false && planetInfo.planetProximityScan == false))
                {
                    if (distance <= 8f && ShipStatsUpgradesStatic.GetShipScannerRange() == 0)
                    {
                        planetInfo.GetComponent<SpriteRenderer>().sprite = planetInfo.unknownPlanetScanSprite;
                    }
                }
            }
        }
        else
        {
            foreach (GameObject planet in planetSpawnerScript.spawnedPlanets)
            {
                PlanetInformation planetInfo = planet.GetComponent<PlanetInformation>();

                // if the planet is in range and is not already scanned
                if (planetInfo.GetComponent<SpriteRenderer>().sprite == planetInfo.unknownPlanetScanSprite)
                {
                    planetInfo.GetComponent<SpriteRenderer>().sprite = planetInfo.unknownPlanetSprite;
                }
            }
        }
    }

    private Vector3 GetScannerRange()
    {
        if (ShipStatsUpgradesStatic.GetShipScannerRange() == 0)
        {
            scannerRange = new Vector3(3f, 3f, 1f);
        }
        else if (ShipStatsUpgradesStatic.GetShipScannerRange() == 1)
        {
            scannerRange = new Vector3(4f, 4f, 1f);
        }
        else if (ShipStatsUpgradesStatic.GetShipScannerRange() == 2)
        {
            scannerRange = new Vector3(5f, 5f, 1f);
        }
        else if (ShipStatsUpgradesStatic.GetShipScannerRange() == 3)
        {
            scannerRange = new Vector3(6f, 6f, 1f);
        }
        else if (ShipStatsUpgradesStatic.GetShipScannerRange() == 4)
        {
            scannerRange = new Vector3(7f, 7f, 1f);
        }
        else
        {
            scannerRange = new Vector3(3f, 3f, 1f);
            Debug.Log("Scanner range not working");

        }

        return scannerRange;
    }
}

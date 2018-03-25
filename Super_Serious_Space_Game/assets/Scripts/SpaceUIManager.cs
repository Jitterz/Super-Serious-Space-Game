﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceUIManager : MonoBehaviour {

    public GameObject playerShip;

    public Slider fuelBar;
    public Slider powerBar;
    public Text fuelBarText;
    public Text powerBarText;
    public GameObject approachPanel;
    public GameObject rewardsSplash;
    public Text creditsPlayerText;
    public Text xpPlayerText;
    public GameObject planetSpawner;

    public Image backGroundFuelBar;

    private Color fuelBarDefualtBckColor;
    private Color lerpColor;
    private PlanetSpawner planetSpawnerScript;

    private ShipController shipController;


    // Use this for initialization
    void Start ()
    {
        if (planetSpawnerScript == null)
        {
            planetSpawnerScript = planetSpawner.GetComponent<PlanetSpawner>();
        }
        approachPanel.SetActive(false);
        fuelBarDefualtBckColor = backGroundFuelBar.color;
        fuelBar.value = PlayerInfoStatic.CurrentShipFuel;
        fuelBarText.text = PlayerInfoStatic.CurrentShipFuel.ToString();
        powerBar.value = PlayerInfoStatic.CurrentShipPower;
        powerBarText.text = PlayerInfoStatic.CurrentShipPower.ToString();
        shipController = playerShip.GetComponent<ShipController>();
	}

    // Update is called once per frame
    void Update()
    {
        creditsPlayerText.text = PlayerInfoStatic.CurrentCredits.ToString();
        xpPlayerText.text = PlayerInfoStatic.CurrentXP.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            GetClickedPlanetInfo();
        }        

        if (shipController.isMoving)
        {
            PlayerInfoStatic.CurrentShipFuel -= 3.3f * Time.deltaTime;
            PlayerInfoStatic.CurrentShipFuel = (float)System.Math.Round(PlayerInfoStatic.CurrentShipFuel, 2);
            fuelBar.value = PlayerInfoStatic.CurrentShipFuel;
            fuelBarText.text = PlayerInfoStatic.CurrentShipFuel.ToString();
        }
        else
        {
            fuelBar.value = PlayerInfoStatic.CurrentShipFuel;
            fuelBarText.text = PlayerInfoStatic.CurrentShipFuel.ToString();
        }

        if (fuelBar.value < 50)
        {
            lerpColor = Color.Lerp(Color.black, Color.red, Mathf.PingPong(Time.time, 0.6f));
            backGroundFuelBar.color = lerpColor;
        }
        else
        {
            backGroundFuelBar.color = fuelBarDefualtBckColor;
        }
    }

    void GetClickedPlanetInfo()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);      

        if (hit.collider != null)
        {
            PlanetInformation planetInfo = hit.collider.gameObject.GetComponent<PlanetInformation>();
            if (planetInfo.planetName != "Home Planet" && planetInfo.planetComplete == false)
            {
                approachPanel.SetActive(true);
                approachPanel.GetComponent<ApproachPanelController>().PopulateAttackPanel(hit.transform.gameObject);
                shipController.isMoving = false;
                shipController.engine1.enableEmission = false;
                shipController.engine2.enableEmission = false;
            }
        }
    }

    public void DisplayAwardsSplash()
    {
        planetSpawnerScript.SpawnNewPlanets(SavedPlanetForBattleStatic.thePlanet);
        GameObject splash = Instantiate(rewardsSplash, transform.position, Quaternion.identity);
        splash.transform.SetParent(gameObject.transform);
        splash.SetActive(true);
    }
}
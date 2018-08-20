using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSavesManager : MonoBehaviour {

    public InputField newPlayerName;
    public Text newPlanetType;
    public Text homePlanetPositiveEffects;
    public Text homePlanetNegativeEffects;
    public Text currentShipName;
    public Text currentShipSpecialAbility;
    public Image planetImage;
    public Image shipImage;

    public Slider fuelBar;
    public Slider powerBar;
    public Slider unitCapacityBar;

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void CreateNewPlayerSave()
    {
        PlayerInfoStatic.PlayerName = newPlayerName.text;
        PlayerInfoStatic.HomePlanetType = newPlanetType.text;
        PlayerInfoStatic.HomePlanetSprite = planetImage.sprite;
        PlayerInfoStatic.HomePlanetPositiveEffects = homePlanetPositiveEffects.text;
        PlayerInfoStatic.HomePlanetNegativeEffects = homePlanetNegativeEffects.text;
    }

    public void ChangeAssignPlayerShip()
    {
        PlayerInfoStatic.CurrentShipName = currentShipName.text;
        PlayerInfoStatic.CurrentShipSpecialAbility = currentShipSpecialAbility.text;
        PlayerInfoStatic.CurrentShipFuel = fuelBar.value;
        PlayerInfoStatic.CurrentShipPower = powerBar.value;
        PlayerInfoStatic.CurrentShipCapacity = unitCapacityBar.value;
        PlayerInfoStatic.ShipImage = shipImage.sprite;
    }
}

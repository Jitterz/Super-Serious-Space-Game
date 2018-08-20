using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmCreateNewPlayer : MonoBehaviour {

    public Image shipImage;
    public Text shipName;
    public Text shipSpecialAbility;
    public Text fuelBarValue;
    public Slider fuelBar;
    public Text powerBarValue;
    public Slider powerBar;
    public Text unitCapacityBarValue;
    public Slider unitCapacityBar;

    public Image planetImage;
    public Text planetDescriptionPositive;
    public Text planetDescriptionNegative;
    public Text planetType;
    public Text playerName;

    void Start()
    {
        BuildUIElements();
    }

    private void BuildUIElements()
    {
        shipImage.sprite = PlayerInfoStatic.ShipImage;
        shipName.text = PlayerInfoStatic.CurrentShipName;
        shipSpecialAbility.text = PlayerInfoStatic.CurrentShipSpecialAbility;
        GetCurrentBarValues(PlayerInfoStatic.CurrentShipName);
        
        planetImage.sprite = PlayerInfoStatic.HomePlanetSprite;
        planetType.text = PlayerInfoStatic.HomePlanetType;
        playerName.text = PlayerInfoStatic.PlayerName;
        planetDescriptionPositive.text = PlayerInfoStatic.HomePlanetPositiveEffects;
        planetDescriptionNegative.text = PlayerInfoStatic.HomePlanetNegativeEffects;  
    }

    private void GetCurrentBarValues(string shipName)
    {
        if (shipName == "Partinili")
        {
            fuelBarValue.text = PlayerInfoStatic.CurrentShipFuel.ToString() + "/" + ShipStatsUpgradesStatic.GetShipFuelCapacity().ToString();
            powerBarValue.text = PlayerInfoStatic.CurrentShipPower.ToString() + "/" + ShipStatsUpgradesStatic.GetShipPowerCapacity().ToString();
            unitCapacityBarValue.text = PlayerInfoStatic.CurrentShipCapacity.ToString() + "/" + ShipStatsUpgradesStatic.partiniliUnitMaxCapacityMax;
            fuelBar.value = PlayerInfoStatic.CurrentShipFuel;
            fuelBar.maxValue = ShipStatsUpgradesStatic.GetShipFuelCapacity();
            powerBar.value = PlayerInfoStatic.CurrentShipPower;
            powerBar.maxValue = ShipStatsUpgradesStatic.GetShipPowerCapacity();
            unitCapacityBar.value = PlayerInfoStatic.CurrentShipCapacity;
            unitCapacityBar.maxValue = ShipStatsUpgradesStatic.GetShipUnitCapacityMax();
        }
        if (shipName == "Tugarak")
        {
            fuelBarValue.text = PlayerInfoStatic.CurrentShipFuel.ToString() + "/" + Tugarak.MaxFuel;
            powerBarValue.text = PlayerInfoStatic.CurrentShipPower.ToString() + "/" + Tugarak.MaxPower;
            unitCapacityBarValue.text = PlayerInfoStatic.CurrentShipCapacity.ToString() + "/" + Tugarak.MaxUnitCapacity;
        }
        if (shipName == "Shupe")
        {
            fuelBarValue.text = PlayerInfoStatic.CurrentShipFuel.ToString() + "/" + Shupe.MaxFuel;
            powerBarValue.text = PlayerInfoStatic.CurrentShipPower.ToString() + "/" + Shupe.MaxPower;
            unitCapacityBarValue.text = PlayerInfoStatic.CurrentShipCapacity.ToString() + "/" + Shupe.MaxUnitCapacity;
        }
    }
}

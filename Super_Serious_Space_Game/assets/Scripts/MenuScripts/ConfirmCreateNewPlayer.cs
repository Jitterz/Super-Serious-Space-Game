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
        fuelBar.value = PlayerInfoStatic.CurrentShipFuel;
        powerBar.value = PlayerInfoStatic.CurrentShipPower;
        unitCapacityBar.value = PlayerInfoStatic.CurrentShipCapacity;

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
            fuelBarValue.text = PlayerInfoStatic.CurrentShipFuel.ToString() + "/" + Partinili.MaxFuel;
            powerBarValue.text = PlayerInfoStatic.CurrentShipPower.ToString() + "/" + Partinili.MaxPower;
            unitCapacityBarValue.text = PlayerInfoStatic.CurrentShipCapacity.ToString() + "/" + Partinili.MaxUnitCapacity;
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

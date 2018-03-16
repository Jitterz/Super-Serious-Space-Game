﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelection : MonoBehaviour {

    public Slider shipSelectionSlider;
    public Text shipName;
    public Image shipImage;
    public Sprite[] shipSprite;
    public Text shipDescription;
    public Text shipSpecialAbility;

    public Text fuelBarValue;
    public Text powerBarValue;
    public Text unitCapacityBarValue;

    public Slider fuelBar;
    public Slider powerBar;
    public Slider unitCapacityBar;

    public void ChangeShip()
    {
        if (shipSelectionSlider.value == 0)
        {
            shipName.text = "Partinili";
            shipImage.sprite = shipSprite[0];
            shipDescription.text = "All around average ship.";
            shipSpecialAbility.text = "Spawn a turret in Defensive zone";
            fuelBar.value = 150;
            powerBar.value = 250;
            unitCapacityBar.value = 15;
            fuelBarValue.text = fuelBar.value.ToString() + "/" + Partinili.MaxFuel.ToString();
            powerBarValue.text = powerBar.value.ToString() + "/" + Partinili.MaxPower.ToString();
            unitCapacityBarValue.text = unitCapacityBar.value.ToString() + "/" + Partinili.MaxUnitCapacity.ToString();
            fuelBar.maxValue = Partinili.MaxFuel;
            powerBar.maxValue = Partinili.MaxPower;
            unitCapacityBar.maxValue = Partinili.MaxUnitCapacity;
        }
        if (shipSelectionSlider.value == 1)
        {
            shipName.text = "Tugarak";
            shipImage.sprite = shipSprite[1];
            shipDescription.text = "Bulky ship that allows more unit capacity but drains fuel and power faster.";
            shipSpecialAbility.text = "Drop two free units into Defensive zone";
            fuelBar.value = 100;
            powerBar.value = 125;
            unitCapacityBar.value = 18;
            fuelBarValue.text = fuelBar.value.ToString() + "/" + Tugarak.MaxFuel.ToString();
            powerBarValue.text = powerBar.value.ToString() + "/" + Tugarak.MaxPower.ToString();
            unitCapacityBarValue.text = unitCapacityBar.value.ToString() + "/" + Tugarak.MaxUnitCapacity.ToString();
            fuelBar.maxValue = Tugarak.MaxFuel;
            powerBar.maxValue = Tugarak.MaxPower;
            unitCapacityBar.maxValue = Tugarak.MaxUnitCapacity;
        }
        if (shipSelectionSlider.value == 2)
        {
            shipName.text = "Shupe";
            shipImage.sprite = shipSprite[2];
            shipDescription.text = "This ship has increased power capicity sacrificing fuel storage and unit capacity.";
            shipSpecialAbility.text = "Place a barrier inside the Defensive zone.";
            fuelBar.value = 125;
            powerBar.value = 350;
            unitCapacityBar.value = 13;
            fuelBarValue.text = fuelBar.value.ToString() + "/" + Shupe.MaxFuel.ToString();
            powerBarValue.text = powerBar.value.ToString() + "/" + Shupe.MaxPower.ToString();
            unitCapacityBarValue.text = unitCapacityBar.value.ToString() + "/" + Shupe.MaxUnitCapacity.ToString();
            fuelBar.maxValue = Shupe.MaxFuel;
            powerBar.maxValue = Shupe.MaxPower;
            unitCapacityBar.maxValue = Shupe.MaxUnitCapacity;
        }
    }
}

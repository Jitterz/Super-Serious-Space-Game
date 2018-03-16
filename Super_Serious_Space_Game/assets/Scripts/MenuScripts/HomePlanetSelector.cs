using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePlanetSelector : MonoBehaviour {

    // 0 = Temperate
    // 1 = Tropical

    public Sprite[] planetTypes;
    public Slider planetSlider;
    public Image planetImage;
    public Text planetTypeText;
    public Text planetDescriptionText;
    public Text planetEffectPositive;
    public Text planetEffectNegative;
    public Button nextButton;
    public InputField playerNameField;
    public Text nextButtonText;

    // Use this for initialization
    void Start ()
    { 

	}
	
	// Update is called once per frame
	void Update ()
    {
		if (playerNameField.text == "")
        {
            nextButton.enabled = false;
            nextButtonText.color = Color.gray;
        }
        else
        {
            nextButton.enabled = true;
            nextButtonText.color = Color.white;
        }
	}

    public void ChangePlanetType()
    {
        if (planetSlider.value == 0)
        {
            planetImage.sprite = planetTypes[0];
            planetTypeText.text = "Temperate";
            planetDescriptionText.text = "Living in perfect conditions means you are not special.";
            planetEffectPositive.text = "No positive effects";
            planetEffectNegative.text = "No negative effects";
        }
        if (planetSlider.value == 1)
        {
            planetImage.sprite = planetTypes[1];
            planetTypeText.text = "Tropical";
            planetDescriptionText.text = "The islands have afforded you knowledge in cramming into tiny spaces.";
            planetEffectPositive.text = "No Tropical Planet unit capacity effect";
            planetEffectNegative.text = "Unit capacity upgrade costs increased";
        }
        if (planetSlider.value == 2)
        {
            planetImage.sprite = planetTypes[2];
            planetTypeText.text = "Tundra";
            planetDescriptionText.text = "The frozen wasteland you call home offers great advantges in colder climates.";
            planetEffectPositive.text = "No Tundra Planet slow movement unit effect";
            planetEffectNegative.text = "Less unit health on Hot Planets";
        }
        if (planetSlider.value == 3)
        {
            planetImage.sprite = planetTypes[3];
            planetTypeText.text = "Desert";
            planetDescriptionText.text = "The scorching sand and scarce water leave you confident in hot climates.";
            planetEffectPositive.text = "No negative Planet effects on ALL hot Planets.";
            planetEffectNegative.text = "Less unit health on ALL other Planets";
        }
        if (planetSlider.value == 4)
        {
            planetImage.sprite = planetTypes[4];
            planetTypeText.text = "Volcanic";
            planetDescriptionText.text = "The raging volcanoes leave little room for species to grow.";
            planetEffectPositive.text = "Units cost less on Volcanic planets";
            planetEffectNegative.text = "Units cost more on ALL other planets";
        }
        if (planetSlider.value == 5)
        {
            planetImage.sprite = planetTypes[5];
            planetTypeText.text = "Space Hub";
            planetDescriptionText.text = "Society is so advanced you guys built your own planet.";
            planetEffectPositive.text = "Home planet is a functioning Space Hub";
            planetEffectNegative.text = "ALL prices are increased";
        }
    }
}

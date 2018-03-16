using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {

    public List<Texture> backgroundTextures;

    private RawImage backgroundImage;

	// Use this for initialization
	void Start ()
    {
        backgroundImage = gameObject.GetComponent<RawImage>();
        GetBackgroundImage();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void GetBackgroundImage()
    {
        if (SavedPlanetForBattleStatic.type == "Temperate")
        {
            backgroundImage.texture = backgroundTextures[0];
        }
        else if (SavedPlanetForBattleStatic.type == "Tropical")
        {
            backgroundImage.texture = backgroundTextures[1];
        }
        else if (SavedPlanetForBattleStatic.type == "Tundra")
        {
            backgroundImage.texture = backgroundTextures[2];
        }
        else if (SavedPlanetForBattleStatic.type == "Desert")
        {
            backgroundImage.texture = backgroundTextures[3];
        }
        else if (SavedPlanetForBattleStatic.type == "Volcanic")
        {
            backgroundImage.texture = backgroundTextures[4];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoStatic : MonoBehaviour {

    public static PlayerInfoStatic playerInfoStatic;

    private void Awake()
    {
        if (playerInfoStatic == null)
        {
            DontDestroyOnLoad(gameObject);
            playerInfoStatic = this;           
        }
        else
        {
            if (playerInfoStatic != this)
            {
                Destroy(gameObject);
            }
        }

        if(PlayerUnitCards == null)
        {
            PlayerUnitCards = new List<GameObject>();
        }
        if (PlayerDeck == null)
        {
            PlayerDeck = new List<GameObject>();
        }
    }

    // Resources
    public static float CurrentShipFuel;
    public static float CurrentCredits = 5000;
    public static float CurrentXP = 100000;

    public static string PlayerName;
    public static string HomePlanetType;
    public static string HomePlanetPositiveEffects;
    public static string HomePlanetNegativeEffects;
    public static string CurrentShipName = "Partinili";
    public static string CurrentShipSpecialAbility = "Turret";
    public static float CurrentShipPower;
    public static float CurrentShipCapacity;
    public static Sprite HomePlanetSprite;
    public static Sprite ShipImage;
    public static string SelectedMiner = "PokoMiner";
    public static string SelectedSpawner = "SpawnPod";

    public static int CardID;
    public static List<GameObject> PlayerUnitCards;
    public static List<GameObject> PlayerDeck;
}

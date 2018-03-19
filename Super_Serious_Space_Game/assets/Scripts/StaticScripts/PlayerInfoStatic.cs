using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoStatic : MonoBehaviour {

    // Resources
    public static float CurrentShipFuel;
    public static float CurrentCredits;
    public static float CurrentXP;

    public static string PlayerName;
    public static string HomePlanetType;
    public static string HomePlanetPositiveEffects;
    public static string HomePlanetNegativeEffects;
    public static string CurrentShipName;
    public static string CurrentShipSpecialAbility;
    public static float CurrentShipPower;
    public static float CurrentShipCapacity;
    public static Sprite HomePlanetSprite;
    public static Sprite ShipImage;

    public static List<GameObject> PlayerUnitCards;
    public static List<GameObject> PlayerDeck;
}

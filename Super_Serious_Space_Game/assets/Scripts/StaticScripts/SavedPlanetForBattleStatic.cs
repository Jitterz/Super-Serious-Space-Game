using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedPlanetForBattleStatic : MonoBehaviour {

    public static GameObject thePlanet;
    public static List<string> resources;
    public static string type;

    public static int fuelReward;
    public static int xPReward;
    public static int creditReward;
    public static int startingMiners;

    public static bool isConquered;
    public static bool wasAttacked;
}

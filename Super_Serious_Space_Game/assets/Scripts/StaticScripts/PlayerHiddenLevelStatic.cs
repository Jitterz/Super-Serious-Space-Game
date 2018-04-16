using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHiddenLevelStatic : MonoBehaviour {

    public static int playerLevel = 1;
    public static float totalPlayerXP = 0;

    private static float xpToNextLevel = 200;

    public static void AddXPUpdatePlayerLevel(float xpReward)
    {
        totalPlayerXP += xpReward;
        // check a few times in case he leveled up more than once
        for (int i = 0; i < 10; i++)
        {
            if (totalPlayerXP >= xpToNextLevel)
            {
                playerLevel++;
                xpToNextLevel *= 2.3f;
            }
        }       
    }
}

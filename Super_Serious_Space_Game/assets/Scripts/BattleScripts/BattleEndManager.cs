using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEndManager : MonoBehaviour {

    public GameObject playerGenerator;
    public GameObject enemyGenerator;

    private Generator playerGeneratorScript;
    private Generator enemyGeneratorScript;
    private LevelManager levelManager;

	// Use this for initialization
	void Start ()
    {
        playerGeneratorScript = playerGenerator.GetComponent<Generator>();
        enemyGeneratorScript = enemyGenerator.GetComponent<Generator>();
        levelManager = new LevelManager();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (enemyGeneratorScript.health <= 0)
        {
            SavedPlanetForBattleStatic.isConquered = true;
            SavedPlanetForBattleStatic.wasAttacked = true;
            BattleAISaverStatic.ReturnChildToOriginalParent();
            levelManager.LoadLevel("02a_Space");
        }

        if (playerGeneratorScript.health <= 0)
        {
            SavedPlanetForBattleStatic.isConquered = false;
            SavedPlanetForBattleStatic.wasAttacked = true;
            BattleAISaverStatic.ReturnChildToOriginalParent();
            levelManager.LoadLevel("02a_Space");
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBuilder : MonoBehaviour {

    public List<GameObject> playerResourcePositions;
    public List<GameObject> playerSpawnPodLocations;
    public List<GameObject> enemyResourcePositions;
    public List<GameObject> enemySpawnPodLocations;
    public List<GameObject> playerStartingMinerLocations;
    public List<GameObject> enemyStartingMinerLocations;
    public Resource resource;
    public GameObject miner;
    public GameObject playerSpawnPod;
    public GameObject enemySpawnPod;
    public GameObject battleUI;
    public GameObject playerBattleManager;
    public GameObject enemyBattleManager;

    private Resource[] playerSpawnedResources;
    private Vector3 randomPosition;
    private BattleUIManager battleUIManager;
    private PlayerBattleManager playerBattleManagerScript;
    private EnemyBattleManager enemyBattleManagerScript;
    private GameObject spaceSceneSaver;

	// Use this for initialization
	void Start ()
    {
        spaceSceneSaver = GameObject.Find("SpaceSceneSaver");
        spaceSceneSaver.SetActive(false);
        BuildResources();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnEnable()
    {
        
               
    }

    private void Awake()
    {
        battleUIManager = battleUI.GetComponent<BattleUIManager>();
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        enemyBattleManagerScript = enemyBattleManager.GetComponent<EnemyBattleManager>();
        PlacePlayerSpawnPods();
        PlaceEnemySpawnPods();
        PlacePlayerStartingMiners();
        PlaceEnemyStartingMiners();
       
    }

    private void BuildResources()
    {
        for (int i = 0; i < SavedPlanetForBattleStatic.resources.Count; i++)
        {
            if (SavedPlanetForBattleStatic.resources[i] == "Gold")
            {
                // players resource
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Gold");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Gold");

                // enemies resource
                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Gold");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Iron")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Iron");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Iron");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Iron");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Copper")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Copper");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Copper");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Copper");               
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Nickel")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Nickel");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Nickel");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Nickel");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Silver")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Silver");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Silver");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Silver");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Cobalt")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Cobalt");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Cobalt");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Cobalt");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Cadmium")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Cadmium");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Cadmium");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Cadmium");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Iridium")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Iridium");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Iridium");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Iridium");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
            else if (SavedPlanetForBattleStatic.resources[i] == "Paladium")
            {
                Resource playerResource = (Instantiate(resource, GetRandomResourcePosition("player"), Quaternion.identity));
                playerResource.BuildResourceObject("Paladium");
                playerResource.tag = "PlayerResource";
                battleUIManager.PlaceResourceMeter("Paladium");

                Resource enemyResource = (Instantiate(resource, GetRandomResourcePosition("enemy"), Quaternion.identity));
                enemyResource.BuildResourceObject("Paladium");
                enemyResource.tag = "EnemyResource";
                enemyBattleManagerScript.myEnemyResources.Add(enemyResource);
            }
        }
    }

    private Vector3 GetRandomResourcePosition(string playerOrEnemy)
    {
        if (playerOrEnemy == "player")
        {
            randomPosition = playerResourcePositions[Random.Range(0, playerResourcePositions.Count)].transform.position;
            for (int i = 0; i < playerResourcePositions.Count; i++)
            {
                if (randomPosition == playerResourcePositions[i].transform.position)
                {
                    playerResourcePositions.RemoveAt(i);
                }

            }
        }
        else if (playerOrEnemy == "enemy")
        {
            randomPosition = enemyResourcePositions[Random.Range(0, enemyResourcePositions.Count)].transform.position;
            for (int i = 0; i < enemyResourcePositions.Count; i++)
            {
                if (randomPosition == enemyResourcePositions[i].transform.position)
                {
                    enemyResourcePositions.RemoveAt(i);
                }

            }
        }
        return randomPosition;
    }

    private void PlacePlayerSpawnPods()
    {
        // spawn the players initial spawn pod at location 1
        GameObject newSpawnPod = Instantiate(playerSpawnPod, playerSpawnPodLocations[0].transform.position, Quaternion.identity);
        newSpawnPod.tag = "PlayerSpawnPod";
        playerBattleManagerScript.activeSpawnPodScripts.Add(newSpawnPod.GetComponent<SpawnPod>());
    }

    private void PlaceEnemySpawnPods()
    {
        // spawn the players initial spawn pod at location 1
        GameObject newSpawnPod = Instantiate(enemySpawnPod, enemySpawnPodLocations[0].transform.position, Quaternion.identity);
        newSpawnPod.tag = "EnemySpawnPod";
        enemyBattleManagerScript.activeSpawnPods.Add(newSpawnPod);
    }

    private void PlacePlayerStartingMiners()
    {
        Vector3 pos;
        // this 2 needs to be from PlayerGlobal.startingMiners; upgrade
        for (int i = 0; i < PlayerStatsUpgradesStatic.startingMiners; i++)
        {
            pos = playerStartingMinerLocations[i].transform.position;
            GameObject newMiner = Instantiate(miner, pos, Quaternion.identity);
            newMiner.tag = "PlayerMiner";
            playerStartingMinerLocations.RemoveAt(i);
        }
    }

    private void PlaceEnemyStartingMiners()
    {
        Vector3 pos;
        // this 2 needs to be from EnemyGlobal.startingMiners;
        for (int i = 0; i < SavedPlanetForBattleStatic.startingMiners; i++)
        {
            pos = enemyStartingMinerLocations[i].transform.position;
            GameObject newMiner = Instantiate(miner, pos, Quaternion.identity);
            newMiner.tag = "EnemyMiner";
            enemyStartingMinerLocations.RemoveAt(i);
        }
    }
}

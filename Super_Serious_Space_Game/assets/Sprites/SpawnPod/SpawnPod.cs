using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPod : MonoBehaviour {

    public bool imSpawningSomething;
    public bool isNewSpawnPod = false;
    public Slider progressBar;
    public GameObject buildingSpawnPodSprite;

    private GameObject playerBattleManager;
    private PlayerBattleManager playerBattleManagerScript;
    private UnitStats myStats;
    private SpriteRenderer spawnPodMainSprite;
    private Animator myAnimator;
    private GameObject mySpawningUnit;
    private float startTime;
    private float endTime;
    private bool timerStarted;
    private float newSpawnPodStartTimer = 0;
    private float newSpawnPodEndTimer;

	// Use this for initialization
	void Start ()
    {
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        myStats = GetComponent<UnitStats>();
        myAnimator = gameObject.GetComponent<Animator>();
        spawnPodMainSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isNewSpawnPod)
        {
            BuildNewSpawnPod();
        }

        if (!isNewSpawnPod)
        {
            if (imSpawningSomething)
            {
                myAnimator.SetBool("isSpawning", true);
            }
            else
            {
                myAnimator.SetBool("isSpawning", false);
            }

            if (mySpawningUnit != null)
            {
                if (timerStarted == true)
                {
                    if (StartTimer() == true)
                    {

                        GameObject newUnit = Instantiate(mySpawningUnit, transform.position, Quaternion.identity);
                        newUnit.SetActive(true);
                        // check the prefabs tag to see if it is a unit or a miner. Deault is always player.
                        if (mySpawningUnit.tag == "PlayerMiner")
                        {
                            // if this spawn pod is an enemy spawn pod then change the tag to enemy
                            if (gameObject.tag == "EnemySpawnPod")
                            {
                                // its an enemy miner spawning
                                newUnit.tag = "EnemyMiner";
                            }
                        }
                        if (mySpawningUnit.tag == "PlayerUnit")
                        {
                            if (gameObject.tag == "EnemySpawnPod")
                            {
                                newUnit.tag = "EnemyUnit";
                            }
                        }

                        // otherwise use the deafault player tags

                        timerStarted = false;
                        startTime = 0;
                        imSpawningSomething = false;
                        mySpawningUnit = null;
                    }
                }
            }
        }
    }

    private void BuildNewSpawnPod()
    {
        newSpawnPodEndTimer = (myStats.unitBuildTime - SpawnerStatsUpgradesStatic.spawnPodBuildTimeUpgrade);
        // need to disable the main spawn pod sprite
        spawnPodMainSprite.enabled = false;
        // need to enable the building spawn pod sprite
        buildingSpawnPodSprite.SetActive(true);
        // after the cooldown make isNewSpawnPodFalse
        if (StartNewSpawnPodTimer())
        {
            // disable building spawn pod sprite
            buildingSpawnPodSprite.SetActive(false);
            // enable main spawn pod sprite
            spawnPodMainSprite.enabled = true;
            // add spawn pod to players spawn pod list
            playerBattleManagerScript.activeSpawnPodScripts.Add(gameObject.GetComponent<SpawnPod>());
            isNewSpawnPod = false;
        }
    }

    public void GiveSpawnPodUnit(GameObject spawningUnit, float buildTime)
    {
        timerStarted = true;
        imSpawningSomething = true;
        mySpawningUnit = spawningUnit;
        endTime = buildTime;
        progressBar.maxValue = buildTime;
    }

    private bool StartNewSpawnPodTimer()
    {
        if (newSpawnPodStartTimer < newSpawnPodEndTimer)
        {
            newSpawnPodStartTimer += Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool StartTimer()
    {
        if (startTime < endTime)
        {
            startTime += Time.deltaTime;
            progressBar.value = startTime;
            return false;
        }       
        else
        {
            return true;
        }
    }
}

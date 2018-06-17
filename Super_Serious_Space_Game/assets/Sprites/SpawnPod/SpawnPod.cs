using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPod : MonoBehaviour {

    public bool imSpawningSomething;
    public Slider progressBar;
    
    private Animator myAnimator;
    private GameObject mySpawningUnit;
    private float startTime;
    private float endTime;
    private bool timerStarted;

	// Use this for initialization
	void Start ()
    {
        myAnimator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
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

    public void GiveSpawnPodUnit(GameObject spawningUnit, float buildTime)
    {
        timerStarted = true;
        imSpawningSomething = true;
        mySpawningUnit = spawningUnit;
        endTime = buildTime;
        progressBar.maxValue = buildTime;
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

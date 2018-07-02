using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {

    public GameObject planet;
    public List<GameObject> spawnedPlanets;
    
    

    private PlanetBuilder planetBuilder;

	// Use this for initialization
	void Start ()
    {
        planetBuilder = GetComponent<PlanetBuilder>();
        spawnedPlanets = new List<GameObject>();      
        SpawnHomePlanet();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void SpawnHomePlanet()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        GameObject homePlanet = Instantiate(planet, spawnPosition, Quaternion.identity);
        homePlanet.tag = "HomePlanet";
        PlanetInformation planetInfo = homePlanet.GetComponent<PlanetInformation>();
        SpriteRenderer spriteRenderer = homePlanet.GetComponent<SpriteRenderer>();
        planetInfo.planetSprite = PlayerInfoStatic.HomePlanetSprite;
        spriteRenderer.sprite = planetInfo.planetSprite;
        planetInfo.planetName = "Home Planet";
        planetInfo.isScanned = true;
        planetInfo.type = PlayerInfoStatic.HomePlanetType;
        homePlanet.transform.SetParent(GameObject.Find("SpaceSceneSaver").transform);
        spawnedPlanets.Add(homePlanet);

        // spawn the starting planets after spawning the home planet
        SpawnStartingPlanets(homePlanet);
    }

    private void SpawnStartingPlanets(GameObject originPlanet)
    {
        // put the possible spawn positions into an array
        Vector3[] possibleSpawnPositions = new Vector3[48];     

        for (int i = 0; i < originPlanet.transform.childCount - 1; i++)
        {
            // need to make sure this one child doesnt get added to the array
            if (originPlanet.transform.GetChild(i).name != "ConqueredLostSpriteHolder")
            {
                possibleSpawnPositions[i] = originPlanet.transform.GetChild(i).position;
            }
        }

        // get a random amount of spawn positions
        int minPlanets = 2;
        int maxPlanets = 6;
        int randomTotal = Random.Range(minPlanets, maxPlanets);

        // find a random open position and spawn there the randomTotal amount of times
        for (int i = 0; i < randomTotal; i++)
        {
            Vector3 mySpawnPosition = new Vector3(1, 1, 1);
            Vector3 defaultPosition = new Vector3(1, 1, 1);
            // while GetRandomPosition is failing keep trying until you get an open position

            while (mySpawnPosition == defaultPosition)
            {
                mySpawnPosition = GetRandomPosition(possibleSpawnPositions);
            }

            // we found an open position now spawn a random planet
            //mySpawnPosition = defaultPosition;
            GameObject newPlanet = Instantiate(planet, mySpawnPosition, Quaternion.identity);
            newPlanet.transform.SetParent(GameObject.Find("SpaceSceneSaver").transform);
            spawnedPlanets.Add(newPlanet);
            PlanetInformation planetInfo = newPlanet.GetComponent<PlanetInformation>();
            planetInfo.planetName = planetBuilder.GetRandomPlanetName();
            planetInfo.type = planetBuilder.GetPlanetType();
            planetInfo.planetAI = Instantiate(planetBuilder.GetPlanetAI());
            planetInfo.planetAI.transform.SetParent(planetInfo.transform);
            planetInfo.planetAI.SetActive(false);
            AIInformation aiInfo = planetInfo.planetAI.GetComponent<AIInformation>();
            planetInfo.difficulty = aiInfo.aiPowerLevel.ToString();                    
            planetInfo.negativeEffect = planetBuilder.GetPlanetNegativeEffect(planetInfo.type);
            planetInfo.planetSprite = planetBuilder.GetPlanetSprite(planetInfo.type);

            // manditory gold resource
            planetInfo.resources.Add("Gold");
            for (int r = 0; r < 3; r++)
            {
                planetInfo.resources.Add(planetBuilder.GetPlanetResources(planetInfo.planetPowerLevel));
            }

            newPlanet.GetComponent<SpriteRenderer>().sprite = planetInfo.unknownPlanetSprite;
        }
    }

    public void SpawnNewPlanets(GameObject originPlanet)
    {
        // put the possible spawn positions into an array
        Vector3[] possibleSpawnPositions = new Vector3[48];

        for (int i = 0; i < originPlanet.transform.childCount - 1; i++)
        {
            // need to make sure this one child doesnt get added to the array
            if (originPlanet.transform.GetChild(i).name != "ConqueredLostSpriteHolder")
            {
                possibleSpawnPositions[i] = originPlanet.transform.GetChild(i).position;
            }
        }

        // get a random amount of spawn positions
        int minPlanets = 2;
        int maxPlanets = 6;
        int randomTotal = Random.Range(minPlanets, maxPlanets);

        // find a random open position and spawn there the randomTotal amount of times
        for (int i = 0; i < randomTotal; i++)
        {
            Vector3 mySpawnPosition = new Vector3(1, 1, 1);
            Vector3 defaultPosition = new Vector3(1, 1, 1);
            // while GetRandomPosition is failing keep trying until you get an open position

            while (mySpawnPosition == defaultPosition)
            {
                mySpawnPosition = GetRandomPosition(possibleSpawnPositions);
            }

            // we found an open position now spawn a random planet
            //mySpawnPosition = defaultPosition;
            GameObject newPlanet = Instantiate(planet, mySpawnPosition, Quaternion.identity);
            newPlanet.transform.SetParent(GameObject.Find("SpaceSceneSaver").transform);
            spawnedPlanets.Add(newPlanet);
            PlanetInformation planetInfo = newPlanet.GetComponent<PlanetInformation>();
            planetInfo.planetName = planetBuilder.GetRandomPlanetName();
            planetInfo.type = planetBuilder.GetPlanetType();
            planetInfo.planetAI = Instantiate(planetBuilder.GetPlanetAI());
            planetInfo.planetAI.transform.SetParent(planetInfo.transform);
            planetInfo.planetAI.SetActive(false);
            AIInformation aiInfo = planetInfo.planetAI.GetComponent<AIInformation>();
            planetInfo.planetPowerLevel = aiInfo.aiPowerLevel;
            planetInfo.difficulty = planetInfo.planetPowerLevel.ToString();          
            planetInfo.negativeEffect = planetBuilder.GetPlanetNegativeEffect(planetInfo.type);
            planetInfo.planetSprite = planetBuilder.GetPlanetSprite(planetInfo.type);

            // manditory gold resource
            planetInfo.resources.Add("Gold");
            for (int r = 0; r < 3; r++)
            {
                planetInfo.resources.Add(planetBuilder.GetPlanetResources(planetInfo.planetPowerLevel));
            }

            newPlanet.GetComponent<SpriteRenderer>().sprite = planetInfo.unknownPlanetSprite;
        }
    }

    private Vector3 GetRandomPosition(Vector3[] position)
    {
        bool planetAlreadyExists = false;
        Vector3 badPosition = new Vector3(1, 1, 1);
        int maxRange = position.Length;
        int randomPosition = Random.Range(0, maxRange);

        // check the already spawned planets to see if the position is still open

        for (int i = 0; i < spawnedPlanets.Count; i++)
        {            
            float distance = Vector3.Distance(spawnedPlanets[i].transform.position, position[randomPosition]);

            if (spawnedPlanets[i].transform.position == position[randomPosition])
            {
                planetAlreadyExists = true;
                break;
            }
        }
        

        // if the position is open then return the position
        if (planetAlreadyExists)
        {
            return badPosition;            
        }
        else
        {
            return position[randomPosition];
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBuilder : MonoBehaviour {

    
    public Sprite[] planetSprites;
    public GameObject playerShip;
    public List<GameObject> possibleAI;

    private List<string> possibleResourceTypes;
    private List<string> possiblePlanetTypes;
    private GameObject theHomePlanet;

    private void Start()
    {
        
    }

    private void Awake()
    {
        theHomePlanet = GameObject.FindGameObjectWithTag("HomePlanet");
        possibleResourceTypes = new List<string>();
        possiblePlanetTypes = new List<string>();
        BuildPossiblePlanetTypes();
        BuildPossibleResourceTypes();    
    }

    public string GetRandomPlanetName()
    {
        // need to generate a ton of random planet names. I think ill keep them on a separate script and call them here
        return "Random Planet Name";
    }

    public string GetPlanetDifficulty()
    {
        theHomePlanet = GameObject.FindGameObjectWithTag("HomePlanet");

        float distance = 0f;
        float difficultyScore = 0f;

        string difficulty = "";

        if (theHomePlanet != null)
        {
            distance = Vector3.Distance(theHomePlanet.transform.position, playerShip.transform.position);
            difficultyScore = BuildAIDifficultyScore();
        }
        else
        {
            distance = 0f;
        }

        if (difficultyScore <= 5f)
        {
            difficulty = "Very Easy";
        }
        else if (difficultyScore <= 10f)
        {
            difficulty = "Easy";
        }
        else if (difficultyScore <= 15f)
        {
            difficulty = "Medium";
        }
        else if (difficultyScore <= 20f)
        {
            difficulty = "Hard";
        }
        else
        {
            difficulty = "Very Hard";
        }
        // need to figure out how to calculate the planets difficulty. 
        // base it on the ai, his buffs, his units, distance from home planet etc.
        return difficulty;
    }

    public GameObject GetPlanetAI()
    {
        // determine the ai based on how far the ship has traveled
        return possibleAI[0];
    }

    public string GetPlanetType()
    {
        int random;
        float distance;

        // as you get further away from the home planet other planet types can start spawning.
        // could include a hidden player level to help determine if they ready?
        // need to spawn a space hub too if one hasnt spawned in a long time
        if (theHomePlanet != null)
        {
            distance = Vector3.Distance(theHomePlanet.transform.position, playerShip.transform.position);
        }
        else
        {
            distance = 0f;
        }
        if (distance <= 25)
        {
            random = Random.Range(0, 2);            
        }
        else if (distance <= 50)
        {
            random = Random.Range(0, 4);
        }
        else if (distance <= 100)
        {
            random = Random.Range(0, 6);
        }
        else
        {
            random = Random.Range(1, 6);
        }

        return possiblePlanetTypes[random];
    }

    public string GetPlanetNegativeEffect(string planetType)
    {
        if (planetType == "Temperate")
        {
            return "No negative effects";
        }
        else if (planetType == "Tropical")
        {
            return "Max unit capacity reduced";
        }
        else if (planetType == "Tundra")
        {
            return "Units move slower";
        }
        else if (planetType == "Desert")
        {
            return "Less unit health";
        }
        else if (planetType == "Volcanic")
        {
            return "Units cost more";
        }
        else if (planetType == "SpaceHub")
        {
            return "Buy shit";
        }
        else
        {
            return "finish this shit hit else";
        }
    }



    public Sprite GetPlanetSprite(string planetType)
    {
        if (planetType == "Temperate")
        {
            return planetSprites[0];
        }
        else if (planetType == "Tropical")
        {
            return planetSprites[1];
        }
        else if (planetType == "Tundra")
        {
            return planetSprites[2];
        }
        else if (planetType == "Desert")
        {
            return planetSprites[3];
        }
        else if (planetType == "Volcanic")
        {
            return planetSprites[4];
        }
        else
        {
            return planetSprites[5];
        }        
    }

    public string GetPlanetResources(string planetDifficulty)
    {
        int random;

        // need to add different types of resources based on difficulty and distance n such
        if (planetDifficulty == "Very Easy")
        {
            random = Random.Range(0, 3);
        }
        else if (planetDifficulty == "Easy")
        {
            random = Random.Range(0, 4);
        }
        else if (planetDifficulty == "Medium")
        {
            random = Random.Range(0, 6);
        }
        else if (planetDifficulty == "Hard")
        {
            random = Random.Range(0, 8);
        }
        else if (planetDifficulty == "Very Hard")
        {
            random = Random.Range(0, 8);
        }
        else
        {
            random = 0;
            Debug.Log("GetPlanetResourses hit else");
        }

        return possibleResourceTypes[random];
    }

    private float BuildAIDifficultyScore()
    {
        float score = (CurrentAIStatsStatic.aiMaxMinerCount + CurrentAIStatsStatic.aiMaxUnitCount + CurrentAIStatsStatic.aiPossibleUnitsCount) * CurrentAIStatsStatic.aiStrongUnitsCount;

        return score;
    }

    private void BuildPossiblePlanetTypes()
    {
        possiblePlanetTypes.Add("Temperate");
        possiblePlanetTypes.Add("Tropical");
        possiblePlanetTypes.Add("Tundra");
        possiblePlanetTypes.Add("Desert");
        possiblePlanetTypes.Add("Volcanic");
        possiblePlanetTypes.Add("SpaceHub");
    }

    private void BuildPossibleResourceTypes()
    {
        possibleResourceTypes.Add("Gold");
        possibleResourceTypes.Add("Iron");
        possibleResourceTypes.Add("Copper");
        possibleResourceTypes.Add("Nickel");
        possibleResourceTypes.Add("Silver");
        possibleResourceTypes.Add("Cobalt");
        possibleResourceTypes.Add("Cadmium");
        possibleResourceTypes.Add("Iridium");
        possibleResourceTypes.Add("Paladium");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

    public List<GameObject> resourceMeterLocations;
    public GameObject resourceMeter;
    public GameObject mainUIBackground;
    public GameObject playerBattleManager;

    private List<string> existingResourceMeters;
    private bool resourceMeterExists;
    private PlayerBattleManager playerBattleManagerScript;
    private List<ResourceMeter> spawnedResourceMeters;

    // Use this for initialization
    void Start ()
    {
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();       
	}

    void Awake()
    {
        existingResourceMeters = new List<string>();
        spawnedResourceMeters = new List<ResourceMeter>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateResourceMeters();
	}

    public void PlaceResourceMeter(string resourceName)
    {
        resourceMeterExists = false;

        if (existingResourceMeters != null && existingResourceMeters.Count != 0)
        {
            foreach (string resourceType in existingResourceMeters)
            {
                if (resourceType == resourceName)
                {
                    resourceMeterExists = true;
                }
            }
        }

        if (resourceMeterExists == false)
        {
            existingResourceMeters.Add(resourceName);
            BuildResourceMeter(resourceName);            
        }
    }

    private void UpdateResourceMeters()
    {
        if (spawnedResourceMeters != null)
        {
            int resource;
            for (int i = 0; i < spawnedResourceMeters.Count; i++)
            {
                if (spawnedResourceMeters[i].resourceType == "Gold")
                {
                    resource = 0;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[0];
                }
                else if (spawnedResourceMeters[i].resourceType == "Iron")
                {
                    resource = 1;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[1];
                }
                else if (spawnedResourceMeters[i].resourceType == "Copper")
                {
                    resource = 2;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[2];
                }
                else if (spawnedResourceMeters[i].resourceType == "Nickel")
                {
                    resource = 3;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[3];
                }
                else if (spawnedResourceMeters[i].resourceType == "Silver")
                {
                    resource = 4;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[4];
                }
                else if (spawnedResourceMeters[i].resourceType == "Cobalt")
                {
                    resource = 5;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[5];
                }
                else if (spawnedResourceMeters[i].resourceType == "Cadmium")
                {
                    resource = 6;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[6];
                }
                else if (spawnedResourceMeters[i].resourceType == "Iridium")
                {
                    resource = 7;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[7];
                }
                else if (spawnedResourceMeters[i].resourceType == "Paladium")
                {
                    resource = 8;
                    spawnedResourceMeters[i].resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                    spawnedResourceMeters[i].resourceSlider.value = playerBattleManagerScript.playerResourcesAmount[resource];
                    spawnedResourceMeters[i].resourceSlider.maxValue = PlayerStatsUpgradesStatic.maxResourceAmounts[8];
                }
            }
        }
    }

    private void BuildResourceMeter(string name)
    {
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        int resource;

        if (name == "Gold")
        {
            resource = 0;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];                
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Gold";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Iron")
        {
            resource = 1;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Iron";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Copper")
        {
            resource = 2;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Copper";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Nickel")
        {
            resource = 3;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Nickel";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Silver")
        {
            resource = 4;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Silver";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Cobalt")
        {
            resource = 5;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Cobalt";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Cadmium")
        {
            resource = 6;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Cadmium";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Iridium")
        {
            resource = 7;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Iridium";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
        else if (name == "Paladium")
        {
            resource = 8;
            for (int i = 0; i < resourceMeterLocations.Count; i++)
            {
                GameObject newResourceMeter = Instantiate(resourceMeter, resourceMeterLocations[i].transform.position, Quaternion.identity);
                newResourceMeter.transform.SetParent(mainUIBackground.transform);
                newResourceMeter.transform.localScale = new Vector3(1, 1, 1);
                ResourceMeter myResourceMeter = newResourceMeter.GetComponent<ResourceMeter>();
                myResourceMeter.sliderFillSprite.sprite = myResourceMeter.resourceFill[resource];
                myResourceMeter.resourceFrontSprite.GetComponent<Image>().sprite = myResourceMeter.resourceFront[resource];
                myResourceMeter.resourceAmount.text = playerBattleManagerScript.playerResourcesAmount[resource].ToString();
                myResourceMeter.resourceType = "Paladium";
                spawnedResourceMeters.Add(myResourceMeter);
                resourceMeterLocations.RemoveAt(i);
                break;
            }
        }
    }
}

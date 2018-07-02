using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : MonoBehaviour {

    public GameObject defendArea;
    
    public GameObject selectedMiner;
    public GameObject selectedUnit;
    public List<GameObject> spawnerLocations;
    public SpawnPod spawnPod;
    public List<SpawnPod> activeSpawnPodScripts;
    public List<GameObject> myPlayerMiners;
    public List<GameObject> mySpawnedUnits;

    public int[] playerResourcesAmount;
    public string[] playerResourcesType;

    public int spawnPodCount;
    public int spawnedUnitsCapacityCount;

    // used for movement state machine when player clicks action buttons
    public bool playerAttacking;
    public bool playerDefending;
    public bool playerFallBack;

    private SpriteRenderer defendAreaSprite;
    private BoxCollider2D defendAreaCollider;
    private RetrieveUnitUpgrades retrieveUpgrades;


    // Use this for initialization
    void Start ()
    {
        defendAreaSprite = defendArea.GetComponent<SpriteRenderer>();
        defendAreaCollider = defendArea.GetComponent<BoxCollider2D>();
        retrieveUpgrades = new RetrieveUnitUpgrades();

        // start the battle in defending mode
        SetDefending();
    }
	
	// Update is called once per frame                           
	void Update ()
    {
        GetSpawnPodCount();
        SelectAndMoveMiner();
        SelectAndMoveUnit();
        GetPlayerResourceCaps();
	}

    void Awake()
    {
        activeSpawnPodScripts = new List<SpawnPod>();
        spawnedUnitsCapacityCount = 0;
    }

    private void GetSpawnPodCount()
    {
        spawnPodCount = 0;
        foreach (SpawnPod spawnPod in activeSpawnPodScripts)
        {
            if (!spawnPod.imSpawningSomething)
            {
                spawnPodCount++;
            }
            else
            {
                spawnPodCount--;
            }
        }
    }

    public void SpawnPlayerUnit(GameObject unitToSpawn, float spawnTime, int unitCost)
    {
        for (int i = 0; i < activeSpawnPodScripts.Count; i++)
        {
            if (!activeSpawnPodScripts[i].imSpawningSomething)
            {
                SubtractResource(unitToSpawn, unitCost);
                activeSpawnPodScripts[i].GiveSpawnPodUnit(unitToSpawn, spawnTime);
            }
        }
    }

    private void SubtractResource(GameObject myUnit, int unitCost)
    {
        UnitStats myStats = myUnit.GetComponent<UnitStats>();
        unitCost -= retrieveUpgrades.GetUnitResourceDiscount(myStats.unitName);
        int resource;
        if (myStats.unitResourceType == "Gold")
        {
            resource = 0;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Iron")
        {
            resource = 1;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Copper")
        {
            resource = 2;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Nickel")
        {
            resource = 3;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Silver")
        {
            resource = 4;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Cobalt")
        {
            resource = 5;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Cadmium")
        {
            resource = 6;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Iridium")
        {
            resource = 7;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Paladium")
        {
            resource = 8;
            playerResourcesAmount[resource] -= unitCost;
        }
        else if (myStats.unitResourceType == "Power")
        {
            PlayerInfoStatic.CurrentShipPower -= unitCost;
        }
            
    }

    private void SelectAndMoveMiner()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.queriesHitTriggers = false;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Physics2D.queriesHitTriggers = true;

            if (hit.collider != null)
            {
                if (hit.collider.transform.gameObject.tag == "PlayerMiner")
                {
                    // if I selected a new miner then remove the icon from old miner
                    if (selectedMiner != null && selectedMiner != hit.collider.transform.gameObject)
                    {
                        GameObject newChildSprite = selectedMiner.transform.GetChild(0).gameObject;
                        SpriteRenderer newChangeSprite = newChildSprite.GetComponent<SpriteRenderer>();
                        Color newAlpha = newChangeSprite.color;
                        newAlpha.a = 0;
                        newChangeSprite.color = newAlpha;
                    }

                    // then apply icon to the new miner
                    selectedMiner = hit.collider.transform.gameObject;
                    GameObject childSprite = selectedMiner.transform.GetChild(0).gameObject;
                    SpriteRenderer changeSprite = childSprite.GetComponent<SpriteRenderer>();
                    Color alpha = changeSprite.color;
                    alpha.a = 255;
                    changeSprite.color = alpha;
                    
                }
                else if (hit.collider.transform.gameObject.tag == "PlayerResource" && selectedMiner != null)
                {
                    MoveToNode moveMiner = selectedMiner.GetComponent<MoveToNode>();
                    moveMiner.myResource = hit.collider.transform.gameObject;
                    moveMiner.isMovingToNode = true;
                }
            }
            else
            {
                if (selectedMiner != null)
                {
                    GameObject childSprite = selectedMiner.transform.GetChild(0).gameObject;
                    SpriteRenderer changeSprite = childSprite.GetComponent<SpriteRenderer>();
                    Color alpha = changeSprite.color;
                    alpha.a = 0;
                    changeSprite.color = alpha;
                    selectedMiner = null;
                    
                }
            }
        }
    }

    public void EnableDisableDefendArea(string enableDisable)
    {
        if (enableDisable == "enable")
        {
            defendAreaSprite.enabled = true;
            defendAreaCollider.enabled = true;
        }
        else
        {
            defendAreaSprite.enabled = false;
            defendAreaCollider.enabled = false;
        }
    }

    private void SelectAndMoveUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.queriesHitTriggers = false;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Physics2D.queriesHitTriggers = true; 

            if (hit.collider != null && !hit.transform.gameObject.name.Contains("Turret"))
            {
                if (hit.collider.transform.gameObject.tag == "PlayerUnit")
                {
                    if (selectedUnit != null && selectedUnit != hit.collider.transform.gameObject)
                    {
                        GameObject newChildSprite = selectedUnit.transform.GetChild(0).gameObject;
                        SpriteRenderer newChangeSprite = newChildSprite.GetComponent<SpriteRenderer>();
                        Color newAlpha = newChangeSprite.color;
                        newAlpha.a = 0;
                        newChangeSprite.color = newAlpha;
                    }

                    selectedUnit = hit.collider.transform.gameObject;
                    GameObject childSprite = selectedUnit.transform.GetChild(0).gameObject;
                    SpriteRenderer changeSprite = childSprite.GetComponent<SpriteRenderer>();
                    Color alpha = changeSprite.color;
                    alpha.a = 255;
                    changeSprite.color = alpha;
                    defendAreaSprite.enabled = true;
                    defendAreaCollider.enabled = true;
                }
                else if (hit.transform.gameObject.name == "PlayerDefendArea")
                {
                    if (selectedUnit != null)
                    {
                        BasicMovementController unitMoveController = selectedUnit.GetComponent<BasicMovementController>();
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        newPosition.z = -1;
                        unitMoveController.newDefendPosition = newPosition;
                        unitMoveController.haveNewPosition = true;
                    }
                }
            }
            else
            {
                if (selectedUnit != null && hit.transform == null)
                {
                    GameObject childSprite = selectedUnit.transform.GetChild(0).gameObject;
                    SpriteRenderer changeSprite = childSprite.GetComponent<SpriteRenderer>();
                    Color alpha = changeSprite.color;
                    alpha.a = 0;
                    changeSprite.color = alpha;
                    selectedUnit = null;
                    defendAreaSprite.enabled = false;
                    defendAreaCollider.enabled = false;
                }
            }
        }
    }

    public void SetDefending()
    {
        playerDefending = true;
        playerAttacking = false;
        playerFallBack = false;        
    }

    public void SetAttacking()
    {
        playerDefending = false;
        playerAttacking = true;
        playerFallBack = false;
    }

    public void SetFallBack()
    {
        playerDefending = false;
        playerAttacking = false;
        playerFallBack = true;
    }

    private void GetPlayerResourceCaps()
    {
        for (int i = 0; i < playerResourcesAmount.Length; i++)
        {
            if (playerResourcesAmount[i] > PlayerStatsUpgradesStatic.maxResourceAmounts[i])
            {
                playerResourcesAmount[i] = PlayerStatsUpgradesStatic.maxResourceAmounts[i];
            }
        }
    }
}

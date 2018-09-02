using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretButton : MonoBehaviour {
    public GameObject myUnit;
    public GameObject myTempUnit;
    public GameObject playerBattleManager;
    public Image cooldownImage;
    public Text myCostText;

    private PlayerBattleManager playerBattleManagerScript;
    private UnitStats myStats;
    private Button myButton;
    private float playerResourceAmountMyResource;
    private float startBuilTime;
    private bool isOnCooldown;
    private int myUnitCost;
    private int myCooldownTimer;
    private GameObject mySpawningTurret;
    private Turret mySpawningTurretScript;
    private bool turretIsSlectedToSpawn;

    // Use this for initialization
    void Start()
    {
        mySpawningTurret = null;
        turretIsSlectedToSpawn = false;
        myStats = myUnit.GetComponent<UnitStats>();
        myButton = gameObject.GetComponent<Button>();
        playerBattleManager = GameObject.Find("PlayerBattleManager");
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();

        // need to set all of my variables based on any upgrades the unit might have
        myUnitCost = myStats.unitCost;
        myCooldownTimer = (myStats.unitBuildTime - ShipStatsUpgradesStatic.turretCooldownReduction);

        myCostText.text = (myUnitCost - ShipStatsUpgradesStatic.turretResourceDiscount).ToString();


        // button starts on cooldown
        isOnCooldown = true;
        startBuilTime = 0;
        cooldownImage.fillAmount = 1;
        myButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerResourceAmountMyResource = PlayerInfoStatic.CurrentShipPower;

        if (isOnCooldown)
        {
            if (StartButtonCooldown())
            {
                myButton.interactable = true;
                isOnCooldown = false;
                cooldownImage.fillAmount = 0;
            }
        }
        else
        {
            DisableOrEnableButton();
        }

        if (turretIsSlectedToSpawn)
        {
            TurretFollowMouse();
        }
    }

    public void SelectTurretToSpawn()
    {
        turretIsSlectedToSpawn = true;
        playerBattleManagerScript.EnableDisableDefendArea("enable");
        mySpawningTurret = Instantiate(myTempUnit, transform.position, Quaternion.identity);        
    }

    private void TurretFollowMouse()
    {
        mySpawningTurret.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lockZ = mySpawningTurret.transform.position;
        lockZ.z = 0;
        mySpawningTurret.transform.position = lockZ;

        if (Input.GetMouseButtonDown(0))
        {
            Physics2D.queriesHitTriggers = false;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Physics2D.queriesHitTriggers = true;

            if (hit.collider != null && hit.transform.gameObject.name == "PlayerDefendArea")
            {                
                GameObject newTurret = Instantiate(myUnit, mySpawningTurret.transform.position, Quaternion.identity);
                playerBattleManagerScript.EnableDisableDefendArea("disable");
                turretIsSlectedToSpawn = false;
                Destroy(mySpawningTurret);
                isOnCooldown = true;
                myButton.interactable = false;
                cooldownImage.fillAmount = 1;
            }
            else
            {
                turretIsSlectedToSpawn = false;
                Destroy(mySpawningTurret);
                playerBattleManagerScript.EnableDisableDefendArea("disable");
            }
        }
    }

    public void SpawnUnit()
    {
        if (playerResourceAmountMyResource >= myUnitCost)
        {
            startBuilTime = 0;
            cooldownImage.fillAmount = 1;
            isOnCooldown = true;
            playerBattleManagerScript.SpawnPlayerUnit(myUnit, myCooldownTimer, myUnitCost);
            myButton.interactable = false;
        }
    }

    private bool StartButtonCooldown()
    {
        startBuilTime += Time.deltaTime;
        if (startBuilTime >= myCooldownTimer)
        {
            startBuilTime = 0;
            return true;
        }
        else
        {
            cooldownImage.fillAmount -= Time.deltaTime / myCooldownTimer;
            return false;
        }
    }

    private void DisableOrEnableButton()
    {
        if (playerResourceAmountMyResource >= myUnitCost)
        {
            myButton.interactable = true;
        }
        else
        {
            myButton.interactable = false;
        }
    }
}

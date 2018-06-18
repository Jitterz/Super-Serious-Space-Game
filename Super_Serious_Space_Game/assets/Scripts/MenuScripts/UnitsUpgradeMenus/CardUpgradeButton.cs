using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUpgradeButton : MonoBehaviour {

    public UnitUpgradePanelController upgradePanelController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpgradeClicked(string buttonName)
    {
        UnitStats stats = UnitUpgradePanelController.SelectedCard.GetComponent<UnitStats>();

        if (buttonName == "Btn_UpgradeDamage")
        {
            if (stats.unitDamage < stats.unitDamageMax)
            {
                stats.unitDamage += 1;
                if (stats.unitDamage >= stats.unitDamageMax)
                {
                    stats.unitDamage = stats.unitDamageMax;
                }
            }
        }
        else if (buttonName == "Btn_UpgradeHealth")
        {
            if (stats.health < stats.healthMax)
            {
                stats.health += 5;
                if (stats.health >= stats.healthMax)
                {
                    stats.health = stats.healthMax;
                }
            }
        }
        else if (buttonName == "Btn_UpgradeAttackSpeed")
        {
            if (stats.unitAttackSpeed > stats.attackSpeedMax)
            {
                stats.unitAttackSpeed -= 0.2f;
                if (stats.unitAttackSpeed <= stats.attackSpeedMax)
                {
                    stats.unitAttackSpeed = stats.attackSpeedMax;
                }
            }
        }
        else if (buttonName == "Btn_UpgradeMoveSpeed")
        {
            if (stats.unitMoveSpeed < stats.moveSpeedMax)
            {
                stats.unitMoveSpeed += 2;
                if (stats.unitMoveSpeed >= stats.moveSpeedMax)
                {
                    stats.unitMoveSpeed = stats.moveSpeedMax;
                }
            }
        }
        else if (buttonName == "Btn_UpgradeBuildTime")
        {
            if (stats.unitBuildTime > stats.unitBuildTimeMax)
            {
                stats.unitBuildTime -= 1;
                if (stats.unitBuildTime <= stats.unitBuildTimeMax)
                {
                    stats.unitBuildTime = stats.unitBuildTimeMax;
                }
            }
        }
        else if (buttonName == "Btn_UpgradeResourceCost")
        {
            if (stats.unitCost > stats.unitCostMax)
            {
                stats.unitCost -= 5;
                if (stats.unitCost <= stats.unitCostMax)
                {
                    stats.unitCost = stats.unitCostMax;
                }
            }
        }

        EnableDisableUpgradeButtons(buttonName, stats);
        upgradePanelController.UpdateUpgradesPanel(UnitUpgradePanelController.SelectedCard);
    }

    public void EnableDisableUpgradeButtons(string buttonName, UnitStats stats)
    {
        if (buttonName == "Btn_UpgradeDamage")
        {
            if (stats.unitDamage >= stats.unitDamageMax)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (buttonName == "Btn_UpgradeHealth")
        {
            if (stats.health >= stats.healthMax)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (buttonName == "Btn_UpgradeAttackSpeed")
        {
            if (stats.unitAttackSpeed <= stats.attackSpeedMax)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (buttonName == "Btn_UpgradeMoveSpeed")
        {
            if (stats.unitMoveSpeed >= stats.moveSpeedMax)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (buttonName == "Btn_UpgradeBuildTime")
        {
            if (stats.unitBuildTime <= stats.unitBuildTimeMax)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (buttonName == "Btn_UpgradeAttackSpeed")
        {
            if (stats.unitAttackSpeed <= stats.attackSpeedMax)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        else if (buttonName == "Btn_UpgradeResourceCost")
        {
            if (stats.unitCost <= stats.unitCostMax)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}

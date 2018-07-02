using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitUpgradePanelController : MonoBehaviour
{

    public static GameObject SelectedCard;

    public GameObject panelControl;

    public Text unitName;
    public Text unitDescription;
    public Text nicknameText;
    public Text upgradeCostAmountText;

    public Image unitImage;
    public Image resourceImage;
    public List<string> possibleUnitTypes;
    public List<string> possibleResourceTypes;
    public List<Sprite> possibleUnitImages;
    public List<Sprite> possibleResourceImages;

    public InputField nicknameInput;

    public List<CardUpgradeButton> upgradeButtonsList;

    //Damage
    public Image damageFill;
    public Text damageUpgradeText;

    //Health
    public Image healthFill;
    public Text healthUpgradeText;

    //Attack Speed
    public Image attackSpeedFill;
    public Text attackSpeedUpgradeText;

    // Move Speed
    public Image moveSpeedFill;
    public Text moveSpeedUpgradeText;

    // Build time
    public Image buildTimeFill;
    public Text buildTimeUpgradeText;

    // Resource Cost
    public Image resourceCostFill;
    public Text resourceCostUpgradeText;

    // Use this for initialization
    void Start ()
    {
        nicknameInput.onValueChanged.AddListener(delegate { NickNameValueChanged(); });
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateUpgradesPanel(GameObject selectedObject)
    {
        SelectedCard = selectedObject;

        if (!panelControl.activeSelf)
        {
            panelControl.SetActive(true);
        }

        UnitStats stats = selectedObject.GetComponent<UnitStats>();
        unitName.text = stats.unitName;
        unitDescription.text = "TODO: Unit Description";

        if (stats.unitNickName != "")
        {
            nicknameText.text = stats.unitNickName;
        }

        upgradeCostAmountText.text = "Need an Amount";
        unitImage.sprite = GetUnitImage(stats);

        // Damage
        damageFill.fillAmount = (float)stats.unitDamage / (float)stats.unitDamageMax;
        Math.Round(damageFill.fillAmount, 3);
        damageUpgradeText.text = stats.unitDamage.ToString();

        // Health
        healthFill.fillAmount = (float)stats.health / (float)stats.healthMax;
        Math.Round(healthFill.fillAmount, 3);
        healthUpgradeText.text = stats.health.ToString();

        // Attack Speed
        attackSpeedFill.fillAmount = stats.attackSpeedMax / stats.unitAttackSpeed;
        Math.Round(attackSpeedFill.fillAmount, 3);
        attackSpeedUpgradeText.text = stats.unitAttackSpeed.ToString();

        // Move Speed
        moveSpeedFill.fillAmount = (float)stats.unitMoveSpeed / (float)stats.moveSpeedMax;
        Math.Round(moveSpeedFill.fillAmount, 3);
        moveSpeedUpgradeText.text = stats.unitMoveSpeed.ToString();

        // Build Time
        buildTimeFill.fillAmount = (float)stats.unitBuildTimeMax / (float)stats.unitBuildTime;
        Math.Round(buildTimeFill.fillAmount, 3);
        buildTimeUpgradeText.text = stats.unitBuildTime.ToString();

        // Resource Cost
        resourceCostFill.fillAmount = (float)stats.unitCostMax / (float)stats.unitCost;
        Math.Round(resourceCostFill.fillAmount, 3);
        resourceCostUpgradeText.text = stats.unitCost.ToString();

        resourceImage.sprite = GetResourceImage(stats);
        nicknameInput.text = stats.unitNickName;

        for (int i = 0; i < upgradeButtonsList.Count; i++)
        {
            upgradeButtonsList[i].EnableDisableUpgradeButtons(upgradeButtonsList[i].gameObject.name, stats);
        }
    }

    private Sprite GetUnitImage(UnitStats stats)
    {
        Sprite selectedSprite = null;

        for (int i = 0; i < possibleUnitImages.Count; i++)
        {
            if (possibleUnitTypes[i] == stats.unitName)
            {
                selectedSprite = possibleUnitImages[i];
                break;
            }
            else
            {
                selectedSprite = null;
            }
        }

        return selectedSprite;
    }

    private Sprite GetResourceImage(UnitStats stats)
    {
        Sprite resourceSprite = null;

        for (int i = 0; i < possibleResourceImages.Count; i++)
        {
            if (possibleResourceTypes[i] == stats.unitResourceType)
            {
                resourceSprite = possibleResourceImages[i];
                break;
            }
            else
            {
                resourceSprite = null;
            }
        }

        return resourceSprite;
    }

    private void NickNameValueChanged()
    {
        SelectedCard.GetComponent<UnitStats>().unitNickName = nicknameInput.text;
    }
}

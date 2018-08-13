using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHidePlayerUpgrades : MonoBehaviour {

    public GameObject hidePanel;
    public Button myUpgradeButton;
    public int myUpgradeCost;
    public bool upgradeMaxed;
    public bool isCredits;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (isCredits)
        {
            EnableDisablePanelCredits();
        }
        else
        {
            EnableDisablePanelXP();
        }
    }

    private void EnableDisablePanelXP()
    {
        // disable the upgrade not enough XP
        if (myUpgradeCost > PlayerInfoStatic.CurrentXP && !upgradeMaxed)
        {
            hidePanel.SetActive(true);
            myUpgradeButton.enabled = true;
            myUpgradeButton.interactable = false;
        }
        else if (upgradeMaxed)
        {
            hidePanel.SetActive(false);
            myUpgradeButton.gameObject.SetActive(false);
            myUpgradeButton.interactable = false;
        }
        else
        {
            hidePanel.SetActive(false);
            myUpgradeButton.enabled = true;
            myUpgradeButton.interactable = true;
        }
    }

    private void EnableDisablePanelCredits()
    {
        // disable the upgrade not enough XP
        if (myUpgradeCost > PlayerInfoStatic.CurrentCredits && !upgradeMaxed)
        {
            hidePanel.SetActive(true);
            myUpgradeButton.enabled = true;
            myUpgradeButton.interactable = false;
        }
        else if (upgradeMaxed)
        {
            hidePanel.SetActive(false);
            myUpgradeButton.gameObject.SetActive(false);
            myUpgradeButton.interactable = false;
        }
        else
        {
            hidePanel.SetActive(false);
            myUpgradeButton.enabled = true;
            myUpgradeButton.interactable = true;
        }
    }
}

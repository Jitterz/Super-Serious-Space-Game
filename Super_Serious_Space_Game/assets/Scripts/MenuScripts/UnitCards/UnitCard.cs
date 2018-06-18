using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCard : MonoBehaviour {

    public int cardID;
    public Sprite[] unitImages;
    public Sprite[] resourceSprites;
    public Sprite[] cardBackgrounds;
    public List<string> resourceTypes;
    public List<string> unitTypes;

    public Image unitImage;
    public Image cardBackground;
    public Image resourceImage;

    public Text unitName;
    public Text nickName;
    public Text unitCapacity;
    public Text resourceCost;
    public Text cardLevel;

    public UnitUpgradePanelController upgradePanel;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ActivateUpgradePanel()
    {
        upgradePanel = GameObject.Find("UnitUpgradePanel").GetComponent<UnitUpgradePanelController>();
        upgradePanel.UpdateUpgradesPanel(gameObject);
    }
}

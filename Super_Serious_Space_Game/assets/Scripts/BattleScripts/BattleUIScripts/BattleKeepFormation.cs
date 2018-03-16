using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleKeepFormation : MonoBehaviour {

    public GameObject playerBattleManager;
    public Sprite toggleOffSprite;
    public Sprite toggleOnSprite;
    public Image toggleSprite;

    private PlayerBattleManager playerBattleManagerScript;
    private List<GameObject> myOriginalUnits;
    private Toggle myToggle;

	// Use this for initialization
	void Start ()
    {
        myToggle = GetComponent<Toggle>();
        playerBattleManagerScript = playerBattleManager.GetComponent<PlayerBattleManager>();
        myOriginalUnits = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetFormation()
    {
        if (myToggle.isOn)
        {
            toggleSprite.sprite = toggleOnSprite;
            myOriginalUnits.Clear();
            foreach (GameObject unit in playerBattleManagerScript.mySpawnedUnits)
            {
                if (unit != null)
                {
                    UnitStats unitStats = unit.GetComponent<UnitStats>();
                    myOriginalUnits.Add(unit);
                    unitStats.unitCurrentMoveSpeed = 30;
                }
            }
        }
        else
        {
            toggleSprite.sprite = toggleOffSprite;
            RemoveFormation();
        }
    }

    public void RemoveFormation()
    {
        foreach (GameObject unit in playerBattleManagerScript.mySpawnedUnits)
        {
            if (unit != null)
            {
                foreach (GameObject originalUnit in myOriginalUnits)
                {
                    if (originalUnit != null)
                    {
                        if (unit == originalUnit)
                        {
                            unit.GetComponent<UnitStats>().unitCurrentMoveSpeed = originalUnit.GetComponent<UnitStats>().unitMoveSpeed;
                            break;
                        }
                    }
                    else
                    {
                        myOriginalUnits.Remove(originalUnit);
                    }
                }
            }
        }
    }
}

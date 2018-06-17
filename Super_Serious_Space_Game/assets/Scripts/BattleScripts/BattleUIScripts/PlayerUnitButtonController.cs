using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitButtonController : MonoBehaviour {

    public List<GameObject> buttonPrefabs;
    public GameObject myUnit;
    public Sprite noUnitSprite;
    public int buttonNumber;

    private string myUnitsName;
    private Image defaultButtonImage;

	// Use this for initialization
	void Start ()
    {
        
	}

    private void Awake()
    {
        defaultButtonImage = GetComponent<Image>();
        BuildMyUnitButton();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void BuildMyUnitButton()
    {
        GetUnitsName();
        GetMyUnit();
        BuildAnPlaceMyUnitButton();
    }

    private void GetUnitsName()
    {
        myUnitsName = "";

        for (int i = 0; i <= PlayerInfoStatic.PlayerDeck.Count - 1; i++)
        {
            if (i == buttonNumber)
            {
                myUnitsName = PlayerInfoStatic.PlayerDeck[buttonNumber].GetComponent<UnitStats>().unitName;
            }
        }
    }

    private void GetMyUnit()
    {
        if (myUnitsName == "")
        {
            defaultButtonImage.sprite = noUnitSprite;
            myUnit = null;
        }
        else if (myUnitsName == "Settler")
        {
            myUnit = buttonPrefabs[0];
        }
        else if (myUnitsName == "Nix")
        {
            myUnit = buttonPrefabs[1];
        }
        else if (myUnitsName == "Chomp")
        {
            myUnit = buttonPrefabs[2];
        }
    }

    private void BuildAnPlaceMyUnitButton()
    {
        if (myUnit != null)
        {
            GameObject myUnitButton = Instantiate(myUnit, transform.position, Quaternion.identity);
            myUnitButton.transform.SetParent(gameObject.transform);
            myUnitButton.transform.position = gameObject.transform.position;
            UnitButton myButtonScript = myUnitButton.GetComponent<UnitButton>();
            myButtonScript.myUnitCard = PlayerInfoStatic.PlayerDeck[buttonNumber];
            myButtonScript.myButtonNumber = buttonNumber;
        }
    }
}

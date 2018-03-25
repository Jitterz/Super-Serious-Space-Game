using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCard : MonoBehaviour {

    public Sprite[] resourceSprites;
    public Sprite[] attackTypes;
    public Sprite[] cardBackgrounds;

    public Image unitImage;
    public Image cardBackground;
    public Image resourceImage;
    public Image attackImage;

    public Text unitName;
    public Text attackDamage;
    public Text attackSpeed;
    public Text health;
    public Text unitCapacity;
    public Text moveSpeed;
    public Text buildTime;
    public Text resourceCost;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {


    
    public Slider healthBar;
    public Image fill;
    public int health;

    private UnitStats statsHealth;   
    private int maxHealth;

	// Use this for initialization
	void Start ()
    {
        statsHealth = gameObject.GetComponent<UnitStats>();
        health = statsHealth.health;
        healthBar.maxValue = health;
        maxHealth = health;
	}
	
	// Update is called once per frame
	void Update ()
    {
        health = statsHealth.health;
        healthBar.value = health;

        if (health <= maxHealth * 0.60f && health >= maxHealth * 0.30f)
        {
            fill.color = Color.yellow;
        }
        else if (health < maxHealth * 0.30f)
        {
            fill.color = Color.red;
        }
        else
        {
            fill.color = Color.green;
        }
	}
}

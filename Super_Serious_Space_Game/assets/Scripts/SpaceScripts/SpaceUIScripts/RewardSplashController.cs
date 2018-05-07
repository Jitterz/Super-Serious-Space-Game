using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSplashController : MonoBehaviour {

    public Text textAmount;
    public Image splashImage;
    public List<Sprite> splashSprites;

    private UnitCardBuilder cardBuilder;
    private ParticleSystem particles;
    private Animator animate;
    private float particleTimer;
    private string transitionCase;
    private float currentRewardCount;
    private float transitionTime;
    private bool particlePlayed;
    private bool rewardAmountCounted;
    private bool cardCreated = false;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Remove Discovered units");
        PlayerStatsUpgradesStatic.discoveredUnits = new List<string>();
        PlayerStatsUpgradesStatic.discoveredUnits.Add("Settler");
        // remove above discovered units
        rewardAmountCounted = false;
        particlePlayed = false;
        particleTimer = 0;
        currentRewardCount = 0;
        transitionTime = 0;
        textAmount.text = "0";
        animate = GetComponent<Animator>();
        particles = GetComponent<ParticleSystem>();
        cardBuilder = GetComponent<UnitCardBuilder>();
        transitionCase = "Fuel";
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (animate.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            TransitionController();
        }
	}

    private void TransitionController()
    {
        switch (transitionCase)
        {
            case "Fuel":
                if (particles.isPlaying == false && particlePlayed == false)
                {
                    var main = particles.main;
                    main.startColor = Color.red;
                    particlePlayed = true;                   
                    particles.Play();
                }
                else
                {
                    if (ParticleTimer())
                    {
                        if (particles.isPlaying == true)
                        {
                            particles.Stop();
                        }
                    }
                }
                splashImage.sprite = splashSprites[0];
                if (AwardAmountTimer(SavedPlanetForBattleStatic.fuelReward) && rewardAmountCounted == false)
                {
                    textAmount.text = SavedPlanetForBattleStatic.fuelReward.ToString();
                    PlayerInfoStatic.CurrentShipFuel += SavedPlanetForBattleStatic.fuelReward;
                    rewardAmountCounted = true;                   
                }
                else
                {
                    if (rewardAmountCounted == false)
                    {
                        textAmount.text = Math.Round(currentRewardCount, 0).ToString();
                    }
                    else
                    {
                        if (TransitionTimer())
                        {
                            particlePlayed = false;
                            rewardAmountCounted = false;
                            currentRewardCount = 0;
                            transitionCase = "Credits";
                        }
                    }
                }
                break;
            case "Credits":
                if (particles.isPlaying == false && particlePlayed == false)
                {
                    var main = particles.main;
                    main.startColor = Color.yellow;
                    particlePlayed = true;
                    particles.Play();
                }
                else
                {
                    if (ParticleTimer())
                    {
                        if (particles.isPlaying == true)
                        {
                            particles.Stop();
                        }
                    }
                }
                splashImage.sprite = splashSprites[1];
                if (AwardAmountTimer(SavedPlanetForBattleStatic.creditReward) && rewardAmountCounted == false)
                {
                    textAmount.text = SavedPlanetForBattleStatic.creditReward.ToString();
                    PlayerInfoStatic.CurrentCredits += SavedPlanetForBattleStatic.creditReward;
                    rewardAmountCounted = true;
                }
                else
                {
                    if (rewardAmountCounted == false)
                    {
                        textAmount.text = Math.Round(currentRewardCount, 0).ToString();
                    }
                    else
                    {
                        if (TransitionTimer())
                        {
                            particlePlayed = false;
                            rewardAmountCounted = false;
                            currentRewardCount = 0;
                            transitionCase = "Exp";
                        }
                    }
                }
                break;
            case "Exp":
                
                if (particles.isPlaying == false && particlePlayed == false)
                {
                    var main = particles.main;
                    main.startColor = Color.blue;
                    particlePlayed = true;
                    particles.Play();
                }
                else
                {
                    if (ParticleTimer())
                    {
                        if (particles.isPlaying == true)
                        {
                            particles.Stop();
                        }
                    }
                }
                splashImage.sprite = splashSprites[2];
                if (AwardAmountTimer(SavedPlanetForBattleStatic.xPReward) && rewardAmountCounted == false)
                {
                    textAmount.text = SavedPlanetForBattleStatic.xPReward.ToString();
                    PlayerInfoStatic.CurrentXP += SavedPlanetForBattleStatic.xPReward;
                    rewardAmountCounted = true;
                }
                else
                {
                    if (rewardAmountCounted == false)
                    {
                        textAmount.text = Math.Round(currentRewardCount, 0).ToString();
                    }
                    else
                    {
                        if (TransitionTimer())
                        {
                            particlePlayed = false;
                            rewardAmountCounted = false;
                            //Destroy(gameObject);
                            transitionCase = "WonCard";
                            // need a case here for extra rewards cards etc and close out the splash
                        }
                    }
                }
                break;
            case "WonCard":
                // show the card and stuff here
                splashImage.enabled = false;
                textAmount.enabled = false;
                if (cardCreated == false)
                {
                    GameObject newCard = cardBuilder.BuildCard(PlayerHiddenLevelStatic.playerLevel);
                    GameObject playerUnitCard = Instantiate(newCard);
                    PlayerInfoStatic.PlayerUnitCards.Add(playerUnitCard);
                    newCard.transform.parent = gameObject.transform;
                    newCard.transform.position = gameObject.transform.position;
                    RectTransform rect = newCard.GetComponent<RectTransform>();
                    rect.sizeDelta = new Vector2(62.3f, 99.25f);
                    cardCreated = true;
                } 
                if (TransitionTimer())
                {
                    Destroy(gameObject);
                }
                break;
        }       
    }

    private bool ParticleTimer()
    {
        particleTimer += 0.5f * Time.deltaTime;
        if (particleTimer >= 1)
        {
            particleTimer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool AwardAmountTimer(int maxAmount)
    {
        float speed;

        if (maxAmount <= 20)
        {
            speed = 6;
        }
        else if (maxAmount <= 50)
        {
            speed = 20;
        }
        else if (maxAmount <= 100)
        {
            speed = 36;
        }
        else
        {
            speed = 45;
        }

        currentRewardCount += speed * Time.deltaTime;

        if (currentRewardCount >= maxAmount)
        {
            currentRewardCount = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool TransitionTimer()
    {
        transitionTime += 5f * Time.deltaTime;

        if (transitionTime >= 4)
        {
            transitionTime = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}

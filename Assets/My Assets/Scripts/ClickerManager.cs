using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour {

    public int realHackerUpgradeCost;
    public bool isRealHacker;

    //UI stuff
    public Text realHackerUpgradeUIValue;

    public Button realHackerUpgradeButton;

    //GameManager reference
    public GameObject GM;
    
	void Start () {
        isRealHacker = false;
        GM = GameObject.Find("GameManager").gameObject;
	}
	
	void Update () {
		if (isRealHacker && Input.anyKeyDown)
        {
            //makes player have ability to type to send ping if he has the upgrade and any keyboard key is pressed
            GM.GetComponent<ScoreManager>().points += 1; //1 is placeholder value for click value
        }
        //change UI for cost of upgrade
        ShowCostOfUpgrade();
	}

    public void MakePlayerRealHacker()
    {
        //check to see if player has enough points to purchase upgrade
        if (GM.GetComponent<ScoreManager>().points >= realHackerUpgradeCost)
        {
            //decrease player's points by real hacker upgrade cost
            GM.GetComponent<ScoreManager>().points -= realHackerUpgradeCost;
            //give player access to real hacker upgrade
            isRealHacker = true;
            //disable button once activated
            realHackerUpgradeButton.interactable = false;
        }
    }

    //UI stuff
    public void ShowCostOfUpgrade()
    {
        realHackerUpgradeUIValue.text = " Cost: " + realHackerUpgradeCost.ToString();
    }

    //disable button after upgrade, todo
}

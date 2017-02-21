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
    public GameObject STM;
    
	void Start () {
        isRealHacker = false;
        GM = GameObject.Find("GameManager").gameObject;
	}
	
	void Update () {
        //to find if player presses any letter keys
        for (int i = 97; i < 123; i++)
        {
            //makes player have ability to type to send ping if he has the upgrade and any keyboard key is pressed
            if (isRealHacker && Input.GetKeyDown((KeyCode)i))
            {
                double pointsToAdd = 0;
                pointsToAdd = CalculatePointsToAdd(pointsToAdd);
                //gives player points
                GM.GetComponent<ScoreManager>().points += pointsToAdd;
                //makes popup text for points at mouse position
                PopupTextController.CreatePopupText(pointsToAdd.ToString(), Input.mousePosition);
                break;
            }
        }
        //change UI for cost of upgrade
        ShowCostOfUpgrade();
        if (GM.GetComponent<ScoreManager>().points < realHackerUpgradeCost || isRealHacker)
        {
            realHackerUpgradeButton.interactable = false;
        }
        else
        {
            realHackerUpgradeButton.interactable = true;
        }
	}

    //adds points when clicked
    public void PlusPointsOnClick()
    {
        double pointsToAdd = 0;
        pointsToAdd = CalculatePointsToAdd(pointsToAdd);
        GM.GetComponent<ScoreManager>().points += pointsToAdd;
        //makes popup text for points at mouse position
        PopupTextController.CreatePopupText((pointsToAdd).ToString(), Input.mousePosition);
    }

    //calculates how many points to give to player
    public double CalculatePointsToAdd(double mPointsToAdd)
    {
        float randValue = Random.value;
        //chance to get extra points
        if (randValue < 0.99f) //0.99f is a placeholder value
        {
            //99% chance to get normal points
            mPointsToAdd = 1 + STM.GetComponent<ServerTierManager>().serverTier;
        }
        else
        {
            //1% chance to get bonus points
            mPointsToAdd = (1 + STM.GetComponent<ServerTierManager>().serverTier) * 10; //10 is a placeholder value
        }
        return mPointsToAdd;
    }

    //real hacker upgrade
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
            realHackerUpgradeCost = 0;
        }
    }

    //UI stuff
    public void ShowCostOfUpgrade()
    {
        realHackerUpgradeUIValue.text = " Cost: " + realHackerUpgradeCost.ToString();
    }
}

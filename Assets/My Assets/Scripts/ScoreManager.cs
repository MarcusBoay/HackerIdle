using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public double points;
    public double pointsPerSecond;

    public Text pointsText;
    public Text pointsPerSecondText;

    private GameObject STM;
    public GameObject[] BM;
    
	void Start () {
        STM = GameObject.Find("ServerTierManager").gameObject;
        points = 0; //placeholder, will be store on player's account
	}
	
	void Update () {
        //update internet points UI
        pointsText.text = Convert.ToInt32(points).ToString(); //will add 456K, 765M, 192B, etc in the future
        //update points per second UI
        ShowPointsPerSecond();
    }
    
    public void PlusPointsOnClick()
    {
        float randValue = UnityEngine.Random.value;
        double pointsToAdd = 0;
        if (randValue < 0.99f) //0.99f is a placeholder value
        {
            //99% chance that it's normal points
            pointsToAdd = 1 + STM.GetComponent<ServerTierManager>().serverTier;
        }
        else
        {
            //1% chance to get bonus points
            pointsToAdd = (1 + STM.GetComponent<ServerTierManager>().serverTier) * 10; //10 is a placeholder value
        }
        points += pointsToAdd;
        //makes popup text for points at mouse position
        PopupTextController.CreatePopupText((pointsToAdd).ToString(), Input.mousePosition);
    }

    public void ShowPointsPerSecond()
    {
        pointsPerSecond = 0;
        for (int i = 0; i < BM.Length; i++)
        {
            pointsPerSecond += BM[i].GetComponent<BotnetManager>().totalPointsPerSecond;
        }
        pointsPerSecondText.text = string.Format("{0:F1}", pointsPerSecond);
    }
}

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
        points += 1 + STM.GetComponent<ServerTierManager>().serverTier;
        //makes popup text for points at mouse position
        PopupTextController.CreatePopupText((1 + STM.GetComponent<ServerTierManager>().serverTier).ToString(), Input.mousePosition);
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

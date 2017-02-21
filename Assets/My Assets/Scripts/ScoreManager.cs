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
    public GameObject[] BM1;
    public GameObject[] BM2;
    
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

    //UI stuff, to show points per second from botnets
    public void ShowPointsPerSecond()
    {
        pointsPerSecond = 0;
        for (int i = 0; i < BM1.Length; i++)
        {
            pointsPerSecond += BM1[i].GetComponent<BotnetManager>().totalPointsPerSecond;
        }
        for (int i = 0; i < BM2.Length; i++)
        {
            pointsPerSecond += BM2[i].GetComponent<BotnetTier2Manager>().totalPointsPerSecond;
        }
        pointsPerSecondText.text = string.Format("{0:F1}", pointsPerSecond);
    }
}

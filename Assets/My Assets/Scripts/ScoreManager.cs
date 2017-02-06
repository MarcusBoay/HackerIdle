using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public float points;
    public Text pointsText;
    
	void Start () {
        points = 0; //placeholder, will be store on player's account
	}
	
	void Update () {
        //update internet points UI
        pointsText.text = Convert.ToInt32(points).ToString(); //will add 456K, 765M, 192B, etc in the future
    }
    
    public void PlusPointsOnClick()
    {
        points += 1;
    }
}

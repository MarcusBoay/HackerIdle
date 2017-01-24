using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int points;
    public Text pointsText;
    
	void Start () {
        points = 0;
	}
	
	void Update () {
        //update internet points UI
        pointsText.text = points.ToString(); //will add 456K, 765M, 192B, etc in the future
	}
    
    public void PlusPointsOnClick()
    {
        points += 1; //1 is a placeholder number, will be changed in future updates
    }
}

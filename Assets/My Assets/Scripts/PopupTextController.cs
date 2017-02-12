using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTextController : MonoBehaviour {

    private static PopupTextAnimator popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        popupText = Resources.Load<PopupTextAnimator>("Prefabs/PopupTextParent");
    }

    public static void CreatePopupText(string myText, Vector3 myLocation)
    {
        Initialize();
        myLocation.x += Random.Range(-15f, 15f);
        myLocation.y += Random.Range(-15f, 15f);
        PopupTextAnimator instance = Instantiate(popupText);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = myLocation;
        instance.SetText(myText);
    }
}

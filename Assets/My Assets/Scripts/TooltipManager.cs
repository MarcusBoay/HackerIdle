using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour {

    private GameObject TT;
    private RectTransform rt;

    private Canvas canvas;

    void Start()
    {
        TT = GameObject.Find("Canvas").gameObject.transform.FindChild("Panel").FindChild("TooltipPanel").gameObject;
        rt = TT.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    void Update () {
        if (TT.activeSelf)
        {
            TT.transform.position = new Vector3(213 + rt.rect.width * canvas.scaleFactor / 2, Input.mousePosition.y, 0);
        }
    }
}

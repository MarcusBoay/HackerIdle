using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private GameObject tooltipPanel;
    private RectTransform rt;

    private Canvas canvas;

    void Start()
    {
        tooltipPanel = GameObject.Find("Canvas").gameObject.transform.FindChild("Panel").FindChild("TooltipPanel").gameObject;
        rt = tooltipPanel.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            tooltipPanel.transform.position = new Vector3(213 + rt.rect.width * canvas.scaleFactor / 2, Input.mousePosition.y, 0);
        }
    }

    public void OnMouseEnter()
    {
        tooltipPanel.SetActive(true);
    }

    public void OnMouseExit()
    {
        tooltipPanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    public string title;
    public string description;

    private GameObject tooltipPanel;
    private RectTransform rt;
    private Text titleUI;
    private Text descUI;

    private Canvas canvas;

    void Start()
    {
        tooltipPanel = GameObject.Find("Canvas").gameObject.transform.FindChild("Panel").FindChild("TooltipPanel").gameObject;
        rt = tooltipPanel.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        titleUI = tooltipPanel.transform.FindChild("Title").GetComponent<Text>();
        descUI = tooltipPanel.transform.FindChild("Description").GetComponent<Text>();
    }

    void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            titleUI.text = title;
            descUI.text = description;
            tooltipPanel.transform.position = new Vector3(213 + rt.rect.width * canvas.scaleFactor / 2, Input.mousePosition.y, 0);
        }
    }

    public void OnMouseEnter()
    {
        titleUI.text = title;
        descUI.text = description;
        tooltipPanel.SetActive(true);
    }

    public void OnMouseExit()
    {
        tooltipPanel.SetActive(false);
        titleUI.text = "";
        descUI.text = "";
    }
}

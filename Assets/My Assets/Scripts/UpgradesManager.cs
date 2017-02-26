using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour {

    [Header("Upgrade variables")]
    public bool isUpgraded;
    public int upgradeCost;

    [Header("Real hacker upgrade tooltip variables")]
    public string upgradeTitle;
    public string upgradeDescription;

    [Header("Upgrade UI")]
    public Text upgradeCostUIValue;
    public Button upgradeButton;
    
    [Header("Next upgrade UI")]
    public GameObject nextUpgradeButton;

    //GameManager reference
    private GameObject GM;

    //Tooltip reference
    private GameObject TT;
    private Text TTTitle;
    private Text TTDesc;
    private GameObject TTStatsGO;

    void Start()
    {
        GM = GameObject.Find("GameManager").gameObject;

        TT = GameObject.Find("Canvas").transform.FindChild("Panel").FindChild("TooltipPanel").gameObject;
        TTTitle = TT.transform.FindChild("Title").GetComponent<Text>();
        TTDesc = TT.transform.FindChild("Description").GetComponent<Text>();
        TTStatsGO = TT.transform.FindChild("Stats").gameObject;
    }

    void Update()
    {
        ShowCostOfUpgrade();
        if (GM.GetComponent<ScoreManager>().points < upgradeCost || isUpgraded)
        {
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
        }
    }

    //UI stuff
    public void BuyUpgrade()
    {
        if (GM.GetComponent<ScoreManager>().points >= upgradeCost)
        {
            GM.GetComponent<ScoreManager>().points -= upgradeCost;
            isUpgraded = true;
            upgradeButton.interactable = false;
            upgradeCost = 0;
        }
    }

    public void ActivateNextButton()
    {
        nextUpgradeButton.SetActive(true);
    }

    //UI stuff
    public void ShowCostOfUpgrade()
    {
        upgradeCostUIValue.text = " Cost: " + upgradeCost.ToString();
    }

    //UI stuff
    public void ShowTooltipUpgrade()
    {
        TTTitle.text = upgradeTitle;
        TTDesc.text = upgradeDescription;
        TTStatsGO.SetActive(false);
        TT.SetActive(true);
    }

    //UI stuff
    public void HideTooltipUpgrade()
    {
        TT.SetActive(false);
        TTTitle.text = String.Empty;
        TTDesc.text = String.Empty;
    }
}

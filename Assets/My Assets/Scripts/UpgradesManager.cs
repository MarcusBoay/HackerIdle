using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour {

    public bool isUpgraded;
    public int upgradeCost;

    //UI stuff
    public Text upgradeCostUIValue;
    public Button upgradeButton;

    public GameObject nextUpgradeButton;

    private GameObject GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").gameObject;
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
}

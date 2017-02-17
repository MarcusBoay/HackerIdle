using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerTierManager : MonoBehaviour {

    public int serverTier;
    public int maxTier;

    public string[] serverName;

    public Button lowerTierButton;
    public Button higherTierButton;

    public Text serverNameText;

    public GameObject[] upgradeManagers;

	void Update () {
		if (serverTier <= 0)
        {
            serverTier = 0;
            lowerTierButton.interactable = false;
            higherTierButton.interactable = upgradeManagers[0].GetComponent<UpgradesManager>().isUpgraded;
        }
        else if (serverTier == maxTier)
        {
            serverTier = maxTier;
            lowerTierButton.interactable = true;
            higherTierButton.interactable = false;
        }
        else
        {
            lowerTierButton.interactable = true;
            higherTierButton.interactable = upgradeManagers[serverTier].GetComponent<UpgradesManager>().isUpgraded;
        }
        ShowServerName();
	}

    public void IncreaseServerTier()
    {
        serverTier += 1;
    }

    public void DecreaseServerTier()
    {
        serverTier -= 1;
    }
    //UI stuff
    public void ShowServerName()
    {
        serverNameText.text = serverName[serverTier];
    }
}

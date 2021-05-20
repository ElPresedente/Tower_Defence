using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUIElement : MonoBehaviour
{
    public GameObject StatText;
    public GameObject UpgradeButton;
    public GameObject UpgradeText;

    private TowerBase TowerPlace;
    private int TowerNum;
    private Tower Tower;    

    public void SetUIElement(GameObject towerPlace, int towerNum)
    {
        TowerPlace = towerPlace.GetComponent<TowerBase>();
        TowerNum = towerNum;
        if (!TowerPlace.isTowerPlaced)
        {
            StatText.GetComponent<TMP_Text>().text = string.Format("Tower {0} Level 0", towerNum);
            UpgradeText.GetComponent<TMP_Text>().text = string.Format("Upgrade price: {0}", StaticGameManager.TowerCost);
        }
        else
        {
            Tower = TowerPlace.tower.GetComponent<Tower>();
            StatText.GetComponent<TMP_Text>().text = string.Format("Tower {0} Level {1}", towerNum, Tower.Level + 1);
            UpgradeText.GetComponent<TMP_Text>().text = string.Format("Upgrade price: {0}", StaticGameManager.TowerUpgradeCost[Tower.Level]);
        }
    }


    public void OnUpgradeButtonClick()
    {
        if (!TowerPlace.isTowerPlaced && StaticGameManager.GameManager.Gold >= StaticGameManager.TowerCost)
        {
            StaticGameManager.GameManager.Gold -= StaticGameManager.TowerCost;
            TowerPlace.SpawnTower();
            UpdateInfo();
            return;
        }
        if (TowerPlace.isTowerPlaced && StaticGameManager.GameManager.Gold >= StaticGameManager.TowerUpgradeCost[Tower.Level])
        {
            StaticGameManager.GameManager.Gold -= StaticGameManager.TowerUpgradeCost[Tower.Level];
            Tower.Upgrage();
            UpdateInfo();
            return;
        }
    }

    void UpdateInfo()
    {
        if (!TowerPlace.isTowerPlaced)
        {
            StatText.GetComponent<TMP_Text>().text = string.Format("Tower {0} Level 0", TowerNum);
            UpgradeText.GetComponent<TMP_Text>().text = string.Format("Upgrade price: {0}", StaticGameManager.TowerCost);
        }
        else
        {
            Tower = TowerPlace.tower.GetComponent<Tower>();
            StatText.GetComponent<TMP_Text>().text = string.Format("Tower {0} Level {1}", TowerNum, Tower.Level + 1);
            UpgradeText.GetComponent<TMP_Text>().text = string.Format("Upgrade price: {0}", StaticGameManager.TowerUpgradeCost[Tower.Level]);
        }
    }
}

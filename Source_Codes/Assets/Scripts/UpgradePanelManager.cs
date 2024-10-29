using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] UpgradeDescriptionPanel upgradeDescriptionPanel;
    PauseManager pauseManager;
    Level playerLevel;

    [SerializeField] List<UpgradeButton> upgradeButtons;
    int selectedUpgradeID;
    List<UpgradeData> upgradeData;

    private void Awake() 
    {
        pauseManager = GetComponent<PauseManager>();
        playerLevel = GameManager.Instance.playerTransform.GetComponent<Level>();
    }
    private void Start() 
    {
        HideButtons();
        selectedUpgradeID = -1;
    }

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pauseManager.PauseGame();
        panel.SetActive(true);

        this.upgradeData = upgradeDatas;

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID)
    {
        if (selectedUpgradeID != pressedButtonID)
        {
            selectedUpgradeID = pressedButtonID;
            ShowDescription();
        }
        else
        {
            playerLevel.Upgrade(pressedButtonID);
            ClosePanel();
            HideDescription();
        }
       
    }

    private void HideDescription()
    {
        upgradeDescriptionPanel.gameObject.SetActive(false);
    }

    private void ShowDescription()
    {
        upgradeDescriptionPanel.gameObject.SetActive(true);
        upgradeDescriptionPanel.Set(upgradeData[selectedUpgradeID]);
    }

    public void ClosePanel()
    {
        selectedUpgradeID = -1;
        HideButtons();
        HideDescription();

        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplation : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManager pauseManager;

    [SerializeField] LevelFinish levelComplatePanel;

    private void Awake() 
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindObjectOfType<PauseManager>();
        levelComplatePanel = FindObjectOfType<LevelFinish>(true);
    }

    private void Update() 
    {
        if (stageTime.time > timeToCompleteLevel)
        {
            pauseManager.PauseGame();
            levelComplatePanel.gameObject.SetActive(true);
        }
    }
}

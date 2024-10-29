using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTime : MonoBehaviour
{
    public float time;
    TimerUI timerUI;

    private void Awake() 
    {
        timerUI = FindObjectOfType<TimerUI>();
    }
    void Update()
    {
        time += Time.deltaTime;
        timerUI.UpdateTime(time);
    }
}

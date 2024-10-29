using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;
    public void StartGameplay()
    {
        if (!string.IsNullOrEmpty(dataContainer.selectedStage)) 
        {
            SceneManager.LoadScene("Essential", LoadSceneMode.Single);
            SceneManager.LoadScene(dataContainer.selectedStage, LoadSceneMode.Additive);
        }
        else
        {
            dataContainer.selectedStage = "Game";
            SceneManager.LoadScene("Essential", LoadSceneMode.Single);
            SceneManager.LoadScene(dataContainer.selectedStage, LoadSceneMode.Additive);
        }
    }
}


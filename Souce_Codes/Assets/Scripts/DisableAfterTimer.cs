using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTimer : MonoBehaviour
{
    float timeToDisable = 0.4f;
    float timer;
    private void OnEnable() 
    {
        timer = timeToDisable;
    }

    private void LateUpdate() 
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
            gameObject.SetActive(false);
    }

}

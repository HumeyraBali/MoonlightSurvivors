using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;

    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        bar.transform.localScale = new Vector3(state,1f,1f);
    }
}

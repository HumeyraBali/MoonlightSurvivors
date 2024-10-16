using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropItem;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;

    bool isQuitting = false;

   private void OnApplicationQuit() 
   {
        isQuitting = true;
    }

    public void CheckDrop() 
    {
        if (isQuitting) { return; }

        if (Random.value < chance)
        {
            Transform t = Instantiate(dropItem).transform;
            t.position = transform.position;
        }
        
    }
}

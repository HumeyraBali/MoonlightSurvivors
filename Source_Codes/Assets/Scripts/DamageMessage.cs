using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float ttl = 1f;

    private void Update() 
    {
        ttl -= Time.deltaTime;
        if (ttl < 0) Destroy(gameObject);
    }
}

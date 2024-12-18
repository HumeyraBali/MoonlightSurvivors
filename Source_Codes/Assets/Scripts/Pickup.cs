using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Player c = collision.GetComponent<Player>();
        if (c != null)
        {
            GetComponent<IPickUp>().OnPickUp(c);
            Destroy(gameObject);
        }
    }
}

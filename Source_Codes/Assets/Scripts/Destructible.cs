using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestroy>().CheckDrop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public string Name;
    public GameObject spritePrefab;
    public WeaponData startingWeapon;
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] GameObject damageMessage;
    public static MessageSystem instance;

    private void Awake() 
    {
        instance = this;
    }

    public void PostMessage(string text, Vector3 worldPosition)
    {
        GameObject go = Instantiate(damageMessage, transform);
        go.transform.position = worldPosition;
        go.GetComponent<TMPro.TextMeshPro>().text = text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForLoadScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
}

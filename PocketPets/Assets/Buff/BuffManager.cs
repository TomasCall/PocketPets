using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager: MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}

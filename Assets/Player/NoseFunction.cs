using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseFunction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("--");
        if (other.tag != "MainPlayer")
        {
            other.gameObject.SetActive(false);
            Debug.Log("ªË¡¶");
        }
    }

}

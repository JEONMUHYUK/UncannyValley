using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
     GameObject player;
    [SerializeField]
    Vector3 cameraPos;
    void Start()
    {
        player = GameObject.FindWithTag("MainPlayer");
        gameObject.transform.SetParent(player.transform);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localPosition += -Vector3.forward*0.55f+Vector3.up*0.4f;
        gameObject.transform.Rotate(20, 180, 0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRigidBody;
    [SerializeField]
    float moveSpeed = 2;

    Vector3 velocityX = Vector3.zero;
    Vector3 velocityZ = Vector3.zero;
    Vector3 rotate = Vector3.zero;

    private void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Mouse X");
        velocityX.x = x;
        velocityZ.z = z;
        rotate.y = y;
        playerRigidBody.transform.forward = velocityZ;
        playerRigidBody.transform.right = velocityX;

        playerRigidBody.transform.Rotate(rotate);
    }
}

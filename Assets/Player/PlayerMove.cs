using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRigidBody;
    [SerializeField]
    float moveSpeed = 2;

    Vector3 velocity = Vector3.zero;
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

        velocity.z = -z;
        velocity.x = -x;
        rotate.y = y;

        playerRigidBody.transform.Rotate(rotate);
        playerRigidBody.transform.Translate(velocity*Time.deltaTime*moveSpeed);
    }


}

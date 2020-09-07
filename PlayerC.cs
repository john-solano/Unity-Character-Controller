using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpHeight = 5.0f;
    private bool canJump = true;
    public Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float translation = Input.GetAxis("LSVertical") * speed;
        float straffe = Input.GetAxis("LSHorizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rbody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}


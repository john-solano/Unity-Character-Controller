using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour {
    public float speed = 10.0f;

    public string LTVertical;
    public string LTHorizontal;

    public string J;
    public float jumpHeight = 8;
    private bool isFalling = false;
    public Rigidbody rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        jump();
    }

    void Movement()
    {
        float translation = Input.GetAxis(LTVertical) * speed;
        float straffe = Input.GetAxis(LTHorizontal) * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }

    void OnCollisionStay(Collision collision)
    {
        isFalling = false;
    }

    void jump()
    {
        if (Input.GetButtonDown(J) && isFalling == false)
        {
            Debug.Log("jump initiated");
            rbody.velocity = new Vector3(0, jumpHeight, 0);
        }
        isFalling = true;
    }
}

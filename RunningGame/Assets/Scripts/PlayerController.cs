using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool grounded;
    public bool readyToJump;
    public float jumpPower;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	void Update ()
    {        
        //Queue a jump action for when Player next touches land
        readyToJump = Input.GetButton("Fire1") ?  true : false;

        //If grounded, can perform jump
        if (grounded == true && readyToJump == true)
        {
            jump();
        }
    }

    //Called when collision starts
    void OnCollisionStart2D()
    {

    }

    //Called constantly when colliding with something
    void OnCollisionStay2D(Collision2D coll)
    {
        //Need to add 'if collision object is top of a floor tile', to allow collisions with other objects
        //Return to the ground faster than using y speed
        if (!grounded)
        {
            grounded = true;

            if (readyToJump == true)
                jump();
        }
    }

    void jump()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
        grounded = false;
        readyToJump = false;
    }
}

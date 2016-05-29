using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool grounded;
    public bool readyToJump;
    public float jumpPower;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {        
        //Queue a jump action for when Player next touches land
        readyToJump = Input.GetButton("Jump") ?  true : false;

        //If grounded, can perform jump
        if (grounded == true && readyToJump == true)
        {
            jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //Gets picked up by the attack controller
            //gameObject.SendMessage("attack");
            //Sends message to everything in and under this gameObject (sprite animator, doesDamage)
            BroadcastMessage("startAttack");

        }

        if (Input.GetButtonDown("Fire2"))
        {
            //TEMPORARY:
            BroadcastMessage("stopAttack");
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
        //Constantly calls to keep player fixed in place, because physics is off
        /*if (grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }*/
    }

    void jump()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower);
        rigidBody.velocity = new Vector2(0, jumpPower);
        grounded = false;
        readyToJump = false;
    }
}

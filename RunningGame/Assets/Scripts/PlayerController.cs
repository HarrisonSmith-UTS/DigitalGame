using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool grounded;
    public bool jumpButton;
    public float jumpPower;
    public float flyPower;

    public float fuelDepleteRate;

    public float maxFuel;
    private float fuel;

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {        
        //Queue a jump action for when Player next touches land
        jumpButton = Input.GetButton("Jump") ?  true : false;

        //If grounded, can perform jump
        if (jumpButton == true)
        {
            if (grounded == true)
            {
                jump();
            }
            else if (fuel > 0)
            {
                hover();
                fuel -= Time.deltaTime * fuelDepleteRate;
                print("FUEL: " + fuel);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //Gets picked up by the attack controller
            //gameObject.SendMessage("attack");
            //Sends message to everything in and under this gameObject (sprite animator, doesDamage)
            BroadcastMessage("startAttack");
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
        //When grounded
        if (!grounded && coll.gameObject.tag == "Platform")
        {
            grounded = true;
            fuel = maxFuel;
        }
    }

    void jump()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower);
        rigidBody.velocity = new Vector2(0, jumpPower);
        grounded = false;
        //jumpButton = false;
    }

    void hover()
    {
        //rigidBody.AddForce(transform.up * flyPower);
        rigidBody.velocity = new Vector2(0, flyPower);
        grounded = false;
    }
}

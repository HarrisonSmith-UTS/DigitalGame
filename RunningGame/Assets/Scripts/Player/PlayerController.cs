using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool grounded;
    private bool attacking;

    public bool jumpButton;
    public float jumpPower;
    public float flyPower;
    public float maxUpwardSpeed;
    public float fuelDepleteRate;
    public float maxFuel;

    public UImanager ui;
    private float fuel;

    private Rigidbody2D rigidBody;

    private jetpackFlames jetpackAnim;

    private float score;
    public float scoreRate;

    private float scrollSpeed;
    

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jetpackAnim = gameObject.GetComponentInChildren<jetpackFlames>();
        fuel = maxFuel;
        ui.initFuelBar(maxFuel);
        ui.updateFuelBar(fuel);
        //may need to change this later if continuing on scenes
        score = 0;

        scrollSpeed = globalConstants.scrollSpeed;
    }
	
	void Update ()
    {        
        //Queue a jump action for when Player next touches land
        jumpButton = Input.GetButton("Jump") ?  true : false;

        //If grounded, can perform jump
        if (jumpButton == true)
        {
            jetpackAnim.enableFire();
            if (grounded == true)
            {
                jump();
            }
            else if (fuel > 0)
            {
                hover();
            }
        }
        else
        {
            jetpackAnim.stopFire();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //Sends message to everything in and under this gameObject (mainly attack controller)
            if (!attacking)
            {
                BroadcastMessage("startAttack");
            }
        }
        score += Time.deltaTime * scrollSpeed;
        ui.updateScoreDisplay(score);
    }

    //Called when collision starts
    void OnCollisionStart2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Platform")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        }
    }

    //Called constantly when colliding with something
    void OnCollisionStay2D(Collision2D coll)
    {
        //Need to add 'if collision object is top of a floor tile', to allow collisions with other objects
        //Return to the ground faster than using y speed
        if (!grounded && coll.gameObject.tag == "Platform")
        {
            grounded = true;
            fuel = maxFuel;
            ui.updateFuelBar(fuel);
        }
    }

    void jump()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        rigidBody.AddForce(gameObject.transform.up * jumpPower);
        grounded = false;
    }

    void hover()
    {
        fuel -= Time.deltaTime * fuelDepleteRate;
        ui.updateFuelBar(fuel);

        //print("Velocity: " + rigidBody.velocity.y );
        if (rigidBody.velocity.y < 10)
        {
            //Extra boost before flying upward
            rigidBody.AddForce(gameObject.transform.up * flyPower);
        }
        if (rigidBody.velocity.y < maxUpwardSpeed)
        {
            rigidBody.AddForce(gameObject.transform.up * flyPower);
        }
        grounded = false;
    }

    void isAttacking(bool attacking)
    {
        this.attacking = attacking;
    }

   
}

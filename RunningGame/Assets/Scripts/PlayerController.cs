using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool grounded;
    public bool jumpButton;
    public float jumpPower;
    public float flyPower;
    public float maxUpwardSpeed;
    public float fuelDepleteRate;
    public float maxFuel;

    public fuelBarManager fuelBar;
    private float fuel;

    private Rigidbody2D rigidBody;

    private jetpackFlames jetpackAnim;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jetpackAnim = gameObject.GetComponentInChildren<jetpackFlames>();
        fuel = maxFuel;
        fuelBar.initFuelBar(maxFuel);
        fuelBar.updateFuelBar(fuel);
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
        if (!grounded && coll.gameObject.tag == "Platform")
        {
            grounded = true;
            fuel = maxFuel;
            fuelBar.updateFuelBar(fuel);
        }
    }

    void jump()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        rigidBody.velocity = new Vector2(0, jumpPower);
        grounded = false;
    }

    void hover()
    {
        fuel -= Time.deltaTime * fuelDepleteRate;
        fuelBar.updateFuelBar(fuel);

        print("Velocity: " + rigidBody.velocity.y );
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
}

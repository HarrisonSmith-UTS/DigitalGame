using UnityEngine;
using System.Collections;

//Uses the collision of the attached object to send damage messages to the collided object
public class doesDamage : MonoBehaviour
{
    public float damage;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void onCollisionEnter(Collision2D coll)
    {
        //Calls the 'take damage' function on the colliding object
        coll.gameObject.SendMessage("takeDamage", damage);
    }
}

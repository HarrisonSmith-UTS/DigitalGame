using UnityEngine;
using System.Collections;

//Uses the collider of the gameObject to send damage messages to the collided object
//
public class doAttack : MonoBehaviour
{
    public float damage;
    //The time an attack will last in seconds. 0 = no specified time.
    public float attackTime;
    public bool destroyOnCollision;

	// Use this for initialization
	void Start ()
    {
        if (attackTime != 0)
        {
            Destroy(gameObject, attackTime);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void onCollisionEnter(Collision2D coll)
    {
        //Calls the 'take damage' function on the colliding object
        coll.gameObject.SendMessage("takeDamage", damage);

        if (destroyOnCollision)
        {
            Destroy(gameObject);
        }
    }
}

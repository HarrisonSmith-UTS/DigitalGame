using UnityEngine;
using System.Collections;

//Uses the collider of the gameObject to send damage messages to the collided object
//Needs to be specific to an attack
public class doesDamage : MonoBehaviour
{
    private Collider2D hitbox;

    public float damage;
    //The time an attack will last in seconds. 0 = no specified time.
    //Not in parent object.
    public float attackTime;
    public bool destroyAttackOnCollision;
    public bool stopAttackOnCollision;

	// Use this for initialization
	void Start ()
    {
        hitbox = GetComponent<Collider2D>();

        if (attackTime != 0)
        {
            //Destroy(gameObject, attackTime);
            //this should disable
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void startAttack()
    {
        hitbox.enabled = true;
        //start attack timer?
    }

    void onCollisionEnter(Collision2D coll)
    {
        //Calls the 'take damage' function on the colliding object
        coll.gameObject.SendMessage("takeDamage", damage);

        if (destroyAttackOnCollision)
        {
            stopAttack();
            Destroy(gameObject);
        }
        else if (stopAttackOnCollision)
        {
            stopAttack();
        }
    }

    void stopAttack()
    {
        //Disable this game object's collider
        hitbox.enabled = false;
    }

    //May not need this?
    void destroyObject()
    {

    }
}

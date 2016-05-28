using UnityEngine;
using System.Collections;

//Uses the collider of the gameObject to send damage messages to the collided object
//Needs to be specific to an attack
public class doesDamage : MonoBehaviour
{
    private bool attacking;
    private Collider2D hitbox;

    public float damage;
    //The time an attack will last in seconds. 0 = no specified time.
    //Not in parent object
    public float attackTime;
    private float attackTimer = 0;
    public bool destroyAttackOnCollision;
    public bool stopAttackOnCollision;

	// Use this for initialization
	void Start ()
    {
        //Should select the first Collider2D in the instance
        hitbox = GetComponent<Collider2D>();
        hitbox.enabled = false;

        if (attackTime != 0)
        {
            //Destroy(gameObject, attackTime);
            //this should disable the attack
            //unless it is a projectile which lasts for a certain amount of time before destroying
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                stopAttack();
            }
        }
	}

    void startAttack()
    {
        attacking = true;
        hitbox.enabled = true;
        //start attack timer?
    }

    void onCollisionEnter2D(Collision2D coll)
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

    void onTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("takeDamage", damage);

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
        SendMessageUpwards("endAttack");
    }

    //May not need this?
    void destroyObject()
    {

    }
}

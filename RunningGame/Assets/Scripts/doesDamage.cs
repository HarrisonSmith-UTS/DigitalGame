using UnityEngine;
using System.Collections;

//Uses the collider of the gameObject to send damage messages to the collided object
//Needs to be specific to an attack
public class doesDamage : MonoBehaviour
{
    //Private timing variables
    private bool attacking;
    private float attackTimer = 0;

    //Attack attributes
    public float damage;
    public bool destroyAttackOnCollision;
    public bool stopAttackOnCollision;
    //Time that attack will last in seconds
    public float attackTime;

    //Determines the sprites that the top level animator will use for animations
    public Sprite[] attackSprites;

    private Collider2D hitbox;

    // Use this for initialization
    void Start ()
    {
        //Should select the first Collider2D in the instance
        hitbox = GetComponent<Collider2D>();
        hitbox.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Determines how long the attack should last
	    if (attacking && attackTime != 0)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                stopAttack();
            }
        }
	}

    void startAttack()
    {
        attacking = true;
        hitbox.enabled = true;
        attackTimer = attackTime;
        SendMessageUpwards("startSpecialAnim", attackSprites);
    }

    void OnCollisionEnter2D(Collision2D coll)
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
        attacking = false;
        hitbox.enabled = false;
        SendMessageUpwards("endSpecial Anim");
        SendMessageUpwards("endAttack");

    }

    //May not need this?
    void destroyObject()
    {

    }
}

using UnityEngine;
using System.Collections;

//Uses the collider of the gameObject to send damage messages to the collided object
//Needs to be specific to an attack
public class attackController : MonoBehaviour
{
    //Private timing variables
    private bool attacking;
    private bool charging;
    private bool damaging;
    private bool onCooldown;
    
    private float timer = 0;

    //Attack attributes
    public float damage;
    public bool destroyObjectOnCollision;
    public bool stopAttackOnCollision;
    //Time that attack will last in seconds
    public float chargeTime;
    public float damageTime;
    public float cooldownTime;

    //Determines the sprites that the top level animator will use for animations
    public Sprite[] chargeSprites;
    public Sprite[] damageSprites;
    public Sprite[] cooldownSprites;

    private Collider2D hitbox;

    // Use this for initialization
    void Start ()
    {
        //Should select the first Collider2D in the instance
        hitbox = GetComponent<Collider2D>();
        if (damageTime != 0)
        {
            hitbox.enabled = false;
        }
        else
        {
            hitbox.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update()
    {
        /*
        //Could turn these into enums if you get time (look at zombieconga)
        if (charging && chargeTime != 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                endCharging();
                startDamage();
            }
        }
        else if (damaging && damageTime != 0)
        {
            //NOTE: Removed check if 'damageTime == 0'. Should be moved to a projectile class.
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                endAttack();
            }
        }
        else if (onCooldown && cooldownTime != 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                endAttack();
            }
        }
        */
        //OPTIMISED CODE:
        //Timer will always tick down
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (charging)
            {
                startDamage();
            }
            else if (damaging)
            {
                startCooldown();
            }
            else
            {
                endAttack();
            }
        }
    }

    void startAttack()
    {
        if (!attacking)
        {
            attacking = true;
            charging = true;
            timer = chargeTime;
            SendMessageUpwards("startSpecialAnim", chargeSprites);
        }
        //else, doesn't start the attack
    }

    void startDamage()
    {
        charging = false;
        damaging = true;
        hitbox.enabled = true;
        timer = damageTime;
        SendMessageUpwards("startSpecialAnim", damageSprites);
    }

    void startCooldown()
    {
        damaging = false;
        hitbox.enabled = false;
        SendMessageUpwards("startSpecialAnim", cooldownSprites);
    }
    
    void endAttack()
    {
        onCooldown = false;
        attacking = false;
        SendMessageUpwards("endSpecialAnim");
        //Not currently needed, may be needed later
        //SendMessageUpwards("endAttack");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Hitbox must be enabled for this to happen
        //Calls the 'take damage' function on the colliding object
        if (coll.gameObject.tag != "Environment")
        {
            coll.gameObject.SendMessage("takeDamage", damage);
        }

        if (destroyObjectOnCollision)
        {
            endAttack();
            Destroy(gameObject);
        }
        else if (stopAttackOnCollision)
        {
            endAttack();
        }
    }
}
 
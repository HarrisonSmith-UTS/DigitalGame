using UnityEngine;
using System.Collections;

public class damageable : MonoBehaviour {

    public float health;
    public float currentHealth;

    //Set to 0 for no invuln time.
    public float invulnTime;
    private float invulnTimer;
    private bool invulnerable;

	// Use this for initialization
	void Start ()
    {
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (invulnerable)
        {
            if (invulnTimer > 0)
            {
                invulnTimer -= Time.deltaTime;
            }
            else if (invulnTime != 0 && invulnTimer <= 0)
            {
                //Invulnerability worn off
                invulnerable = false;
                gameObject.SendMessage("enableInvulnAnim", false);
            }
        }

	    if (currentHealth <= 0)
        {
            //gameObject.SendMessage()
            die();
        }
	}

    //
    void takeDamage(float damage)
    {
        //Other variables in here such as shielding, powerups etc?

        //Basic:
        if (!invulnerable)
        {
            currentHealth -= damage;
        }

        if (invulnTime != 0)
        {
            invulnTimer = invulnTime;
            gameObject.SendMessage("enableInvulnAnim", true);
        }
    }

    //Called when health reaches 0 (i.e. object has 'died')
    void die()
    {
        if (gameObject.tag == "Player")
        {
            //Game over
            
        }
        print("OBJECT DESTROYED");
        DestroyObject(gameObject);
    }
}

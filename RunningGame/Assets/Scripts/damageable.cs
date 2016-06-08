using UnityEngine;
using System.Collections;

//Creates new particle system using a prefab??

public class damageable : MonoBehaviour {

    public float health;
    public float currentHealth;

    //Set to 0 for no invuln time.
    public float invulnTime;
    private float invulnTimer;
    private bool invulnerable;

    public float deathTime;
    
    //Should help avoid scripting errors
    public bool hasParticles;
    public GameObject damageParticleObj;
    public GameObject deathParticleObj;

    private ParticleSystem damageParticles;
    private ParticleSystem deathParticles;

    public Sprite[] deathSprites;

	// Use this for initialization
	void Start ()
    {
        currentHealth = health;

        if (hasParticles)
        {
            damageParticles = damageParticleObj.GetComponent<ParticleSystem>();
            deathParticles = deathParticleObj.GetComponent<ParticleSystem>();

            damageParticles.Stop();
            deathParticles.Stop();
        }
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
	}
    
    void takeDamage(float damage)
    {
        //Other variables in here such as shielding, powerups etc?

        //Basic:
        if (!invulnerable)
        {
            if (hasParticles)
            {
                damageParticles.Play();
            }
            currentHealth -= damage;
        }

        if (invulnTime != 0)
        {
            invulnTimer = invulnTime;
            gameObject.SendMessage("enableInvulnAnim", true);
        }

        if (currentHealth <= 0)
        {
            //gameObject.SendMessage()
            die();
        }
    }

    //Called when health reaches 0 (i.e. object has 'died')
    void die()
    {
        if (hasParticles)
        {

            //Disable hitbox and all damage dealing child components
            foreach (Transform child in transform)
            {
                if (child.tag == "Enemy")
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
            gameObject.GetComponent<Collider2D>().enabled = false;
            deathParticles.Play();
            
            if (deathSprites.Length > 0)
                gameObject.SendMessage("startSpecialAnim", deathSprites);

            //Enable the death particles
            DestroyObject(gameObject, deathTime);
        }
        else
        {
            DestroyObject(gameObject);
        }

    }
}

using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour
{

    public float health;
    public float currentHealth;

    //Set to 0 for no invuln time.
    public float invulnTime;
    private float invulnTimer;
    private bool invulnerable;

    public UImanager ui;

    // Use this for initialization
    void Start()
    {
        currentHealth = health;
        ui.updateHealthDisplay(health);
    }

    // Update is called once per frame
    void Update()
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

                //SendMessage("endSpecialAnim", takeDamageSprite);
            }
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
            //SendMessage("startSpecialAnim", takeDamageSprite);
        }

        if (invulnTime != 0)
        {
            invulnTimer = invulnTime;
            invulnerable = true;
            gameObject.SendMessage("enableInvulnAnim", true);
        }

        if (currentHealth <= 0)
        {
            //gameObject.SendMessage()
            die();
        }

        ui.updateHealthDisplay(currentHealth);
    }

    //Called when health reaches 0 (i.e. object has 'died')
    void die()
    {
        if (gameObject.tag == "Player")
        {
            //Game over
            Time.timeScale = 0;
            //Show game over screen
            ui.showGameOverScreen();
        }
        print("OBJECT DESTROYED");
        DestroyObject(gameObject);
    }
}

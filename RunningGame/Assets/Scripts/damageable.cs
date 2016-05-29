using UnityEngine;
using System.Collections;

public class damageable : MonoBehaviour {

    public float health;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (health <= 0)
        {
            //gameObject.SendMessage()

            //Destroys the object in 1 second
            //Should probably do a more advanced setting that will animate the 'destruction'
            //Could call a destroy method for each object if it exists

            //Basic:
            print("OBJECT DESTROYED");

            //Needs to be timed

            //Animation for destruction
            DestroyObject(gameObject);
        }
	}

    //
    void takeDamage(float damage)
    {
        //Other variables in here such as shielding, powerups etc?

        //Basic:
        health = health - damage;
    }

    //Called when a destroyed object will be destroyed
    void destroy()
    {

    }
}

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
            DestroyObject(gameObject, 1);
        }
	}

    void takeDamage()
    {

    }
}

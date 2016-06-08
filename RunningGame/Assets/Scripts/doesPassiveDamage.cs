using UnityEngine;
using System.Collections;

public class doesPassiveDamage : MonoBehaviour {

    public float damage;
    public bool destroyObjectOnCollision;
    public bool dieOnCollision;

    public string damages;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Hitbox must be enabled for this to happen
        //Calls the 'take damage' function on the colliding object
        if (coll.gameObject.tag == damages)
        {
            coll.gameObject.SendMessage("takeDamage", damage);
        }

        if (destroyObjectOnCollision)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Hitbox must be enabled for this to happen
        //Calls the 'take damage' function on the colliding object
        if (coll.gameObject.tag == damages)
        {
            coll.gameObject.SendMessage("takeDamage", damage);
        }

        if (dieOnCollision)
        {
            SendMessage("die");
        }
        else if (destroyObjectOnCollision)
        {
            Destroy(gameObject);
        }
    }
}

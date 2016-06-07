using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    //Private timing variables
    public float damage;
    public bool destroyObjectOnCollision;
    public bool stopAttackOnCollision;

    public string damagesWhat;

    public bool fixedDirection;
    public Vector3 direction;
    public float speed;

    private 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector3 aimLocation)
    {
        //direction = aimLocation;
        //direction = gameObject.transform.position - aimLocation;
        if (!fixedDirection)
        {
            //direction =  gameObject.transform.position - aimLocation;
        //direction =  aimLocation + gameObject.transform.position;
            direction =  aimLocation - gameObject.transform.position;
        }
        direction.Normalize();
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Calls the 'take damage' function on the colliding object
        if (coll.gameObject.tag == damagesWhat)
        {
            coll.gameObject.SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
            if (destroyObjectOnCollision)
            {
                Destroy(gameObject);
            }
        }
        //Bug: collides with itself
        /*
        if (destroyObjectOnCollision && coll.gameObject.tag != gameObject.tag)
        {
            Destroy(gameObject);
        }*/
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Hitbox must be enabled for this to happen
        //Calls the 'take damage' function on the colliding object
        if (coll.gameObject.tag == damagesWhat)
        {
            coll.gameObject.SendMessage("takeDamage", damage);
            if (destroyObjectOnCollision)
            {
                Destroy(gameObject);
            }
        }
    }
}

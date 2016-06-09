using UnityEngine;
using System.Collections;

//Used for simple fixed obstacles that are in the way
public class obstacleController : MonoBehaviour
{
    //Attack attributes
    public float damage;
    public bool destroyOnPlayerColl;

    //Determines the sprites that the animator will use when colliding with the player
    //public Sprite[] attackSprites;

    private Collider2D hitbox;

    // Use this for initialization
    void Start()
    {
        //Should select the first Collider2D in the instance
        hitbox = GetComponent<Collider2D>();
        hitbox.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Calls the 'take damage' function on the player
        if (destroyOnPlayerColl && coll.gameObject.tag == "Player")
        {
            print(gameObject.ToString() + " dealing " + damage + " damage to: " + coll.gameObject.ToString());
            coll.gameObject.SendMessage("takeDamage", damage);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {

    public GameObject[] groundAttacks;
    public GameObject[] airAttacks;

    private bool grounded;
    private bool attacking;

    private GameObject player;
    private Transform playerTransform;
    private Transform thisTransform;


    //How much randomness to add to attacks
    //0 = 100% accurate, 1 = maximum amount of randomness
    public float accuracy;

    //Detection range in units to begin a ranged attack
    public float detectionRange;
    //Attack range in units to begin a close range attack
    public float attackRange;

	// Use this for initialization
	void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        thisTransform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, thisTransform.position);

        if (groundAttacks.Length > 0 && distanceToPlayer <= attackRange && !attacking)
        {
            //choose random ground attack, use it
            int index = Random.Range(0, groundAttacks.Length);
            groundAttacks[index].SendMessage("startAttack");
        }
        else if (airAttacks.Length > 0 && distanceToPlayer <= detectionRange && !attacking)
        {
            int index = Random.Range(0, airAttacks.Length);
            airAttacks[index].SendMessage("startAttack");
        }
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        //Need to add 'if collision object is top of a floor tile', to allow collisions with other objects
        //Return to the ground faster than using y speed
        if (!grounded && coll.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

    void isAttacking(bool attacking)
    {
        this.attacking = attacking;
        
    }
}

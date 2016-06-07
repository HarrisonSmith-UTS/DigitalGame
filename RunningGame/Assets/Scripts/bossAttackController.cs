using UnityEngine;
using System.Collections;

//Time limit between attacks (should set cooldown on attacks to 0?)
public class bossAttackController : MonoBehaviour {
    
    public GameObject[] attacks;
    private bool attacking;
    private Camera mainCamera;

    //Count down after attacking until next attack...
    private float attackTimer;
    //Picks a random time to set the timer to after attacking in seconds
    public float maxTimerAmount;
    public float minTimerAmount;

    //How much randomness to add to attacks
    //0 = 100% accurate, 1 = maximum amount of randomness
    //Note: not implemented
    public float accuracy;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        resetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        //Need a way to synch this up with movement?
        //Need a way to stop movement? e.g. gameObject.SendMessage("pauseMovement")
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0 && !attacking)
        {
            //Attack
            int index = Random.Range(0, attacks.Length);
            attacks[index].SendMessage("startAttack");
            resetTimer();
        }
        
    }

    void isAttacking(bool attacking)
    {
        this.attacking = attacking;
    }

    void resetTimer()
    {
        //Sets the 
        attackTimer = Random.Range(minTimerAmount, maxTimerAmount);
    }
}

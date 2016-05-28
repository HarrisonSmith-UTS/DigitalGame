using UnityEngine;
using System.Collections;

//Attached to main gameObject, controls attack start and stop
//Recieves input from the input controller, controls all attacks
//Does not handle specific attack info, that is on a child attack class
public class attackController : MonoBehaviour
{
    GameObject attackObj;

    // Use this for initialization
    void Start ()
    {
        attackObj = transform.FindChild("player_sword_attack").gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //When attack ends:
        //BroadcastMessage("endAttack");
	}

    //Defines what happens when the gameObject initiates an attack
    void attack(/*string attackName*/)
    {
        //enable child object hitbox?
        //attackObj.SendMessage("startAttack");
        //HS - replaced with a broadcast in playerController

        //Later: Holds an array of gameObjects for different attacks?


        //start timer to time down the hit?

    }
}

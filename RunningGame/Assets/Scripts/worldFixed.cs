using UnityEngine;
using System.Collections;

public class worldFixed : MonoBehaviour {

    public GameObject player;
    private Transform playerPos;

    // Use this for initialization
    void Start ()
    {
        playerPos = player.GetComponent<Transform>();
        //HS - commented out for testing. Please remove this later as necessary
        //Destroy(gameObject, 3);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Transform transObj = GetComponent<Transform>();
        //print("Playerpos - this floortile = " + (playerPos.position.x - transObj.position.x));
        if (playerPos.position.x - transObj.position.x  >= 4)
        {
            //print("Destroying object");
            //Destroys the object after leaving the dimensions

            //'gameObject' is the object that this sprite is attached to
            Destroy(gameObject);
        }
    }
}

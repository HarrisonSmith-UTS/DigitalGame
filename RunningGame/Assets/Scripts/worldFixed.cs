using UnityEngine;
using System.Collections;

public class worldFixed : MonoBehaviour {

    private GameObject player;
    private Transform playerPos;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        playerPos = player.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Transform transObj = GetComponent<Transform>();
        if (playerPos.position.x - transObj.position.x  >= 4)
        {
            //print("Destroying object");
            //Destroys the object after leaving the dimensions

            //'gameObject' is the object that this sprite is attached to
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class worldScrolling : MonoBehaviour
{

    //private something 
    public float endPosition;
    public float scrollSpeed;

    // Use this for initialization
    void Start()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().velocity = new Vector2(-gameSpeed, 0);
        //Gets game speed from the generatefloorandceiling section
        
        scrollSpeed = globalConstants.scrollSpeed;
        rigidBody.velocity = new Vector2(-scrollSpeed, 0);
        //rigidBody.AddForce(new Vector2(-scrollSpeed, 0));

        //print("Start function called");

        //Testing auto destroying objects
        //Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Transform transObj = GetComponent<Transform>();

        if (transObj.position.x <= -4)
        {
            print(transObj.position.x);
            //Destroys the object after leaving the dimensions
            //DestroyObject(gameObject);
            Destroy(gameObject);
        }
    }
}

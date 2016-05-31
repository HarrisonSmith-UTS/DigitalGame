using UnityEngine;
using System.Collections;

public class worldScrolling : MonoBehaviour
{
    //This moves objects constantly to the right (e.g. player, camera)
    //Opposite of 'worldFixed' script


    //private something
    private float scrollSpeed;
    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().velocity = new Vector2(-gameSpeed, 0);
        //Gets game speed from the generatefloorandceiling section
        scrollSpeed = globalConstants.scrollSpeed;
        rigidBody.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Needs to be replaced/fixed
        rigidBody.velocity = new Vector2(scrollSpeed, rigidBody.velocity.y);
    }
}

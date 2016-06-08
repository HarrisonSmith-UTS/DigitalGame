using UnityEngine;
using System.Collections;

public class bossScrolling : MonoBehaviour
{
    //This moves objects constantly to the right (e.g. player, camera)
    //Opposite of 'worldFixed' script


    //private something
    private float scrollSpeed;
    private Rigidbody2D rigidBody;
    private Transform cameraPos;
    public float offSet;
    private bool onScreen;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //Gets game speed from the generatefloorandceiling section
        scrollSpeed = globalConstants.scrollSpeed;
        cameraPos = Camera.main.transform;
        onScreen = false;
    }

    void OnBecameVisible()
    {
        //rigidBody.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //If object comes within the offset
        if (!onScreen && gameObject.transform.position.x < cameraPos.position.x + offSet)
        {
            rigidBody.velocity = new Vector2(scrollSpeed, 0);
            onScreen = true;
        }
    }
}

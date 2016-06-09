using UnityEngine;
using System.Collections;

public class backgroundScroll : MonoBehaviour {

    //This moves objects constantly to the right (e.g. player, camera)
    //Opposite of 'worldFixed' script


    //private something
    private float scrollSpeed;
    private Rigidbody2D rigidBody;
    public float multiplier;

    private Transform cameraTransform;
    private float spriteWidth;
    private SpriteRenderer spriteRenderer;

    //Sets up a secondary offset background to continue the scrolling effect
    public bool isSecondaryOffset;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().velocity = new Vector2(-gameSpeed, 0);
        //Gets game speed from the generatefloorandceiling section
        scrollSpeed = globalConstants.scrollSpeed;
        rigidBody.velocity = new Vector2(scrollSpeed * multiplier, 0);
        
        cameraTransform = Camera.main.transform;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x * transform.localScale.x;

        if (isSecondaryOffset)
        {
            //shift to the right by sprite width
            Vector3 newPos = transform.position;
            newPos.x += spriteWidth;
            transform.position = newPos;
        }
    }

    void FixedUpdate()
    {
        //Forces scrolling on x at a certain speed
        rigidBody.velocity = new Vector2(scrollSpeed * multiplier, 0);
    }

    void Update()
    {
        if ((transform.position.x + spriteWidth) < cameraTransform.position.x)
        {
            
            Vector3 newPos = transform.position;
            //2 times the width because a whole width is being covered by the other background object
            newPos.x += 2.0f * spriteWidth;
            transform.position = newPos;
        }
    }
}

using UnityEngine;
using System.Collections;

public class bossMovementController : MonoBehaviour {

    //relative to the main camera
    public Vector3[] positions;
    //Used with the array
    private int startPosID;
    private int endPosID;
    private Vector3 absoluteStartPos;
    private Vector3 absoluteEndPos;

    //Used for scrolling movement & applying velocity
    private Rigidbody2D rigidBody;
    private float scrollSpeed;

    private Vector3 aimDirection;
    public float speed;

    private Camera cam;

    private float stillTimer;
    public float stillTime;
    private bool still;

    //Used for determining movement for the boss
    private float distanceTraveled;
    private float distanceNeeded;

    // Use this for initialization
    void Start ()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        cam = Camera.main;
        scrollSpeed = globalConstants.scrollSpeed;
        absoluteStartPos = transform.position;

        //Stop moving until object is visible on screen
        still = true;
        stillTimer = 99;
    }

    void OnBecameVisible()
    {
        //Start moving?
        //Slightly buggy. He will start moving after the timer has count down... Workaround: set timer to large amount
        still = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (still)
        {
            stillTimer -= Time.deltaTime;

            if (stillTimer <= 0)
            {
                //End of still movement period is over
                startMove();
                still = false;
            }
        }
        else
        {
            //Update absoluteEndPositions (the position of the object in regards to the camera)
            absoluteEndPos = positions[endPosID] + cam.transform.position;

            //Distances traveled on the direction vector
            //These will scale up as the absoluteEndPos moves with the 
            distanceTraveled = Vector3.Distance(absoluteStartPos, transform.position);
            distanceNeeded = Vector3.Distance(absoluteStartPos, absoluteEndPos);

            //If object has reached the destination ()
            if (distanceTraveled >= distanceNeeded)
            {
                //if point is reached, sets up next movement (or starts 'still timer')
                stopMove();
                still = true;
                stillTimer = stillTime;
            }
        }

    }

    void startMove()
    {
        //Selects next movement along
        startPosID = endPosID;
        endPosID = indexIncrementor(endPosID, positions.Length);

        //Sets up absolute start position
        absoluteStartPos = transform.position;

        //maybe this should not be the absolute end pos? No, because it is only called once at the start, and the directional vector is being applied
        aimDirection = absoluteEndPos - gameObject.transform.position;
        aimDirection.Normalize();
        //Launches in aim direction with scroll speed added
        rigidBody.velocity = (aimDirection * speed) + new Vector3(scrollSpeed, 0);
    }

    void stopMove()
    {
        //Maintains scrolling but stops all other movement
        rigidBody.velocity = new Vector2(scrollSpeed, 0);
    }

    void setObjectStill(bool still)
    {
        this.still = still;
    }

    int indexIncrementor(int i, int length)
    {
        i++;
        if (i > length)
        {
            i = 0;
        }
        return i;
    }

    
}

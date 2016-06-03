using UnityEngine;
using System.Collections;

public class worldFixed : MonoBehaviour {

    private GameObject player;
    private Transform playerPos;
    private Camera mainCam;

    //Code for camera shit
    public enum ScreenEdge { LEFT, RIGHT, TOP, BOTTOM };
    private Vector2[] screenEdges;
    public ScreenEdge startScreenEdge;
    public float yOffset;
    public float xOffset;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.GetComponent<Transform>();

        Vector3 newPosition = transform.position;
        mainCam = Camera.main;

        initialiseScreenEdgePositions();

        //Sets up screen edges
        newPosition = getCameraEdge(ScreenEdge.RIGHT);

        transform.position = newPosition;
    }

    private void initialiseScreenEdgePositions()
    {
        //Top
        screenEdges[0] = new Vector2(xOffset, mainCam.orthographicSize + yOffset);
        //Right
        screenEdges[1] = new Vector2(mainCam.aspect * mainCam.orthographicSize + xOffset, yOffset);
        //Bottom
        screenEdges[2] = new Vector2(xOffset, -mainCam.orthographicSize + yOffset);
        //Left
        screenEdges[3] = new Vector2(-mainCam.aspect * mainCam.orthographicSize + xOffset, yOffset);        
    }

    //REturns 
    public Vector2 getCameraEdge(ScreenEdge chosenEdge)
    {
        switch (chosenEdge)
        {
            case ScreenEdge.TOP:
                return screenEdges[0];
            case ScreenEdge.RIGHT:
                return screenEdges[1];
            case ScreenEdge.BOTTOM:
                return screenEdges[2];
            case ScreenEdge.LEFT:
                return screenEdges[3];
            default:
                return screenEdges[1];
        }
    }

	// Update is called once per frame
	void Update ()
    {
        // = GetComponent<Transform>();
        /*
        if (playerPos.position.x - transObj.position.x  >= 4)
        {
            //print("Destroying object");
            //Destroys the object after leaving the dimensions

            //'gameObject' is the object that this sprite is attached to
            Destroy(gameObject);
        }*/
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

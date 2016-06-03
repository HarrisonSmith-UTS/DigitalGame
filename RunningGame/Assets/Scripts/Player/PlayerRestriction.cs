using UnityEngine;
using System.Collections;

public class PlayerRestriction : MonoBehaviour {

    private Vector2 newPosition;
    private Camera mainCamera;
    private Vector2 cameraPosition;

    //Moves the boundaries in or out from the camera edges
    public float xMaxOffset;
    public float xMinOffset;
    public float yMaxOffset;
    public float yMinOffset;

    private float xDist;
    private float xMax;
    private float xMin;
    private float yMax;
    private float yMin;


    private Rigidbody2D rigidBody;
    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        EnforceBounds();
    }

    private void EnforceBounds()
    {
        newPosition = transform.position;
        cameraPosition = mainCamera.transform.position;

        xDist = mainCamera.aspect * mainCamera.orthographicSize;
        xMax = cameraPosition.x + xDist + xMaxOffset;
        xMin = cameraPosition.x - xDist + xMinOffset;
        yMax = mainCamera.orthographicSize + yMaxOffset;
        yMin = -mainCamera.orthographicSize + yMinOffset;

        if (newPosition.x < xMin || newPosition.x > xMax)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        }
        // TODO vertical bounds
        if (newPosition.y < -yMax || newPosition.y > yMax)
        {
            newPosition.y = Mathf.Clamp(newPosition.y, -yMax, yMax);
            //changes y velocity to zero to start falling immediately
            rigidBody.velocity = new Vector2();
        }

        // 4
        transform.position = newPosition;
    }
}

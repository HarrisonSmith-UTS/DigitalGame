using UnityEngine;
using System.Collections;

public class EnvironGen2 : MonoBehaviour
{
    public float createPosX;
    private float createPosY;

    public GameObject[] environParts;
    private GameObject lastCreatedObj;
    private int enIndex;
    private PooledObject2 poolScript;

    private Camera mainCam;
    private float rightSideOfCam;

    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
        enIndex = 0;
        createPosY = 0;

        rightSideOfCam = mainCam.aspect * mainCam.orthographicSize;

        //Creates one object off the bat
        lastCreatedObj = (GameObject)Instantiate(environParts[enIndex], new Vector3(createPosX, createPosY, 0), Quaternion.identity);

        createObject();
    }

    void Update()
    {
        if (createPosX <  mainCam.transform.position.x + rightSideOfCam)
        {
            createObject();
        }
    }

    public void objectBecameVisible()
    {
        createObject();
    }

    //Called when an environment piece moves onto screen, indicating a new one is ready to be created off-screen

    void createObject()
    {
        //Increments by the last created object.
        poolScript = lastCreatedObj.GetComponent<PooledObject2>();
        createPosX += poolScript.halfObjectWidth;

        //Chooses random object to create
        enIndex = Random.Range(0, environParts.Length);

        //Increments by the newly created object
        poolScript = environParts[enIndex].GetComponent<PooledObject2>();
        createPosX += poolScript.halfObjectWidth;
        createPosY = poolScript.defaultPosition.y;

        lastCreatedObj = (GameObject)Instantiate(environParts[enIndex], new Vector3(createPosX, createPosY, 0), Quaternion.identity);
    }

    //Pooling stuff
    
}

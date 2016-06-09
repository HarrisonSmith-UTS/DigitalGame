using UnityEngine;
using System.Collections;

public class EnvironGen2 : MonoBehaviour
{
    public float createPosX;
    public float createPosY;

    public GameObject[] environParts;
    private GameObject lastCreatedObj;
    public GameObject startingArea;
    private int enIndex;
    private PooledObject2 poolScript;

    private Camera mainCam;
    private float rightSideOfCam;

    //After scene timer exceeded, switches scenes
    public bool useSceneTimer;
    public float maxSceneTime;
    private float sceneTimer;

    //private SceneFadeInOut sceneFader;

    // Use this for initialization
    void Start()
    {
        sceneTimer = 0;

        mainCam = Camera.main;
        enIndex = 0;

        rightSideOfCam = mainCam.aspect * mainCam.orthographicSize;

        //Creates one object off the bat
        lastCreatedObj = (GameObject)Instantiate(startingArea, new Vector3(createPosX, createPosY, 0), Quaternion.identity);
    }

    void Update()
    {
            if (createPosX <  mainCam.transform.position.x + rightSideOfCam)
            {

                if (sceneTimer < maxSceneTime || !useSceneTimer)
                {
                    //creates as usual
                    createObject();
                }
                else
                {
                    //fade out

                }
            }
            sceneTimer += Time.deltaTime;
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

        int oldIndex = enIndex;
        //Chooses random object to create
        enIndex = Random.Range(0, environParts.Length - 1);
        if (enIndex == oldIndex)
        {
            enIndex = indexIncrementor(enIndex, environParts.Length -1);
        }

        //Increments by the newly created object
        poolScript = environParts[enIndex].GetComponent<PooledObject2>();
        createPosX += poolScript.halfObjectWidth;
        createPosY = poolScript.defaultPosition.y;

        lastCreatedObj = (GameObject)Instantiate(environParts[enIndex], new Vector3(createPosX, createPosY, 0), Quaternion.identity);
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
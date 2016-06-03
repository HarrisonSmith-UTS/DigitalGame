using UnityEngine;
using System.Collections;

public class EnvironmentGenerator : MonoBehaviour
{
    public Vector3 createPosition;
    public Vector3 poolPosition;

    public GameObject[] environParts;
    private int enIndex;
    private PooledObject poolScript;

    private Camera mainCam;

    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
        //instantiate all objects above the screen
        instantiateAll();

        enIndex = 0;

        enableObject();
    }

    private void instantiateAll()
    {
        //Initalises all environment prefabs here and creates usable objects out of them
        for (int i= 0; i < environParts.Length; i++)
        {
            environParts[i] = (GameObject)Instantiate(environParts[i], poolPosition, Quaternion.identity);
            environParts[i].GetComponent<PooledObject>().initialiseEnvironScript(this);
            environParts[i].SetActive(false);
        }
    }

    //Called when an environment piece moves onto screen, indicating a new one is ready to be created off-screen
    public void objectBecameVisible()
    {
        calculateCreatePosition();
        enableObject();
    }

    //Figures out where to create the new object. Probably could be optimised later.
    void calculateCreatePosition()
    {
        //get right-hand side of the 'old' object
        poolScript = environParts[enIndex].GetComponent<PooledObject>();

        createPosition.x = createPosition.x + poolScript.halfObjectWidth;

        //select a new random environment piece
        enIndex = Random.Range(0, environParts.Length);

        //Checks if object is ready to be pooled or not
        while (environParts[enIndex].activeSelf)
        {
            //Chooses another pooled object
            enIndex++;
            if (enIndex >= environParts.Length)
            {
                enIndex = 0;
            }
        }

        poolScript = environParts[enIndex].GetComponent<PooledObject>();
        //Adds half the bounds of the new object
        createPosition.x = createPosition.x + environParts[enIndex].GetComponent<PooledObject>().halfObjectWidth;
        createPosition.y = poolScript.defaultPosition.y;
    }

    //Enables pooled object, figures out where to put it
    void enableObject()
    {
        environParts[enIndex].SetActive(true);
        environParts[enIndex].transform.position = createPosition;
    }

    //Pooling stuff
    public void objectBecameInvisible(GameObject givenObject)
    {
        //May not even need to move the pooling position
            //poolPosition = new Vector2(mainCam.transform.position.x, poolPosition.y);
        //Move the given object, which should move the same one in the array??
        givenObject.SetActive(false);
        givenObject.transform.position = poolPosition;
    }
}

using UnityEngine;
using System.Collections;

public class PooledObject2 : MonoBehaviour
{
    private EnvironGen2 environScript;
    public bool specifyObjectWidth;
    public float objectWidth;
    public float halfObjectWidth;

    private Camera cam;

    public Vector3 defaultPosition;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        if (!specifyObjectWidth)
        {
            objectWidth = gameObject.GetComponent<Collider2D>().bounds.size.x;
            halfObjectWidth = objectWidth / 2;
            print("Size of bounds: " + objectWidth);
            print("Half size: " + halfObjectWidth);
        }
        //defaultPosition = transform.position;
    }

    //Allows the environment script to set this object up for generation properly
    public void initialiseEnvironScript(EnvironGen2 script)
    {
        environScript = script;
    }

    void OnBecameVisible()
    {
        //tell environment generator that it can create another object
        //environScript.objectBecameVisible();
    }

    void FixedUpdate()
    {
        if (cam.transform.position.x  - (gameObject.transform.position.x + (cam.aspect * cam.orthographicSize)) > halfObjectWidth)
        {
            Destroy(gameObject);
        }
    }

    /*
    void OnBecameInvisible()
    {
        Destroy(gameObject);
        //return to pool
        //Somehow notify environment generator?
        //environScript.objectBecameInvisible(gameObject);
    }*/
}

using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour
{   
    private EnvironmentGenerator environScript;
    public bool specifyObjectWidth;
    public float objectWidth;
    public float halfObjectWidth;

    public Vector3 defaultPosition;

    public bool inPool;

    // Use this for initialization
    void Start()
    {
        if (!specifyObjectWidth)
        {
            objectWidth = gameObject.GetComponent<Collider2D>().bounds.size.x;
        }
        halfObjectWidth = objectWidth / 2;
        //defaultPosition = transform.position;
    }

    //Allows the environment script to set this object up for generation properly
    public void initialiseEnvironScript(EnvironmentGenerator script)
    {
        environScript = script;
    }
    
    void setInPool(bool setPool)
    {
        inPool = setPool;
    }

    void OnBecameVisible()
    {
        //tell environment generator that it can create another object
        environScript.objectBecameVisible();
    }

    void OnBecameInvisible()
    {
        //Destroy(gameObject);
        //return to pool
        //Somehow notify environment generator?
        inPool = false;
        environScript.objectBecameInvisible(gameObject);
    }
}

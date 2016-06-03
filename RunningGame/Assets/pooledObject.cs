using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour
{   
    private EnvironmentGenerator environScript;
    public bool specifyObjectWidth;
    public float halfObjectWidth;

    // Use this for initialization
    void Start()
    {
        if (!specifyObjectWidth)
        {
            halfObjectWidth = gameObject.GetComponent<Collider2D>().bounds.size.x / 2;
        }
    }

    //Allows the environment script to set this object up for generation properly
    public void initialiseEnvironScript(EnvironmentGenerator script)
    {
        environScript = script;
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
        environScript.objectBecameInvisible(gameObject);
    }
}

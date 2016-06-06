using UnityEngine;
using System.Collections;

public class worldFixed : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

	// Update is called once per frame
	void Update ()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

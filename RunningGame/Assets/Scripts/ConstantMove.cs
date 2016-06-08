using UnityEngine;
using System.Collections;

public class ConstantMove : MonoBehaviour {

    public Vector2 direction;
    public float speed;

	// Use this for initialization
	void Start ()
    {
	
	}

    //Called when enabled
    void OnEnable()
    {
        direction.Normalize();
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
	
    //Should use on visible instead

	// Update is called once per frame
	void Update ()
    {
	
	}
}

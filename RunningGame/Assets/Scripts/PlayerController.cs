using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool grounded = true;
    public float jumpPower = 100;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //'Jump'

        if (!grounded && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            grounded = true;
        }
        if (Input.GetButtonDown("Fire1") && grounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower);
            grounded = false;
        }
    }

    //Called regularly
    void fixedUpdate()
    {
        
    }
}

using UnityEngine;
using System.Collections;

public class GenerateFloorAndCeiling : MonoBehaviour
{
    //Dictates how fast everything moves past the player
    public float scrollSpeed = 10;
    //public float scrollSpeed;

    public Vector3 floorCreatePosition;

    public GameObject floorTile;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //creates floor tiles as needed
    void FixedUpdate()
    {
        createFloorTile();
    }

    //Creates a floor tile on the right
    void createFloorTile()
    {
        Object newFloorTile = Instantiate(floorTile, floorCreatePosition, new Quaternion(0, 0, 0, 0));
        floorTile.GetComponent<Transform>().position = new Vector3(0, 10, 0);
    }
}

using UnityEngine;
using System.Collections;

public class GenerateFloorAndCeiling : MonoBehaviour
{
    //Dictates how fast everything moves past the player
    private float scrollSpeed;
    //public float scrollSpeed;

    public Vector3 floorCreatePosition;

    public GameObject floorTile;
    //Need to move these to their respective objects
    //public GameObject mainCam;
    public GameObject player;
    public Transform playerPos;

	// Use this for initialization
	void Start ()
    {
	    //Create a floor to start with
        scrollSpeed = globalConstants.scrollSpeed;
        playerPos = player.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //creates floor tiles as needed
    void FixedUpdate()
    {
        if (playerPos.position.x - floorCreatePosition.x >= -6)
        {
            createFloorTile();
        }
        
        /*if ((int)(Time.timeSinceLevelLoad * scrollSpeed * 4) %  scrollSpeed == 0)
        {
            createFloorTile();
        }*/
    }

    //Creates a floor tile on the right
    void createFloorTile()
    {
        Object newFloorTile = Instantiate(floorTile, floorCreatePosition, Quaternion.identity);
        //GameObject newFloorTileGame = (GameObject)newFloorTile;
        floorCreatePosition.x++;
        //Need to move these to their respective objects
    }
}

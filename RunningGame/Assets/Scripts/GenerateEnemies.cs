using UnityEngine;
using System.Collections;

public class GenerateEnemies : MonoBehaviour {

    //Dictates how fast everything moves past the player
    private float scrollSpeed;
    //public float scrollSpeed;

    public Vector3 enemyCreatePosition;

    public GameObject[] enemies;
    //Need to move these to their respective objects
    //public GameObject mainCam;
    public GameObject player;
    private Transform playerPos;

    private float enemyTimer;
    private float enemySpawnTimeMin;
    private float enemySpawnTimeMax;

    // Use this for initialization
    void Start()
    {
        //Create a floor to start with
        scrollSpeed = globalConstants.scrollSpeed;
        playerPos = player.GetComponent<Transform>();
        enemyTimer = Random.Range(enemySpawnTimeMin, enemySpawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //creates floor tiles as needed
    void FixedUpdate()
    {
        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0)
        {
            //spawn new enemy. Choose random enemy?
            createEnemy(0);
            //reset timer
            enemyTimer = Random.Range(enemySpawnTimeMin, enemySpawnTimeMax);

        }
        /*if ((int)(Time.timeSinceLevelLoad * scrollSpeed * 4) %  scrollSpeed == 0)
        {
            createFloorTile();
        }*/
    }

    void createEnemy(int index)
    {
        //creates an enemy (possibly decides between multiple types of enemy per scene)
        //change index later
        //enemy will be moved by it's 'world fixed' script?
        Camera mainCam = Camera.main;
        //generates on the right hand side of the camera??
        Object enemy = Instantiate(enemies[index], new Vector2(mainCam.aspect * mainCam.orthographicSize, 0), Quaternion.identity);
    }
}
